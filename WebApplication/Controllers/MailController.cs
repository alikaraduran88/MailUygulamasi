using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Business;
using WebApplication.Models;
using WebApplication.Models.Data;
using WebApplication.Models.Models;

namespace WebApplication.Controllers
{
    public class MailController : Controller
    {
        public ActionResult Index()
        {
            List<SmsConfiguration> SendMail = MailManager.CreateMailManager();
            return View(SendMail);
        }

        public ActionResult Prefix()
        {
            PrefixVM prefix = new PrefixVM();
            using (DBContext db = new DBContext())
            {
                var list = db.SmsConfigurations.Select(m => m.Prefix).Distinct().ToList();
               
                return View();
            }           
        }

        [HttpPost]
        public ActionResult SmsGonder(List<string> chkData)
        {
            return View();
        }

        public ActionResult SendSMS(List<string> chkData)
        {
            return View();
        }

        public ActionResult HomePage()
        {
            return View();
        }


        public ActionResult WebPage()
        {
            return View();
        }
    }
}