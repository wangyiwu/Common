using MailKit.Net.Smtp;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Email
{
    public sealed class SmtpEmailSender : IEmailSender
    {
        private readonly SmtpOptions options;
        private readonly ObjectPool<SmtpClient> clientPool;

        public SmtpEmailSender(IOptions<SmtpOptions> options)
        {
            this.options = options.Value;

            clientPool = new DefaultObjectPoolProvider().Create(new DefaultPooledObjectPolicy<SmtpClient>());
        }

        public async Task SendAsync(string recipient, string subject, string body,
            CancellationToken ct = default)
        {
            var smtpClient = clientPool.Get();
            try
            {
                using (var timeout = new CancellationTokenSource(options.Timeout))
                {
                    using (var combined = CancellationTokenSource.CreateLinkedTokenSource(ct, timeout.Token))
                    {
                        await EnsureConnectedAsync(smtpClient, combined.Token);

                        var smtpMessage = new MimeMessage();

                        smtpMessage.From.Add(MailboxAddress.Parse(
                            options.Sender));

                        smtpMessage.To.Add(MailboxAddress.Parse(
                            recipient));

                        smtpMessage.Body = new TextPart(TextFormat.Html)
                        {
                            Text = body
                        };

                        smtpMessage.Subject = subject;

                        await smtpClient.SendAsync(smtpMessage, ct);

                    }
                }
            }
            catch (Exception e)
            {
                throw new EmailInvalidException("Send email not success!");
            }
            finally
            {
                clientPool.Return(smtpClient);
            }
        }

        private async Task EnsureConnectedAsync(SmtpClient smtpClient,
            CancellationToken ct)
        {
            if (!smtpClient.IsConnected)
            {
                await smtpClient.ConnectAsync(options.Server, options.Port, cancellationToken: ct);
            }

            if (!smtpClient.IsAuthenticated)
            {
                await smtpClient.AuthenticateAsync(options.Username, options.Password, ct);
            }
        }
    }
}
