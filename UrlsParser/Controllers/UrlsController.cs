using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using UrlsParser.Helpers;

namespace UrlsParser.Controllers;

[ApiController]
[Route("[controller]")]
public class UrlsController : ControllerBase
{
    private readonly IUrlsExtracter _urlsExtracter;

    public UrlsController(IUrlsExtracter urlsExtracter)
    {
        _urlsExtracter = urlsExtracter;
    }

    [HttpPost("ExtracUrls")]
    [Consumes("text/plain")]
    [Produces("application/json")]
    public List<string> ExtracUrls([FromBody] string body)
    {
        return _urlsExtracter.ExtractUrls(body);
    }
}