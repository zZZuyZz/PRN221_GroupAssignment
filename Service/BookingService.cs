using BO.Models;
using Repo.IRepository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;
        public BookingService(IBookingRepository repository)
        {
            _repository = repository;
        }

        public bool CreateBooking(Booking? booking)
        {
           return _repository.CreateBooking(booking);
        }

        public List<Booking> GetAll()
        {
           return _repository.GetAll();
        }

        public List<Booking>? GetBookingsByCustomerId(Guid? id)
        {
            return _repository.GetBookingsByCustomerId(id);
        }

        public List<Booking>? GetBookingsByProductId(Guid? productId)
        {
            return _repository.GetBookingsByProductId(productId);
        }

        public Booking? GetById(Guid? id)
        {
           return _repository.GetById(id);
        }
    }
}
