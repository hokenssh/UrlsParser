using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using UrlsParser.UrlsExtracters;

namespace UrlsParser.Controllers;

[ApiController]
[Route("api/v1")]
public class UrlsController : ControllerBase
{
    private readonly IUrlsExtracter urlsExtracter;

    public UrlsController(IUrlsExtracter urlsExtracter)
    {
        this.urlsExtracter = urlsExtracter;
    }

    [HttpPost("ExtracUrls")]
    [Consumes("text/plain")]
    [Produces("application/json")]
    public List<string> ExtracUrls([FromBody] string body)
    {
        return this.urlsExtracter.ExtractUrls(body);
    }
}