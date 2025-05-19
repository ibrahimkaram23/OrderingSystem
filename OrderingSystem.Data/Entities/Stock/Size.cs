using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderingSystem.Data.Commons;

namespace OrderingSystem.Data.Entities.Stock
{
    public class Size
    {
        public int Id { get; set; }
        public LocalizableEntity Name { get; set; } = new LocalizableEntity();
        public virtual ICollection<Product>? Products { get; set; } = new List<Product>();

    }
}
