using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace UsefulTools.QuadTree
{
    class StandardNode<T> : Node<T>
    {
        private static int QUADS = 4;

        //Members
        private StandardNode<T>[] _children; //Quadrants are organized in the following order: {Nw, Ne, Sw, Se}
        private Node<T> _parent;
        private Rectangle _rectangle;
        private T _entity;

        //Properties
        public bool HasChildren { get; private set; }
        public bool HasEntity { get; private set; }
        public override Rectangle Rect { get { return _rectangle; } }

        //Constructor
        public StandardNode(Rectangle rectangle, Node<T> parent)
        {
            _children = new StandardNode<T>[QUADS];
            _parent = parent;
            _rectangle = rectangle;
            _entity = default(T);
            HasChildren = false;
            HasEntity = false;
        }

        //Public Methods
        public override void add(T entity)
        {       
            if (!HasEntity)
            {
                _entity = entity;
                HasEntity = true;
            }
            else
            {
                if (!HasChildren) { createChildren(); }

                IHasRect entityRect = (IHasRect)entity;

                for (int i = 0; i < QUADS; i++)
                {
                    if(_children[i]._rectangle.Intersects(entityRect.Rect))
                    {
                        _children[i].add(entity);
                        break;
                    }
                }
            }
        }

        public override void remove(T entity)
        {
            if (EqualityComparer<T>.Default.Equals(entity, _entity))
            {
                _entity = default(T);
                HasEntity = false;
                _parent.checkChildren();
                return;
            }
            
            if (!HasChildren) { return; }
            
            IHasRect entityRect = (IHasRect)entity;
            for (int i = 0; i < QUADS; i++)
            {
                if (HasChildren && _children[i].Rect.Intersects(entityRect.Rect))
                {
                    _children[i].remove(entity);
                }
            }
            
        }

        public override void print(string indent)
        {
            Console.WriteLine(indent + ToString());

            if (HasChildren)
            {
                indent += " - ";
                for (int i = 0; i < QUADS; i++)
                {
                    _children[i].print(indent);
                }
            }
        }

        public override List<T> queryArea(Rectangle areaToQuery, List<T> entitiesFound)
        {
            //Check for instersection with entity if one is held in this node
            if (HasEntity)
            {
                IHasRect rectEntity = (IHasRect)_entity;
                if (areaToQuery.Intersects(rectEntity.Rect))
                {
                    entitiesFound.Add(_entity);
                }
            }

            //Check child nodes for intersection, and query them if so.
            if (HasChildren)
            {
                for (int i = 0; i < QUADS; i++)
                {

                    if (areaToQuery.Intersects(_children[i].Rect))
                    {
                        entitiesFound = _children[i].queryArea(areaToQuery, entitiesFound);
                    }
                }
            }
            return entitiesFound;
        }

        //If each child node is empty of children and entities, _children is reinitialized
        public override void checkChildren()
        {
            bool empty = true;
            for (int i = 0; i < QUADS; i++)
            {
                if (_children[i].HasEntity || _children[i].HasChildren)
                {
                    empty = false;
                    break;
                }
            }

            if(empty)
            {
                HasChildren = false;
                for (int i = 0; i < QUADS; i++)
                {
                    _children[i] = null;
                }
            }
        }

        public override string ToString()
        {
            string s = "";
            if (HasEntity)
            {
                s += ("Entity # " + _entity.GetHashCode() + " ");
            }

            s += ("Quad Rectangle: " + _rectangle.ToString());

            return s;
        }

        //Private Methods

        private void createChildren()
        {
            HasChildren = true;

            //Divide the Node's rectangle into 4 quadrants           
            Point size = new Point(_rectangle.Width / 2, _rectangle.Height / 2);
            Rectangle nwRect = new Rectangle(_rectangle.Location, size);
            Rectangle neRect = new Rectangle(new Point(_rectangle.Center.X, _rectangle.Location.Y), size);
            Rectangle swRect = new Rectangle(new Point(_rectangle.Location.X, _rectangle.Center.Y), size);
            Rectangle seRect = new Rectangle(_rectangle.Center, size);

            _children[0] = new StandardNode<T>(nwRect, this);
            _children[1] = new StandardNode<T>(neRect, this);
            _children[2] = new StandardNode<T>(swRect, this);
            _children[3] = new StandardNode<T>(seRect, this);
        }
    }
}
