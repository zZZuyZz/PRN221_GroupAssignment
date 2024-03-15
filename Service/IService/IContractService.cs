using BO.Models;
using Repo.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IContractService
    {
            Contract GetContract(Guid id);
            List<Contract> GetContractList();
            void AddContract(Contract contract);
            void DeleteContract(Guid id);
            void EditContract(Contract updatedContract);
        public List<Booking> GetBookingList(Guid idProduct);


    }
}
