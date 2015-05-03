using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MantenimientoHostConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Type mantenimientoType = typeof(MantenimientoService.ManService);
            using (ServiceHost host = new ServiceHost(mantenimientoType))
            {
                host.Open();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Servicio Mantenimiento Online");
                Console.ReadLine();
                //host.Close()
            }
        }
    }
}
