using PluralSightBook.Core.Interfaces;
using System.Diagnostics;

namespace PluralSightBook.Infrastructure.Services
{
    public class DebugEmailSender : ISendEmail
    {
        public void SendEmail(string message)
        {
            // send email
            Debug.Print("Sending Email: " + message);
        }
    }
}
