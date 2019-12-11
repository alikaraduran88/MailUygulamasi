using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.ModelVM;

namespace WebApplication.Business
{
    public class AddMailList
    {
        public List<string> ChooiceChechBox = new List<string>();
        public AddMailList(string email)
        {
            ChooiceChechBox.Add(email);
        }

        
    }
    
}