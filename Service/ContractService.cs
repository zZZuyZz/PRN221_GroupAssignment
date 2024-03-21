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
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;

        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public Contract GetContract(Guid id) => _contractRepository.GetContract(id);

        public List<Contract> GetContractList() => _contractRepository.GetContractList();

        public void AddContract(Contract contract) => _contractRepository.AddContract(contract);

        public void DeleteContract(Guid id) => _contractRepository.DeleteContract(id);

        public void EditContract(Contract updatedContract) => _contractRepository.EditContract(updatedContract);

        public List<Booking> GetBookingList() => _contractRepository.GetBookingList();

    }
}

