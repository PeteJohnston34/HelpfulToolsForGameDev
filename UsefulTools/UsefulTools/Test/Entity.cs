using Microsoft.Xna.Framework;
using System;
using UsefulTools.QuadTree;

namespace UsefulTools.Test
{
    public class Entity : IHasRect
    {
        private Rectangle _rectangle;

        public Rectangle Rect { get { return _rectangle; } }

        public Entity(Rectangle rectangle)
        {
            _rectangle = rectangle;
        }
    }
}
