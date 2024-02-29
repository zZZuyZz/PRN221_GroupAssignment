using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
