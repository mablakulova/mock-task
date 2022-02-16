namespace Shortener.Api
{
    public class LinkDto
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string ShortUrl { get; set; }
    }
}
