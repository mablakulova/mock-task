using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shortener.Api
{
    public interface ILinksRepository
    {
        int CreateLink(LinkEntity entity);

        IEnumerable<LinkEntity> GetAllLinks();

        public class LinksRepository : ILinksRepository
        {
            public int CreateLink(LinkEntity entity)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<LinkEntity> GetAllLinks()
            {
                throw new NotImplementedException();
            }
        }
    }


}
