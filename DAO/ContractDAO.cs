using BO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ContractDAO
    {
        private static ContractDAO instance = null;
        private readonly RealEstateManagementContext dbContext = null;

        public ContractDAO()
        {
            if (dbContext == null)
            {
                dbContext = new RealEstateManagementContext();
            }
        }
        public static ContractDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ContractDAO();
                }
                return instance;
            }
        }
        public Contract GetContract(Guid id)
        {
            return dbContext.Contracts.FirstOrDefault(m => m.Id.Equals(id));
        }


        public List<Contract> GetContractList()
        {
            return dbContext.Contracts.ToList();
        }

        public void AddContract(Contract contract)
        {
            Contract contractIn = GetContract(contract.Id);
            if (contractIn == null)
            {
                dbContext.Add(contract);
                dbContext.SaveChanges();
            }

        }

        public void DeleteContract(Guid id)
        {
            Contract contract = GetContract(id);
            if (contract != null)
            {
                dbContext.Remove(contract);
                dbContext.SaveChanges();
            }
        }
        public void EditContract(Contract updatedContract)
        {
            var existingContract = GetContract(updatedContract.Id);
            if (existingContract != null)
            {

                dbContext.Update(existingContract);
                dbContext.Attach(existingContract).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
        public List<Booking> GetBookingList(Guid idProduct)
        {

            return dbContext.Bookings
                    .Where(booking => booking.RealEstateId == idProduct)
                    .ToList();
        }
        
    }
}
