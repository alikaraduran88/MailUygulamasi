using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Business;
using WebApplication.Models;
using WebApplication.Models.Data;
using WebApplication.Models.Models;
using WebApplication.Models.ModelVM;

namespace WebApplication.Controllers
{
    public class homeController : Controller
    {
       public List<string> ChooiceChechBox1 = new List<string>();
        
        List<string> ChooiceChechBox = null;
        List<GetHavuzName> _GetHavuzName = new List<GetHavuzName>();

        // GET: home
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Prefix()
        {
            //List<SmsConfiguration> SendMail = MailManager.GetPrefix();
            /*var list= SendMail.Select(m => m.Prefix).Distinct().ToList();
           
            ViewData["A"] = list[0];
            ViewData["B"] = list[1];
            ViewData["C"] = list[2];*/
            return View();
        }

        public ActionResult HavuzName()
        {
           
            List<SmsConfiguration> SendMail = MailManager.CreateMailManager();
            var list= SendMail.Select(m => m.HavuzAdi).Distinct().ToList();
            ViewBag.Liste = list;
             
            return View();

        }

        public ActionResult AllCustomer()
        {
            List<SmsConfiguration> SendMail = MailManager.CreateMailManager();
            List<SmsConfiguration> SendMail1 = MailManager.AllCustomerManager();
            var list = SendMail1.ToList();
            ViewBag.Liste = list;
            return View(SendMail);
            
        }
        public ActionResult Prefixx(PrefixVM prefix)
        {
            using (DBContext db = new DBContext())
            {
                var list = db.SmsConfigurations.Select(m => m.Prefix).Distinct().ToList();
            }
            return View();

        }
       
        public ActionResult SmsGonder(string data)
        {      
            return View();
        }

        [HttpPost]
        public ActionResult SMSEkrani(List<string> chkData, string mesaj, string MesajKonusu)
        {
            
            SendMail sendmails = new SendMail();
           
                sendmails.SendMails(chkData, mesaj, MesajKonusu);
           
             return View();
        }

        [HttpPost]
        public ActionResult HavuzEkrani(List<string> chkData, string mesaj, string MesajKonusu)
        {
            SendMail sendmails = new SendMail();

            sendmails.SendMails(chkData, mesaj, MesajKonusu);

            return View();
        }

        [HttpPost]
        public ActionResult PrefixSMSEkrani(List<string> chkData, string mesaj, string MesajKonusu)
        {
            List<SmsConfiguration> smsList = new List<SmsConfiguration>();
            using (DBContext db = new DBContext())
            {
                foreach (var item in chkData)
                {
                    var list1 = db.SmsConfigurations.Where(q => q.Prefix == item).ToList();
                    smsList.AddRange(list1);
                }
                
            }
            SendMail sendMAil = new SendMail();
           //sendMAil.SendMails(smsList, mesaj,MesajKonusu);
            return View();
        }


        [HttpPost]
        public ActionResult GetValuesEmailsByHavuzName(List<string> chkData)
        {
            List<SmsConfiguration> SendMail = MailManager.GetHavuzName1(chkData);
            var list = SendMail.Select(m => new { m.Email }).Distinct().ToList();
            ViewBag.Liste = list.Select(m => m.Email).Distinct().ToList();
            return View();
        }
        
       

        [HttpPost]
        public ActionResult GetAllCustomer(int pageNumber)
        {
            List<SmsConfiguration> SendMail = MailManager.getCustomerWithPageNumberManager(pageNumber);
            var list = SendMail.ToList();
            ViewBag.Liste = list;
            return View();
        }


        [HttpPost]
        public ActionResult AddMail(string chkData, string email)
        {
            _GetHavuzName.Add(new GetHavuzName() { Email = email });
            return View();
        }

       
        [HttpPost]
        public ActionResult AddMailList(List<string> chkData)
        {
            ChooiceChechBox.AddRange(chkData);
            return View();
        }

        [HttpPost]
        public ActionResult SendToEmail(string Konu,String mesaj)
        {
            SendMail send = new SendMail();
            send.SendMails(ChooiceChechBox,Konu,mesaj);
            return View();
        }
    }
}