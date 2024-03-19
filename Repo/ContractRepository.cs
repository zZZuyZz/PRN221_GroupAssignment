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
    public class ContractRepository : IContractRepository
    {
        public void AddContract(Contract contract) => ContractDAO.Instance.AddContract(contract);

        public void DeleteContract(Guid id) => ContractDAO.Instance.DeleteContract(id);


        public void EditContract(Contract updatedContract) => ContractDAO.Instance.EditContract(updatedContract);

        public List<Booking> GetBookingList() => ContractDAO.Instance.GetBookingList();

        public Contract GetContract(Guid id) => ContractDAO.Instance.GetContract(id);


        public List<Contract> GetContractList() => ContractDAO.Instance.GetContractList();

    }
}
