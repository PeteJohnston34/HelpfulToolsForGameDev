using System;
using System.Collections.Generic;
using UsefulTools.AxisAlignedBoundingBox;

namespace UsefulTools.QuadTree
{
    //A QuadTree Implementation for use with Monogame.
    //Type T must implement IHasRect
    public class QuadTreeAABBImplementation<T> : Node<T>
    {
        //members
        private StandardNode<T> _root;
        private AABB2D __boundingBox;

        //properties
        public override AABB2D BoundingBox { get { return __boundingBox; } }

        //constructor
        public QuadTreeAABBImplementation(AABB2D area)
        {
            if (!typeof(IHasAABB2D).IsAssignableFrom(typeof(T)))
            {
                throw new TypeWithoutAABBException();
            }

            __boundingBox = area;
            _root = new StandardNode<T>(area, this);
        }

        //public methods
        public override void add(T entity)
        {
            _root.add(entity);
        }

        public override void remove(T entity)
        {
            IHasAABB2D entityRect = (IHasAABB2D)entity;
            if (entityRect.BoundingBox.intersects(BoundingBox)) { _root.remove(entity); }
        }

        public override void print(string indent = "")
        {
            Console.WriteLine("Tree Contents:");
            _root.print(indent);
        }

        public override List<T> queryArea(AABB2D areaToQuery, List<T> entitiesFound = null)
        {
            return _root.queryArea(areaToQuery, new List<T>());
        }

        public override void checkChildren() {}
    }
}
