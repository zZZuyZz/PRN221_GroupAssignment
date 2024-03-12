﻿using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class Booking
    {
        public Guid Id { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? AgencyId { get; set; }
        public string? BookingUserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Content { get; set; }
        public DateTime? BookingDate { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public virtual User? Agency { get; set; }
        public virtual User? Customer { get; set; }
        public virtual Product? Product { get; set; }
    }
}
