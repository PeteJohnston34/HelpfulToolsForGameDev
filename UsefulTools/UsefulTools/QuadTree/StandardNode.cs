using System;
using System.Collections.Generic;
using UsefulTools.AxisAlignedBoundingBox;

namespace UsefulTools.QuadTree
{
    class StandardNode<T> : Node<T>
    {
        private static int QUADS = 4;

        //Members
        private StandardNode<T>[] _children; //Quadrants are organized in the following order: {Nw, Ne, Sw, Se}
        private Node<T> _parent;
        private AABB2D _boundingBox;
        private T _entity;

        //Properties
        public bool HasChildren { get; private set; }
        public bool HasEntity { get; private set; }
        public override AABB2D BoundingBox { get { return _boundingBox; } }

        //Constructor
        public StandardNode(AABB2D boundingBox, Node<T> parent)
        {
            _children = new StandardNode<T>[QUADS];
            _parent = parent;
            _boundingBox = boundingBox;
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

                IHasAABB2D entityRect = (IHasAABB2D)entity;

                for (int i = 0; i < QUADS; i++)
                {
                    if(_children[i].BoundingBox.intersects(entityRect.BoundingBox))
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
            
            IHasAABB2D entityRect = (IHasAABB2D)entity;
            for (int i = 0; i < QUADS; i++)
            {
                if (HasChildren && _children[i].BoundingBox.intersects(entityRect.BoundingBox))
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

        public override List<T> queryArea(AABB2D areaToQuery, List<T> entitiesFound)
        {
            //Check for instersection with entity if one is held in this node
            if (HasEntity)
            {
                IHasAABB2D rectEntity = (IHasAABB2D)_entity;
                if (areaToQuery.intersects(rectEntity.BoundingBox))
                {
                    entitiesFound.Add(_entity);
                }
            }

            //Check child nodes for intersection, and query them if so.
            if (HasChildren)
            {
                for (int i = 0; i < QUADS; i++)
                {

                    if (areaToQuery.intersects(_children[i].BoundingBox))
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

            s += ("Quad Rectangle: " + _boundingBox.ToString());

            return s;
        }

        //Private Methods

        private void createChildren()
        {
            HasChildren = true;

            //Divide the Node's bounding box into 4 quadrants           
            int sizeX = _boundingBox.Width / 2;
            int sizeY = _boundingBox.Height / 2;
            AABB2D nwRect = new AABB2D(_boundingBox.X, _boundingBox.Y, sizeX, sizeY);
            AABB2D neRect = new AABB2D(_boundingBox.CenterX, _boundingBox.Y, sizeX, sizeY);
            AABB2D swRect = new AABB2D(_boundingBox.X, _boundingBox.CenterY, sizeX, sizeY);
            AABB2D seRect = new AABB2D(_boundingBox.CenterX, _boundingBox.CenterY, sizeX, sizeY);

            _children[0] = new StandardNode<T>(nwRect, this);
            _children[1] = new StandardNode<T>(neRect, this);
            _children[2] = new StandardNode<T>(swRect, this);
            _children[3] = new StandardNode<T>(seRect, this);
        }
    }
}
