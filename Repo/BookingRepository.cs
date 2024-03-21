using BO.Models;
using DAO;
using Repo.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class BookingRepository : IBookingRepository
    {
        public bool CreateBooking(Booking? booking) => BookingDAO.Instance.CreateBooking(booking);

        public List<Booking> GetAll() => BookingDAO.Instance.GetAll();

        public List<Booking>? GetBookingsByCustomerId(Guid? id) => BookingDAO.Instance.GetBookingsByCustomerId(id);

        public List<Booking>? GetBookingsByProductId(Guid? productId) => BookingDAO.Instance.GetBookingsByProductId(productId);

        public Booking? GetById(Guid? id) => BookingDAO.Instance.GetById(id);
    }
}
