using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Models
{
    public class SmsConfiguration
    {
        public int SmsConfigurationID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string HavuzAdi { get; set; }
        public string Prefix { get; set; }

    }
}