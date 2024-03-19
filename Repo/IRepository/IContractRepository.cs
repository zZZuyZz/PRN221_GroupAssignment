using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.IRepository
{
    public interface IContractRepository
    {
        public Contract GetContract(Guid id);
        public List<Contract> GetContractList();
        public void AddContract(Contract contract);
        public void DeleteContract(Guid id);
        public void EditContract(Contract updatedContract);
        public List<Booking> GetBookingList();
    }
}
