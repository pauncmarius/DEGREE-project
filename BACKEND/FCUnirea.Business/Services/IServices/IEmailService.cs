
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
