using System.Collections.Generic;
using UsefulTools.AxisAlignedBoundingBox;

namespace UsefulTools.QuadTree
{
    public abstract class AbstractNode<T> : IHasAABB2D
    {
        public abstract AABB2D BoundingBox{ get; }

        public abstract void add(T entity);
        public abstract void remove(T entity);
        public abstract void print(string indent);
        public abstract List<T> queryArea(AABB2D areaToQuery, List<T> entitiesFound);
        public abstract void checkChildren();
    }
}
