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
            //for (int i = 0; i < 50; i++)
            //{
            //    testTree1.add(new Entity(new Rectangle(random.Next(640 - 33), random.Next(480 - 33), 16, 16)));
            //}

            Entity entity1 = new Entity(new Rectangle(10, 10, 16, 16));
            Entity entity2 = new Entity(new Rectangle(20, 20, 16, 16));
            Entity entity3 = new Entity(new Rectangle(random.Next(640 - 33), random.Next(480 - 33), 16, 16));
            Entity entity4 = new Entity(new Rectangle(random.Next(640 - 33), random.Next(480 - 33), 16, 16));
            Entity entity5 = new Entity(new Rectangle(300, 200, 16, 16));
            Entity entity6 = new Entity(new Rectangle(random.Next(640 - 33), random.Next(480 - 33), 16, 16));
            Entity entity7 = new Entity(new Rectangle(random.Next(640 - 33), random.Next(480 - 33), 16, 16));
            Entity entity8 = new Entity(new Rectangle(random.Next(640 - 33), random.Next(480 - 33), 16, 16));
            Entity entity9 = new Entity(new Rectangle(random.Next(640 - 33), random.Next(480 - 33), 16, 16));
            Entity entity10 = new Entity(new Rectangle(random.Next(640 - 33), random.Next(480 - 33), 16, 16));

            testTree1.add(entity1);
            testTree1.add(entity2);
            testTree1.add(entity3);
            testTree1.add(entity4);
            testTree1.add(entity5);
            testTree1.add(entity6);
            testTree1.add(entity7);
            testTree1.add(entity8);
            testTree1.add(entity9);
            testTree1.add(entity10);

            testTree1.print();

            testTree1.remove(entity4);
            testTree1.remove(entity3);
            testTree1.remove(entity10);
            testTree1.remove(entity8);
            testTree1.remove(entity6);
            testTree1.remove(entity7);
            testTree1.remove(entity9);

            testTree1.print();

            List<Entity> entities = testTree1.queryArea(new Rectangle(0, 0, 100, 100));
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
