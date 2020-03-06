using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace EntityModels.Identity
{
    public class User : IdentityUser<Guid>, IBaseEntity
    {
        public virtual ICollection<Order> Orders { get; set; }
    }
}
