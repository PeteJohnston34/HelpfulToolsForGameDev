using System;

namespace UsefulTools.AxisAlignedBoundingBox
{
    public class AABB2D
    {

        //properties
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Right { get { return X + Width; } }
        public int Bottom { get { return Y + Height; } }
        public int CenterX { get { return X + (Width / 2); } }
        public int CenterY { get { return Y + (Height / 2); } }
        
        //constructor
        public AABB2D(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        //public methods
        public bool intersects(AABB2D otherBox)
        {
            return 
                (X < otherBox.Right && 
                Right > otherBox.X && 
                Y < otherBox.Bottom && 
                Bottom > otherBox.Y);
        }

        public override string ToString()
        {
            return (" {X: " + X + ", Y: " + Y + ", Width: " + Width + ", Height: " + Height + "}");
        }

        //static methods
        public static AABB2D intersects(AABB2D box1, AABB2D box2)
        {
            if (box1.intersects(box2))
            {
                int right = Math.Min(box1.Right, box2.Right);
                int left = Math.Max(box1.X, box2.X);
                int top = Math.Max(box1.Y, box2.Y);
                int bottom = Math.Min(box1.Bottom, box2.Bottom);

                return new AABB2D(left, top, right - left, bottom - top);
            }
            else
            {
                return AABB2D.Empty();
            }
        }

        public static AABB2D Empty()
        {
            return new AABB2D(0, 0, 0, 0);
        }

    }
}
