// Controllers/ChatController.cs
using FCUnirea.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly OpenAiChatService _chatService;

    public ChatController(OpenAiChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpPost("ask")]
    public async Task<ActionResult<ChatResponse>> Ask([FromBody] ChatRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Message))
            return BadRequest(new ChatResponse { Reply = "Mesajul nu poate fi gol." });

        var prompt = $"Esti asistentul virtual FC Unirea. Raspunde la intrebari legate de bilete, meciuri, profil etc. Intrebarea utilizatorului: \"{request.Message}\"";
        var reply = await _chatService.GetChatGptReplyAsync(prompt);

        return Ok(new ChatResponse { Reply = reply });
    }
}
