using System.Collections.Generic;
using System.Threading.Tasks;
using Shortener.Api.Dtos;

namespace Shortener.Api.Services
{
    public interface IShorteningService
    {
        Task<IEnumerable<LinkDto>> GetShortLinksAsync();

        Task<string> ProcessLinkAsync(string url);
    }
}