namespace UsefulTools.SearchingAndSorting
{
    public class SearchingAlgorithms
    {
        /// <summary>
        /// A Binary Search algorithm for integer arrays.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="array"></param>
        /// <returns>The index of the number is found, otherwise it returns -1</returns>
        public static int BinarySearch(int num, int[] array)
        {
            int index = -1;
            int maxI = array.Length - 1;
            int minI = 0;
            int midI = array.Length / 2;

            if (array[minI] == num) { return minI; }
            if (array[maxI] == num) { return maxI; }

            while (minI < maxI)
            {
                if (num < array[midI])
                {
                    maxI = midI;
                    midI = minI + ((maxI - minI) / 2);
                }
                else if (num > array[midI])
                {
                    minI = midI;
                    midI = minI + ((maxI - minI) / 2);
                }
                else
                {
                    index =  midI;
                    break;                    
                }

                if(midI == minI && array[midI] != num || midI == maxI && array[midI] != num) { break; }
            }
            return index; 
        }

        /// <summary>
        /// A Binary Search algorithm for double arrays.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="array"></param>
        /// <returns>The index of the number is found, otherwise it returns -1</returns>
        public static int BinarySearch(double num, double[] array)
        {
            int index = -1;
            int maxI = array.Length - 1;
            int minI = 0;
            int midI = array.Length / 2;

            if (array[minI] == num) { return minI; }
            if (array[maxI] == num) { return maxI; }

            while (minI < maxI)
            {
                if (num < array[midI])
                {
                    maxI = midI;
                    midI = minI + ((maxI - minI) / 2);
                }
                else if (num > array[midI])
                {
                    minI = midI;
                    midI = minI + ((maxI - minI) / 2);
                }
                else
                {
                    index = midI;
                    break;
                }

                if (midI == minI && array[midI] != num || midI == maxI && array[midI] != num) { break; }
            }
            return index;
        }
    }
}
