using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(WCFCHAT.Service1)))
            {
                host.Open();
                Console.WriteLine("hello Piter");
                Console.ReadLine();
            }
        }
    }
}
