using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace iltest
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataWait = Console.ReadLine();
            WR(dataWait);

            Console.ReadLine();
        }

        public static void WR(string data)
        {
            Console.WriteLine(data);
        }
    }
}
