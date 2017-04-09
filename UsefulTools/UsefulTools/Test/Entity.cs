using UsefulTools.AxisAlignedBoundingBox;
using UsefulTools.QuadTree;

namespace UsefulTools.Test
{
    public class Entity : IHasAABB2D
    {
        private AABB2D _boundingBox;

        public AABB2D BoundingBox { get { return _boundingBox; } }

        public Entity(AABB2D boundingBox)
        {
            _boundingBox = boundingBox;
        }
    }
}
