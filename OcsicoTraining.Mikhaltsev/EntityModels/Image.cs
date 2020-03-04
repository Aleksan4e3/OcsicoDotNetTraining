using System;
using System.Collections.Generic;

namespace EntityModels
{
    public class Image : IEntityModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Data { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
