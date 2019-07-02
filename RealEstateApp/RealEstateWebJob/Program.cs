using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace RealEstateWebJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        private static string _servicesBusConnectionString;
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {

            _servicesBusConnectionString = AmbientConnectionStringProvider.Instance.GetConnectionString(ConnectionStringNames.ServiceBus);

            var config = new JobHostConfiguration();
            try
            {
                if (config.IsDevelopment)
                {
                    config.UseDevelopmentSettings();
                }

                ServiceBusConfiguration serviceBusConfig = new ServiceBusConfiguration
                {
                    ConnectionString = _servicesBusConnectionString
                };
                config.UseServiceBus(serviceBusConfig);

                var host = new JobHost(config);
                // The following code ensures that the WebJob will be running continuously
                host.RunAndBlock();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            ///Get message from queue
           
            Console.WriteLine("from webjob");
        }
    }
}
