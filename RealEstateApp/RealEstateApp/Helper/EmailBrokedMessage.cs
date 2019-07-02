using System;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace RealEstateApp.Helper
{
    public class EmailBrokedMessage
    {

        public static async Task SendAsync(string msg)
        {
            try
            {

                const string connectionString = "Endpoint=sb://realestateservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=quq1EKQU+u7+0SFEUuzy9i+tHgHELf8Yf/W5z8C5KeI=";
                const string queueName = "email";
                var _client = QueueClient.CreateFromConnectionString(connectionString, queueName);
                string Message = msg;
                BrokeredMessage message = new BrokeredMessage(Message);
                await _client.SendAsync(message);
            }
            catch(Exception ex)
            {
                //log
            }

        }
    }
}