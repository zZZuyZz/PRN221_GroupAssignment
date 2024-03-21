using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.IRepository
{
    public interface IBookingRepository
    {
        public List<Booking> GetAll();
        public Booking? GetById(Guid? id);
        public List<Booking>? GetBookingsByCustomerId(Guid? id);
        public List<Booking>? GetBookingsByProductId(Guid? productId);
        public bool CreateBooking(Booking? booking);
    }
}
