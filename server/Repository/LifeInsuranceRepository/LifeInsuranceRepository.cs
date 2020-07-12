using Microsoft.EntityFrameworkCore;
using server.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Context=server.LifeInsuranceContext;

namespace server.Repository
{
    public class LifeInsuranceRepository : ILifeInsuranceRepository
    {
        private readonly Context.LifeInsuranceContext _context;
        public LifeInsuranceRepository(Context.LifeInsuranceContext context)
        {
            _context = context;
        }

        public async Task<List<LifeInsuranceContract>> GetLifeInsuranceContractAsync()
        {
            return await _context.LifeInsuranceContracts.ToListAsync();
        }
        public async Task<LifeInsuranceContract> CreateLifeInsuranceContract(LifeInsuranceContract lifeInsuranceContract)
        {
            _context.LifeInsuranceContracts.Add(lifeInsuranceContract);
            await _context.SaveChangesAsync();
            return lifeInsuranceContract;
        }

        public async Task<bool> UpdateLifeInsuranceContract(LifeInsuranceContract lifeInsuranceContract)
        {
            _context.Update(lifeInsuranceContract);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteLifeInsuranceContract(int id)
        {
            var toRemove = _context.LifeInsuranceContracts.Find(id);
            _context.LifeInsuranceContracts.Remove(toRemove);
            await _context.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
