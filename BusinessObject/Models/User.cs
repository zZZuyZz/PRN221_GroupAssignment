using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class User
    {
        public User()
        {
            BookingAgencies = new HashSet<Booking>();
            BookingCustomers = new HashSet<Booking>();
            ContractAgencies = new HashSet<Contract>();
            ContractCustomers = new HashSet<Contract>();
            ProductFinalCustomers = new HashSet<Product>();
            ProductInvestors = new HashSet<Product>();
            Projects = new HashSet<Project>();
        }

        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public Guid? RoleId { get; set; }
        public byte? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Booking> BookingAgencies { get; set; }
        public virtual ICollection<Booking> BookingCustomers { get; set; }
        public virtual ICollection<Contract> ContractAgencies { get; set; }
        public virtual ICollection<Contract> ContractCustomers { get; set; }
        public virtual ICollection<Product> ProductFinalCustomers { get; set; }
        public virtual ICollection<Product> ProductInvestors { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
