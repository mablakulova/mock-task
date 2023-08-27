using AutoMapper;
using DAL.Entities;
using DAL.Repository;
using Microsoft.Extensions.Logging;
using Shortener.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shortener.Api.Services
{
    public class ShorteningService : IShorteningService
    {
        private readonly IRepository<LinkEntity> linksRepository;
        private readonly ILogger<ShorteningService> logger;
        private readonly IMapper mapper;

        public ShorteningService(
            IRepository<LinkEntity> linksRepository,
            ILogger<ShorteningService> logger,
            IMapper mapper)
        {
            this.linksRepository = linksRepository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<string> ProcessLinkAsync(string url)
        {
            logger.LogInformation("Processing link: {Url}", url);

            var entity = (await linksRepository.GetAllAsync()).Where(x => x.Url == url).FirstOrDefault();
            if (entity == null)
            {
                Thread.Sleep(1);//make everything unique while looping
                long ticks = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds;//EPOCH
                char[] baseChars = new char[] { '0','1','2','3','4','5','6','7','8','9',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x'};

                int i = 32;
                char[] buffer = new char[i];
                int targetBase = baseChars.Length;

                do
                {
                    buffer[--i] = baseChars[ticks % targetBase];
                    ticks = ticks / targetBase;
                }
                while (ticks > 0);

                char[] result = new char[32 - i];
                Array.Copy(buffer, i, result, 0, 32 - i);

                var shortUrl = new string(result);

                var link = new LinkEntity
                {
                    ShortUrl = shortUrl,
                    Url = url
                };

                logger.LogWarning("Link not found, creating new short URL: {ShortUrl}", shortUrl);

                await linksRepository.AddAsync(link);

                return link.ShortUrl;
            }
            else
            {
                logger.LogInformation("Link found, returning existing short URL: {ShortUrl}", entity.ShortUrl);

                return entity.ShortUrl;
            }
        }

        public async Task<IEnumerable<LinkDto>> GetShortLinksAsync()
        {
            logger.LogInformation("Getting all short links");

            var links = await linksRepository.GetAllAsync();

            var linksDto = mapper.Map<IEnumerable<LinkDto>>(links);

            logger.LogInformation("Successfully retrieved {Count} short links", linksDto.Count());

            return linksDto;
        }
    }
}
