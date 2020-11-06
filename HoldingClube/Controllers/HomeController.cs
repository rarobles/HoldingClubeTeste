using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoldingClube.Models;
using HoldingClube.Models.ViewModels;
using System.Net.Mail;

namespace HoldingClube.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult MailMessage()
        {
            string name         = Request.Form["Name"];
            string email        = Request.Form["Email"];
            string phone        = Request.Form["Phone"];
            string organization = Request.Form["Organization"];
            string message      = Request.Form["Message"];

            SendMail(name, email, phone, organization, message);

            return RedirectToAction(nameof(Contact));
        }

        public void SendMail(string name, string email, string phone, string organization, string message)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient
            {
                Host        = "smtp.gmail.com",
                Port        = Convert.ToInt32("587"),
                EnableSsl   = true,
                Credentials = new System.Net.NetworkCredential("robles.holdingclube@gmail.com", "@HoldingClube")
            };

            MailMessage mail = new MailMessage
            {
                Sender = new System.Net.Mail.MailAddress("robles.holdingclube@gmail.com", "All In 2020 - Holding Clube"),
                From   = new MailAddress("robles.holdingclube@gmail.com", "All In 2020 - Holding Clube")
            };

            mail.To.Add(new MailAddress(email, name));
            mail.Subject    = "Contato";
            mail.Body       = "<br /> Mensagem de contato <br /> <br /> Nome: " + name.ToUpper().ToString() + "<br /> E-mail: " + email.ToUpper().ToString() + "<br /> " + "Telefone: " + phone.ToString() + "<br /> Organização: " + organization.ToUpper().ToString() + "<br /> Mensagem: " + message.ToString() + "<br /> ";
            mail.IsBodyHtml = true;
            mail.Priority   = MailPriority.High;

            try
            {
                client.Send(mail);
            }
            catch (System.Exception e)
            {
                new Exception(e.Message);
            }
            finally
            {
                //mail = null;
            }

        }
    }
}
