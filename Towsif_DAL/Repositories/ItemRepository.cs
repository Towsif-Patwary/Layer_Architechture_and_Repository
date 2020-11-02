using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Towsif_DAL.Base;
using Towsif_Entity.Entity;

namespace Towsif_DAL.Repositories
{
    public class ItemRepository : Repository<Towsif_Item>
    {
        public ItemRepository() : base(new SampleEntities())
        {
        }
    }
}
