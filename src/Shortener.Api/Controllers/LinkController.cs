using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DAL.Controllers
{
    public class LinkController : ControllerBase
    {
        private readonly IRepository<LinkEntity> linksRepository;

        public LinkController(IRepository<LinkEntity> linksRepository)
        {
            this.linksRepository = linksRepository;
        }

        public async Task<int> CreateLink(LinkEntity entity)
        {
            await linksRepository.AddAsync(entity);
            return entity.Id;
        }

        public async Task<IEnumerable<LinkEntity>> GetAllLinks()
        {
            return await linksRepository.GetAllAsync();
        }
    }
}
