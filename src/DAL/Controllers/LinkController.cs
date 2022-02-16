using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DAL.Controllers
{
    public class LinkController : ControllerBase
    {
        private readonly ShortLinkContext context;

        public LinkController(ShortLinkContext context)
        {
            this.context = context;
        }

        public int CreateLink(LinkEntity entity)
        {
            this.context.Add(entity);
            this.context.SaveChanges();
            return entity.Id;
        }

        public IEnumerable<LinkEntity> GetAllLinks()
        {
            return this.context.Links;
        }
    }
}
