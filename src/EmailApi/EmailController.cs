using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace EmailApi
{
    public class EmailController : Controller
    {
        private readonly Settings _settings;

        public EmailController(IOptions<Settings> config)
        {
            _settings = config.Value;
        }

        [Route("api/email")]
        [HttpPost]
        public IActionResult Post([FromBody] Email email)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    client.Port = _settings.Port;
                    client.Host = _settings.Host;
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(_settings.User, _settings.Password);

                    var mailMessage = new MailMessage(_settings.User, email.ToEmailAddress, email.Subject, email.Body)
                    {
                        BodyEncoding = Encoding.UTF8,
                        DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure,
                        IsBodyHtml = true,
                    };

                    if (email.CC.Any())
                    {
                        mailMessage.CC.Add(email.CC.Aggregate((x, y) => $"{x.Trim()},{y.Trim()}"));
                    }

                    client.Send(mailMessage);
                }
                return this.Ok("Email sent");
            } 
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
