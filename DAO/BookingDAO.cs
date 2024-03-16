using BO.Enum;
using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BookingDAO
    {
        private readonly RealEstateManagementContext _context = new();

        private static BookingDAO _instance = new();

        public static BookingDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BookingDAO();
                }
                return _instance;
            }
        }

        public List<Booking> GetAll()
        {
            return _context.Bookings.ToList();
        }
        public Booking? GetById(Guid? id)
        {
            return _context.Bookings?.FirstOrDefault(x => x.Id == id);
        }
        public List<Booking>? GetBookingsByCustomerAgencyId(Guid? id)
        {
            return _context.Bookings?.Where(x => x.CustomerId == id || x.AgencyId == id).ToList();
        }
        public List<Booking>? GetBookingsByStatus(string? status)
        {
            return _context.Bookings?.Where(x => x.Status == status).ToList();
        }
        public List<Booking>? GetBookingsByProductId(Guid? productId)
        {
            return _context.Bookings?.Where(x => x.ProductId == productId).ToList();
        }
        public bool CreateBooking(Booking? booking)
        {
            bool result = false;
            try
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }
    }
}