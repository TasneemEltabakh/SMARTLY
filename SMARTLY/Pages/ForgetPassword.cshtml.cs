using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMARTLY.Pages.Models;
using System.Data;
using System.Net.Mail;


namespace SMARTLY.Pages
{
    public class ForgetPasswordModel : UserPageModel
    {
        private readonly Database database;

        public DataTable dt { get; set; }
        [BindProperty]
        public Client user { get; set; }
        public string message { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool state { get; set; }
        public int val { get; set; }
        public int Type { get; set; }
        public ForgetPasswordModel(Database db)
        {
            this.database = db;

        }
        public void OnGet()
        {
            message = "free";
            dt= database.ReadClient(UserName);
            Type = 0;
        }
     

        public void SendEmail(string recipient, string subject, string body)
        {
            // Set the sender's email address and credentials
            string senderEmail = "email";
            string senderPassword = "pass";
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            bool enableSsl = true;

            // Create a new MailMessage object
            MailMessage message = new MailMessage(senderEmail, recipient, subject, body);

            // Set the message body format to HTML
            message.IsBodyHtml = true;

            // Create a new SmtpClient object and set its properties
            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.EnableSsl = enableSsl;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential(senderEmail, senderPassword);

            // Send the email
            smtpClient.Send(message);
        }
    public IActionResult OnPost()
        {
            if (!database.checkForgotten(user.email))
            {
                message = "Your email isn't register";
                return Page();
            }
            else
            {
                //SendEmail(user.email, "Smartly Password","this is the body");

                return RedirectToPage("/LogIn", message= "An email has been sent to you.");
                  
                
            }


        }
    }
}
