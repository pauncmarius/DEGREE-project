using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface IOpenAiChatService
    {
        Task<string> GetChatGptReplyAsync(string prompt);
    }
}
