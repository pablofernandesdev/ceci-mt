﻿using CeciMT.Domain.DTO.Commons;
using CeciMT.Domain.DTO.Email;
using CeciMT.Domain.Interfaces.Service;
using CeciMT.Infra.CrossCutting.Settings;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CeciMT.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<ResultResponse> SendEmailAsync(EmailRequestDTO emailRequest)
        {
            var response = new ResultResponse();

            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress(_emailSettings.Mail, _emailSettings.DisplayName);
                message.To.Add(new MailAddress(emailRequest.ToEmail));
                message.Subject = emailRequest.Subject;

                if (emailRequest.Attachments != null)
                {
                    foreach (var file in emailRequest.Attachments)
                    {
                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                var fileBytes = ms.ToArray();
                                Attachment att = new Attachment(new MemoryStream(fileBytes), file.FileName);
                                message.Attachments.Add(att);
                            }
                        }
                    }
                }

                message.IsBodyHtml = false;
                message.Body = emailRequest.Body;
                smtp.Port = _emailSettings.Port;
                smtp.Host = _emailSettings.Host;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_emailSettings.Mail, _emailSettings.Password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                await smtp.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                response.Message = "It was not possible to send the email.";
                response.Exception = ex;
            }

            return response;
        }
    }
}
