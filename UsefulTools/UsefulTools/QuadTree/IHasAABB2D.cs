using UsefulTools.AxisAlignedBoundingBox;

namespace UsefulTools.QuadTree
{
    interface IHasAABB2D
    {
        AABB2D BoundingBox { get; }
    }
}
