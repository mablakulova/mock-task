using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shortener.Api.Services;

namespace Shortener.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : ControllerBase
    {
        private readonly IShorteningService service;

        public LinksController(IShorteningService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<string> GetShortLink(string url)
        {
            return await service.ProcessLinkAsync(url);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetShortLinks()
        {
            var linkDtos = await service.GetShortLinksAsync();

            return Ok(linkDtos);
        }
    }
}
