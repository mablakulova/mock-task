using System.Collections.Generic;

namespace Shortener.Api
{
    public interface IShorteningService
    {
        IEnumerable<LinkDto> GetShortLinks();
        string ProcessLink(string url);
    }
}