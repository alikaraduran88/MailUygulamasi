using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Models.Models;

namespace WebApplication.Models.Data
{
    public class DBContext :DbContext
    {
        public DBContext()
        {
            Database.Connection.ConnectionString = "server=.;database=MailDB;Trusted_Connection=true";
        }
        //DbSet<SmsConfiguration> SmsConfigurations { get; set; }

        public System.Data.Entity.DbSet<WebApplication.Models.Models.SmsConfiguration> SmsConfigurations { get; set; }
    }
}