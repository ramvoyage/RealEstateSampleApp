using RealEstateApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace RealEstateApp.Controllers
{
    public class EmialNotificationController : Controller
    {
        // GET: EmialNotification
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmialNotification/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmialNotification/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmialNotification/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            try
            {
                RealEstate tempmsg;

                string message = "";
                if (TempData["modifieddata"] != null)
                {
                    tempmsg = TempData["modifieddata"] as RealEstate;
                    message = $"modified price, {tempmsg.price}! area is {tempmsg.area}";
                }
                string receiver = "babukondaram@gmail.com";
                string subject = "from SMTP";
                string senderEmailId = "rambabu2k4@gmail.com";

                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress(senderEmailId, "gmail");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
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
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
    
        




    }
}
