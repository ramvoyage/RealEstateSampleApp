using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Model;
using Microsoft.Azure.WebJobs;
using Microsoft.ServiceBus.Messaging;

namespace RealEstateWebJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.

        private RealEstateAppContext dbcontext;
        public static void ProcessQueueMessage([ServiceBusTrigger("email")] BrokeredMessage message,TextWriter logger)
        {
            var brokeredmessage = message.GetBody<string>();
            logger.WriteLine(brokeredmessage);


            SendEmailToUser(brokeredmessage);

            message.Complete();
        }

        private static void SendEmailToUser(string message)
        {
            List<User> users;
            using (var dbcontext = new RealEstateAppContext())
            {
                users = dbcontext.Users.Where(u => u.Active).ToList();
                foreach (var user in users)
                {
                    SendEmail(user.EmailAddress,message);

                }
            };

        }

        private static void SendEmail(string recievermailAddress,string message)
        {
            try
            {

                string receiver = "babukondaram@gmail.com";
                string subject = "from SMTP";
                string senderEmailId = "rambabu2k4@gmail.com";


                var senderEmail = new MailAddress(senderEmailId, "gmail");
                var receiverEmail = new MailAddress(recievermailAddress, "Receiver");
                var password = "rambabu@1990";
                var sub = subject;
                var body = message;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };

                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(mess);
                }

            }
            catch (Exception ex)
            {

            }
        }

        public static void GetMessage()
        {
            const string connectionString = "Endpoint=sb://realestateservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=quq1EKQU+u7+0SFEUuzy9i+tHgHELf8Yf/W5z8C5KeI=";
            const string queueName = "email";
            var queueClient = QueueClient.CreateFromConnectionString(connectionString, queueName);
            BrokeredMessage message = queueClient.Receive();
            string body = message.GetBody<string>();
            message.Complete();
            message.Abandon();
            Console.WriteLine(body);
            Console.ReadLine();

        }
    }
}
