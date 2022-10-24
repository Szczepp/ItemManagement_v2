using System.Collections.Generic;

namespace ItemManagement_v2.Models
{
    public class Collection
    {
       
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
