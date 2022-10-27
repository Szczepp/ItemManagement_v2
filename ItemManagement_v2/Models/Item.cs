using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.Language;
using System.Collections.Generic;

namespace ItemManagement_v2.Models
{
    public class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
