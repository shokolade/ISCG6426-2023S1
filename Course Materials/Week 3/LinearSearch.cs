namespace LinerSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[10] {10,20,30,40,50,60,70,80,90,100};
      
            Console.WriteLine("-------------------------");
        
       
            Console.WriteLine("Enter the Search element\n");

            string s = Console.ReadLine();
            int x = Int32.Parse(s);

            for (int i = 0; i < 10; i++)
            {
                if (a[i] == x)
                {
                    Console.WriteLine("-------------------------");
                    Console.WriteLine("Search successful");
                    Console.WriteLine("Item {0} found at location {1}\n", x, i + 1);
                    //return;
                    Console.ReadLine();
                }
            }
            Console.WriteLine("Entered item not found. Search unsuccessful");
            Console.ReadLine();
        }
    }
}
