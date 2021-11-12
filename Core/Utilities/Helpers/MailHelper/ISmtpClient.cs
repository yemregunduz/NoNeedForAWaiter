using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.MailHelper
{
    public interface ISmtpClient : IDisposable
    {
        X509CertificateCollection ClientCertificates { get; }
        ICredentialsByHost Credentials { get; set; }
        SmtpDeliveryFormat DeliveryFormat { get; set; }
        SmtpDeliveryMethod DeliveryMethod { get; set; }
        bool EnableSsl { get; set; }
        string Host { get; set; }
        string PickupDirectoryLocation { get; set; }
        int Port { get; set; }
        ServicePoint ServicePoint { get; }
        string TargetName { get; set; }
        int Timeout { get; set; }
        bool UseDefaultCredentials { get; set; }

        event SendCompletedEventHandler SendCompleted;

        void Send(MailMessage message);
        void Send(string from, string recipients, string subject, string body);
        void SendAsync(MailMessage message, object userToken);
        void SendAsync(string from, string recipients, string subject, string body, object userToken);
        void SendAsyncCancel();
        Task SendMailAsync(MailMessage message);
        Task SendMailAsync(string from, string recipients, string subject, string body);
    }
}
