using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication.Models;
using WebApplication.Models.Data;
using WebApplication.Models.Models;
using WebApplication.Models.ModelVM;

namespace WebApplication.Business
{
    public class MailManager
    {
        static List<string> liste = new List<string>();
        public static List<SmsConfiguration> CreateMailManager()
        {
            using (DBContext db = new DBContext())
            {
              return  db.SmsConfigurations.ToList();
            }
        }


        public static List<SmsConfiguration> GetPrefix(List<string> chkData)
        {
            List<SmsConfiguration> smsList = new List<SmsConfiguration>();
            using (DBContext db = new DBContext())
            {
                foreach (var item in chkData)
                {
                    var list1 = db.SmsConfigurations.Where(q => q.Prefix == item).ToList();
                    smsList.AddRange(list1);
                }
                return db.SmsConfigurations.ToList();
            }
        }

        public static List<SmsConfiguration> GetEmailByHavuzName(string HavuzName)
        {
            using (DBContext db = new DBContext())
            {
                //db.SmsConfigurations.Select(m => m.Prefix).Distinct().ToList();
                return db.SmsConfigurations.Where(q => q.HavuzAdi == HavuzName).ToList();
            }
        }
        public static List<SmsConfiguration> GetHavuzName(string chkData)
        {
                using (DBContext db = new DBContext())
                {
                return db.SmsConfigurations.Where(q => q.HavuzAdi == chkData).ToList();
                }
        }

        public static List<SmsConfiguration> GetHavuzName1(List<string> chkData)
        {
            List<SmsConfiguration> smsList = new List<SmsConfiguration>();
            using (DBContext db = new DBContext())
            {
                foreach (var item in chkData)
                {
                    var list1 = db.SmsConfigurations.Where(q => q.HavuzAdi == item).ToList();
                    smsList.AddRange(list1);
                }
                return smsList;
            }
        }
    }
}