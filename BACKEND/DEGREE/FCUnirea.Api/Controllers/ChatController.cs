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

    [Authorize]
    [HttpPost("ask")]
    public async Task<ActionResult<ChatResponse>> Ask([FromBody] ChatRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ChatResponse { Reply = "Mesajul nu poate fi gol." });

        // preia username-ul utilizatorului autentificat din token
        var username = User.Identity?.Name;
        if (string.IsNullOrEmpty(username))
            return Unauthorized(new ChatResponse { Reply = "Utilizatorul nu este autentificat." });

        var reply = await _chatService.GetReplySmartAsync(request.Message, username);
        if (string.IsNullOrEmpty(reply))
            return BadRequest(new ChatResponse { Reply = "Nu am putut genera un răspuns." });

        return Ok(new ChatResponse { Reply = reply });
    }
}

