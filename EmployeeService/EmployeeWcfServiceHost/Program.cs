using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace EmployeeWcfServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //to host a WCF Service we must first add Reference to the Service project
            //and to the library System.ServiceModel 
            using(ServiceHost host = new ServiceHost(typeof(EmployeeWcfService.EmployeeWcfService)))
            {
                host.Open(); // open the host
                Console.WriteLine("Host started at " + DateTime.Now.ToString());
                Console.ReadLine();

            }
        }
    }
}
