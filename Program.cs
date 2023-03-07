using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlolnOverloading
{
    class Program
    {
       
            static void Main(string[] args)
            {
                Console.WriteLine(Add(10, 12));
                Console.WriteLine(Add(1.5, 2.9));
            }
            //complete the method to sum
            static int Add(int a,int b)
            {
            int sum = a + b;
            return sum;
            }
            //overload it for double type
            static double Add(double a,double b)
            {
              double sum = a + b;
              return sum;
            }
        
    }
}
