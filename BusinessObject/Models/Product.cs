using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class Product
    {
        public Product()
        {
            Bookings = new HashSet<Booking>();
            Contracts = new HashSet<Contract>();
        }

        public Guid Id { get; set; }
        public Guid? InvestorId { get; set; }
        public Guid? FinalCustomerId { get; set; }
        public Guid? ProjectId { get; set; }
        public string? ProductTitle { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public virtual User? FinalCustomer { get; set; }
        public virtual User? Investor { get; set; }
        public virtual Project? Project { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
