using DocumentoService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace DocumentoHostConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string qName = ConfigurationSettings.AppSettings["queueName"];
            //string qName = ConfigurationManager.AppSettings["ColaDocumento"];
            if (!MessageQueue.Exists(qName))
            {
                MessageQueue.Create(qName, true);
            }
            using (ServiceHost host = new ServiceHost(typeof(DocService)))
            {
                host.Open();
                Console.WriteLine("Servicio Listo...");
                Console.ReadLine();
            }
        }
    }
}
