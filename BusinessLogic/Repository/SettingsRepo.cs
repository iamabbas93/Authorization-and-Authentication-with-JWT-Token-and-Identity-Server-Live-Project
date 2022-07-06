using BusinessLogic.Interface;
using DataAccess.Models.VM;
using IKonnect_LiveCare.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    class SettingsRepo : ISettings
    {
        private readonly IConfiguration _configuration;
        

        public SettingsRepo(IConfiguration configuration )
        {
            _configuration = configuration;
          

        }


        public async Task<AuthTokenVM> getAuthTokenLC()
        {
            AuthTokenVM auth = new AuthTokenVM();
            var baseURL = _configuration["LiveCareBaseURL"];
            var clientKey = _configuration["LiveCareClientKey"];
            var accessCode = _configuration["LiveCareAccessCode"];


            var client = new RestClient(baseURL);
           
            var request = new RestRequest("api/"+ clientKey + "/auth",Method.Post);
            request.AddHeader("accesscode", accessCode);
           
            RestResponse response =await client.ExecuteAsync(request);
            auth = JsonConvert.DeserializeObject<AuthTokenVM>(response.Content);
            Console.WriteLine(response.Content);

            return auth;


        }

        public async Task<string> SendEmail(string host,int port,string username,string password,string from, string to, string subject, string html)
        {
            try
            {
             
               
                    var email = new MimeMessage();
                    email.From.Add(MailboxAddress.Parse(from));
                    email.To.Add(MailboxAddress.Parse(to));
                    email.Subject = subject;
                    email.Body = new TextPart(TextFormat.Html) { Text = html };





                    // send email
                    var smtp = new MailKit.Net.Smtp.SmtpClient();
                   await smtp.ConnectAsync(host, port, SecureSocketOptions.StartTls);
                   await smtp.AuthenticateAsync(username, password);
                   await smtp.SendAsync(email);
                   await smtp.DisconnectAsync(true);


           


                return "Email Send Sucessfully";

                
              

            }
            catch (Exception ex)
            {

                return "Email Not Sending.";
            }
        }
    
   
    
    }
}
