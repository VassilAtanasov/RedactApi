using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RedactApi.Services;

namespace RedactApi.Controllers;


[ApiController]
[Route("[controller]")]
public class RedactionController : ControllerBase
{
    private readonly RedactionService _redactionService;
    private readonly ILogger<RedactionController> _logger;

    public RedactionController(RedactionService redactionService, ILogger<RedactionController> logger)
    {
        _redactionService = redactionService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Redaction Service");
    }

    [HttpPost]
    public IActionResult Post([FromBody] string input)
    {
        var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _logger.LogInformation($"[{timestamp}] Received text: {input}");
        var redactedText = _redactionService.RedactText(input);
        return Ok(redactedText);
    }
}
