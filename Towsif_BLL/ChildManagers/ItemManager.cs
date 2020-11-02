using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Towsif_BLL.BaseManager;
using Towsif_DAL.Repositories;
using Towsif_Entity.Entity;

namespace Towsif_BLL.ChildManagers
{
    public class ItemManager : BaseManager<Towsif_Item>
    {
        public ItemManager() : base(new ItemRepository())
        {
        }
    }
}
