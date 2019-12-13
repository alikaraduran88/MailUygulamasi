using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using WebApplication.Models.Data;
using WebApplication.Models.Models;

namespace WebApplication.Business
{
    public class SendMail
    {
        MailMessage mail = new MailMessage();

        public void SendMails(List<string> email, string icerik,string MesajKonusu)
        {
            List<SmsConfiguration> SendMaill = new List<SmsConfiguration>();

          /* for (int i = 0; i <= email.Count - 1; i++)
            {
                SendMaill.AddRange(MailManager.GetHavuzName(email[i]));
            }*/

            for (int i = 0; i <= email.Count - 1; i++)
            {

                try
                {
                    using (DBContext db = new DBContext())
                    {
                      //  var list = db.SmsConfigurations.Select(m => m.Email).Distinct().ToList();
                        mail.IsBodyHtml = true; //mail içeriğinde html etiketleri kullanılsın mı?
                        mail.To.Add(email[i]); //Kime mail gönderilecek.

                        //mail kimden geliyor, hangi ifade görünsün?
                        mail.From = new MailAddress("karaduranuniversitesi@gmail.com", "deneme", System.Text.Encoding.UTF8);
                        mail.Subject = MesajKonusu;//mailin konusu

                        //mailin içeriği.. Bu alan isteğe göre genişletilip daraltılabilir.
                        mail.Body = icerik;
                        mail.IsBodyHtml = true;
                        SmtpClient smp = new SmtpClient();

                        //mailin gönderileceği adres ve şifresi
                        smp.Credentials = new NetworkCredential("karaduranuniversitesi@gmail.com", "alikaraduran");
                        smp.Port = 587;
                        smp.Host = "smtp.gmail.com";//gmail üzerinden gönderiliyor.
                        smp.EnableSsl = true;
                        smp.Send(mail);//mail isimli mail gönderiliyor.
                    }       
                }
                catch (Exception)
                {

                }
            }
            }

       
        }
    }
