using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class Project
    {
        public Project()
        {
            Products = new HashSet<Product>();
        }

        public Guid Id { get; set; }
        public Guid? InvestorId { get; set; }
        public string? ProjectStatus { get; set; }
        public string? ProjectLocation { get; set; }
        public string? ProjectGeoLocationUrl { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ProjectTitle { get; set; }
        public string? ProjectContent { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? CreateBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? UpdateBy { get; set; }

        public virtual User? Investor { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
