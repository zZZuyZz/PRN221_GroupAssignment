using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class Booking
    {
        public Guid Id { get; set; }
        public Guid? RealEstateId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? AgencyId { get; set; }
        public DateTime? BookingDate { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? CreateBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? UpdateBy { get; set; }

        public virtual User? Agency { get; set; }
        public virtual User? Customer { get; set; }
        public virtual Product? RealEstate { get; set; }
    }
}
