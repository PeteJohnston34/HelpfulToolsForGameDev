using Microsoft.Xna.Framework;
using System;
using UsefulTools.QuadTree;

namespace UsefulTools.Test
{
    class TestProgram
    {
        public static int Main(string[] args)
        {
            QuadTreeImplementation<Entity> testTree1 = new QuadTreeImplementation<Entity>(new Rectangle(0, 0, 640, 480));
            Random random = new Random();
            for (int i = 0; i < 50; i++)
            {
                testTree1.add(new Entity(new Rectangle(random.Next(640 - 33), random.Next(480 - 33), 32, 32)));
            }
            testTree1.print();

            return 0;
        }
    }
}
