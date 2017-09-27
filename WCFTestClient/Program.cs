using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var myService = new BilletSystemReference.BilletSystemService();
            double rabat = 0;
            bool success = false;
            myService.GetBilRabatBro(out rabat, out success);
            Console.WriteLine(rabat);

            Console.WriteLine(myService.GetMCBro());
        }
    }
}
