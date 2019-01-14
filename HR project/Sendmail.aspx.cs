﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;  
namespace HR_project
{
    public partial class Sendmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendMail()
        {
            // Gmail Address from where you send the mail
            var fromAddress = "anynomys890@gmail.com";
            // any address where the email will be sending
            var toAddress = YourEmail.Text.ToString();
            //Password of your gmail address
            const string fromPassword = "omarzaki133";
            // Passing the values and make a email formate to display
            string subject = YourSubject.Text.ToString();
            string body = "From: " + YourName.Text + "\n";
            //body += "Email: " + YourEmail.Text + "\n";
            //body += "Subject: " + YourSubject.Text + "\n";
            body +=  Comments.Text + "\n";
            //"Question: \n" +
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //here on button click what will done 
                SendMail();
                DisplayMessage.Text = "Email has been successfully sent.";
                DisplayMessage.Visible = true;
                YourSubject.Text = "";
                YourEmail.Text = "";
                YourName.Text = "Manager";
                Comments.Text = "";
            }
            catch (Exception) { }
        }
    }
}