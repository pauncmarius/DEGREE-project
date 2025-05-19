//EmailService
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Email;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
// de schimbat
public class EmailService : IEmailService
{
    private readonly EmailSettings _settings;

    public EmailService(IOptions<EmailSettings> settings)
    {
        _settings = settings.Value;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        // creeaza un mesaj de email nou
        var message = new MailMessage();
        message.From = new MailAddress(_settings.SenderEmail, _settings.SenderName); // adresa si numele expeditorului
        message.To.Add(new MailAddress(toEmail));                                     // adauga destinatarul
        message.Subject = subject;                                                    // subiectul emailului
        message.Body = body;                                                          // continutul emailului
        message.IsBodyHtml = true;                                                    // specifica daca body-ul este HTML

        // creeaza clientul SMTP folosind serverul si portul din setari
        using var client = new SmtpClient(_settings.SmtpServer, _settings.Port)
        {
            Credentials = new NetworkCredential(_settings.Username, _settings.Password), // user si parola pentru autentificare
            EnableSsl = true                                                            // foloseste conexiune securizata
        };

        // trimite emailul in mod asincron
        await client.SendMailAsync(message);
    }

}
