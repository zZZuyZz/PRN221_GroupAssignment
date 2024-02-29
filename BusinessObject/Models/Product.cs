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
        public string? Address { get; set; }
        public string? Sescription { get; set; }
        public decimal? Price { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? CreateBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? UpdateBy { get; set; }

        public virtual User? FinalCustomer { get; set; }
        public virtual User? Investor { get; set; }
        public virtual Project? Project { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
