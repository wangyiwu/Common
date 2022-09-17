using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Email
{
    public sealed class SmtpOptions
    {
        public string Server { get; set; }

        public string Sender { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool EnableSsl { get; set; }

        public int Timeout { get; set; } = 5000;

        public int Port { get; set; } = 587;

        public bool IsConfigured()
        {
            return
                !string.IsNullOrWhiteSpace(Server) &&
                !string.IsNullOrWhiteSpace(Sender) &&
                !string.IsNullOrWhiteSpace(Username) &&
                !string.IsNullOrWhiteSpace(Password);
        }
    }
}
