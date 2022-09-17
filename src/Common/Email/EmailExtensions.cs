using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Email
{
    public static class EmailExtensions
    {
        public static void AddEmailConfig(this IServiceCollection services, IConfiguration config)
        {
            var emailoptions = config.GetOptionalValue<SmtpOptions>("Email:smtp");
            services.TryAddSingleton(emailoptions);
            services.TryAddSingleton<IEmailSender, SmtpEmailSender>();
        }
    }
}
