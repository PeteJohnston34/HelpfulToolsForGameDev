using System;
using System.Collections.Generic;
using UsefulTools.AxisAlignedBoundingBox;
using UsefulTools.Heap;
using UsefulTools.QuadTree;
using UsefulTools.SearchingAndSorting;

namespace UsefulTools.Test
{
    class TestProgram
    {
        public static int Main(string[] args)
        {
            Random random = new Random();
            
            //test quadtree
            //QuadTreeAABBImplementation<Entity> testTree1 = new QuadTreeAABBImplementation<Entity>(new AABB2D(0, 0, 640, 480));

            //Entity entity1 = new Entity(new AABB2D(10, 10, 16, 16));
            //Entity entity2 = new Entity(new AABB2D(20, 20, 16, 16));
            //Entity entity3 = new Entity(new AABB2D(random.Next(640 - 33), random.Next(480 - 33), 16, 16));
            //Entity entity4 = new Entity(new AABB2D(random.Next(640 - 33), random.Next(480 - 33), 16, 16));
            //Entity entity5 = new Entity(new AABB2D(300, 200, 16, 16));
            //Entity entity6 = new Entity(new AABB2D(random.Next(640 - 33), random.Next(480 - 33), 16, 16));
            //Entity entity7 = new Entity(new AABB2D(random.Next(640 - 33), random.Next(480 - 33), 16, 16));
            //Entity entity8 = new Entity(new AABB2D(random.Next(640 - 33), random.Next(480 - 33), 16, 16));
            //Entity entity9 = new Entity(new AABB2D(random.Next(640 - 33), random.Next(480 - 33), 16, 16));
            //Entity entity10 = new Entity(new AABB2D(random.Next(640 - 33), random.Next(480 - 33), 16, 16));

            //testTree1.add(entity1);
            //testTree1.add(entity2);
            //testTree1.add(entity3);
            //testTree1.add(entity4);
            //testTree1.add(entity5);
            //testTree1.add(entity6);
            //testTree1.add(entity7);
            //testTree1.add(entity8);
            //testTree1.add(entity9);
            //testTree1.add(entity10);

            //testTree1.print();

            //testTree1.remove(entity4);
            //testTree1.remove(entity3);
            //testTree1.remove(entity10);
            //testTree1.remove(entity8);
            //testTree1.remove(entity6);
            //testTree1.remove(entity7);
            //testTree1.remove(entity9);

            //testTree1.print();

            //List<Entity> entities = testTree1.queryArea(new AABB2D(0, 0, 100, 100));
            //int index = 0;

            //entities.ForEach(e =>
            //{
            //    Console.Write(index + " - " + e.ToString() + " Rectangle: ");
            //    IHasAABB2D eRect = (IHasAABB2D)e;
            //    Console.WriteLine(eRect.BoundingBox.ToString());
            //    index++;
            //});

            //Test Heap
            //Console.WriteLine("Test Heap");
            //HeapTreeImplementation<int, Entity> testHeap = new HeapTreeImplementation<int, Entity>(HeapPriorityType.MaxHeap);
            //Entity[] testEntities = new Entity[10];

            //Console.WriteLine("Adding 10 Entities.....");
            //for (int i = 0; i < 10; i++)
            //{
            //    testEntities[i] = new Entity(new AABB2D(random.Next(640 - 33), random.Next(480 - 33), 32, 32));
            //    Console.WriteLine(testEntities[i].BoundingBox.X);
            //    testHeap.push(testEntities[i].BoundingBox.X, testEntities[i]);
            //}

            //Console.WriteLine(testHeap.peek().BoundingBox.X);

            //Console.WriteLine("Popping 5....");
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(testHeap.pop().BoundingBox.X);
            //}

            //Entity[] testEntities2 = new Entity[20];
            //Console.WriteLine("Adding 20 entities.....");
            //for (int i = 0; i < 20; i++)
            //{
            //    testEntities2[i] = new Entity(new AABB2D(random.Next(640 - 33), random.Next(480 - 33), 32, 32));
            //    Console.WriteLine(testEntities2[i].BoundingBox.X);
            //    testHeap.push(testEntities2[i].BoundingBox.X, testEntities2[i]);
            //}

            //Console.WriteLine("Emptying....");
            //while (!testHeap.IsEmpty)
            //{
            //    Console.WriteLine(testHeap.pop().BoundingBox.X);
            //}

            //Console.WriteLine("Test Binary Search");

            int[] testArray = new int[] {
                1, 4, 15, 28, 35, 78, 105, 119, 149, 209,
                215, 289, 301, 345, 372, 390, 498, 501, 589, 687,
                690, 703, 756, 767, 789, 834, 897, 903, 956, 999
            };

            //double[] testArrayDbl = new double[30];

            //for (int i = 0; i < 30; i++)
            //{
            //    testArrayDbl[i] = (double)testArray[i];
            //}

            //int result = SearchingAlgorithms.BinarySearch(989, testArray);
            //Console.WriteLine(result);
            //result = SearchingAlgorithms.BinarySearch(15, testArray);
            //Console.WriteLine(result + ", " + testArray[result]);
            //result = SearchingAlgorithms.BinarySearch(29, testArray);
            //Console.WriteLine(result);
            //result = SearchingAlgorithms.BinarySearch(390, testArray);
            //Console.WriteLine(result + ", " + testArray[result]);

            //result = SearchingAlgorithms.BinarySearch(989.0d, testArrayDbl);
            //Console.WriteLine(result);
            //result = SearchingAlgorithms.BinarySearch(15.0d, testArrayDbl);
            //Console.WriteLine(result + ", " + testArray[result]);
            //result = SearchingAlgorithms.BinarySearch(29.0d, testArrayDbl);
            //Console.WriteLine(result);
            //result = SearchingAlgorithms.BinarySearch(390.0d, testArrayDbl);
            //Console.WriteLine(result + ", " + testArray[result]);

            //Test Array heap

            //HeapArrayImplementation <int> testHeapArray = 
            //    new HeapArrayImplementation<int>(testArray, HeapArrayPriorityType.MinHeap);

            //Console.WriteLine("Popping 10");
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(testHeapArray.pop());
            //}

            //Console.WriteLine("adding 5");
            //for (int i = 0; i < 5; i++)
            //{
            //    int num = random.Next(0, 1000);
            //    Console.WriteLine(num);
            //    testHeapArray.push(num);
            //}

            //Console.WriteLine("emptying heap");
            //while (!testHeapArray.IsEmpty)
            //{
            //    Console.WriteLine(testHeapArray.pop());
            //}

            //Test Heap Sort

            int[] data = new int[100];
            Console.WriteLine("Creating array");
            for (int i = 0; i < 100; i++)
            {
                data[i] = random.Next(0, 10000);
                Console.WriteLine(data[i]);
            }

            data = SortingAlgorithms.HeapSort<int>(data, true);
            Console.WriteLine("Sorting.....");

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(data[i]);
            }

            return 0;
        }


    }
}
