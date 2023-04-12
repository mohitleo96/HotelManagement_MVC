using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Models;
using System.Net.Mail;
using System.Net;



namespace HotelManagement.Controllers
{
    public class SMTPController : Controller
    {
        //GET: EmailSetup
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HotelManagement.Models.SMTP model)
        {
            MailMessage mm = new MailMessage("guestreservationnotification@gmail.com", model.To);
            mm.Subject = "Welcome to Royal Grand Hotel";
            mm.Body = "Your Room ID is Booked Successfully" +
                "Have a Nice Stay.";
            mm.IsBodyHtml = false;



            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            NetworkCredential nc = new NetworkCredential("guestreservationnotification@gmail.com", "miqxnurgwkwdqyir");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);



            ViewBag.Message = "Mail has been send Successfully";
            return View();
        }
    }
}

