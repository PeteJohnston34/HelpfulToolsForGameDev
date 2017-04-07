using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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
                testTree1.add(new Entity(new Rectangle(random.Next(640 - 33), random.Next(480 - 33), 16, 16)));
            }
            testTree1.print();

            List<Entity> entities = testTree1.queryArea(new Rectangle(0, 0, 320, 240));
            int index = 0;

            entities.ForEach(e =>
            {
                Console.Write(index + " - " + e.ToString() + " Rectangle: ");
                IHasRect eRect = (IHasRect)e;
                Console.WriteLine(eRect.Rect.ToString());
                index++;
            });
            return 0;
        }
    }
}
