using System.Threading;
using System.Threading.Tasks;

namespace Common.Email
{
    public interface IEmailSender
    {
        Task SendAsync(string recipient, string subject, string body,
            CancellationToken ct = default);
    }
}
