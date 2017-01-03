using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Runtime.Caching;
using System.Web.Caching;
using newSiteMVC.Models;
using reCAPTCHA.MVC;


namespace newSiteMVC.Controllers
{
    public class HelperController : Controller
    {

        private static StoreDB db = new StoreDB();

        [HttpPost, ActionName("ContactFormSendEmail")]
        [CaptchaValidator]
        public ActionResult ContactFormSendEmail(bool captchaValid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage mailMessage = SetMailMessageDetails();
                    SmtpClient smtp = SetSmtpClientDetails();

                    smtp.Send(mailMessage);

                    SetEmailCookie("success");
                                   
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);

                    SetEmailCookie("fail");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Wrong captcha. Please try again.");
                return Redirect("/Page/ContactUs");

            }
            ModelState.Clear();
            return Redirect("/Page/ContactUs");
        }

        private MailMessage SetMailMessageDetails()
        {
            string firstname = Request.Form["firstname"].ToString();
            string lastname = Request.Form["lastname"].ToString();
            string email = Request.Form["email"].ToString();
            string company = Request.Form["company"].ToString();
            string country = Request.Form["country"].ToString();
            string messageBody = Request.Form["message"].ToString();

            MailMessage message = new MailMessage();
                        message.From = new MailAddress("contactus@iccsolutions.com");
                        message.IsBodyHtml = true;
                        message.To.Add("info@iccsolutions.com");
                        message.Subject = "ICC Solutions - Customer's Enquiry";

                        message.Body = "<p>First Name:" + " " + firstname + "</p>" + "<p>Last Name:" + " " + lastname + "</p>" +
                                    "<p>Email:" + " " + email + "</p>" + "<p>Company:" + " " + company + "</p>"+ " <p>Country:" + " " + country + " </p><br>" +
                                    "<p>Message:" + " " + messageBody + "</p>";

            return message;
        }

        private SmtpClient SetSmtpClientDetails()
        {
             SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.office365.com";
                        smtp.Port = 587;
                        smtp.Credentials = new System.Net.NetworkCredential
                        ("contactus@iccsolutions.com", "Abcd1234!");
                        smtp.EnableSsl = true;

            return smtp;
        }

        private void SetEmailCookie(string state)
        {
            var userCookie = new HttpCookie("emailSent", state);

            userCookie.Expires = DateTime.Now.AddSeconds(10.0);

            HttpContext.Response.Cookies.Add(userCookie);
        }     
    }
}