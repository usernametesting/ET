using ETAppApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETAppApi.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        ICollection<Order>Orders { get; set; }

    }
}
