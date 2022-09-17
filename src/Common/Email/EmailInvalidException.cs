using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Email
{
    public class EmailInvalidException: Exception
    {
        public EmailInvalidException(string message): base(message)
        {

        }
    }
}
