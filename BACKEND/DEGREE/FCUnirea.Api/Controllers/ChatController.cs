// ChatController.cs
using FCUnirea.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


[Authorize]
[ApiController]
[Route("api/chat")]
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

        var username = User.Identity?.Name;

        var reply = await _chatService.GetReplySmartAsync(request.Message, username);

        return Ok(new ChatResponse { Reply = reply });
    }
}

