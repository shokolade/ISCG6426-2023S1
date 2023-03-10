using System;

namespace BinarySearch

{
    internal class Test

    {
        public static int IntArrayBinarySearch(int[] data, int item)
        {

            int min = 0;
            int N = data.Length;
            int max = N - 1;
            do
            {
                int mid = (min + max) / 2;
                if (item > data[mid])
                    min = mid + 1;
                else
                    max = mid - 1;
                if (data[mid] == item)
                    return mid;
          
            } while (min <= max);
            return -1;
        }

        public static void Main(string[] args)
        {
       

            int[] data = new int[10] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
           
            while (true)
            {
                Console.WriteLine("Please enter a number you want to find (blank line to end):");

                string s = Console.ReadLine();             
                int x = Int32.Parse(s);

                int foundPos = IntArrayBinarySearch(data, x);

                if (foundPos < 0)

                    Console.WriteLine("Item {0} not found", x);
                else
                    Console.WriteLine("Item {0} found at position {1}\n", x, foundPos+1);
            }
        }

    }

}
