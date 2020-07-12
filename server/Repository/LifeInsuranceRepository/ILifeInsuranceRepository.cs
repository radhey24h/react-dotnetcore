using server.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repository
{
    public interface ILifeInsuranceRepository
    {
        Task<List<LifeInsuranceContract>> GetLifeInsuranceContractAsync();
        Task<LifeInsuranceContract> CreateLifeInsuranceContract(LifeInsuranceContract lifeInsuranceContract);
        Task<bool> UpdateLifeInsuranceContract(LifeInsuranceContract lifeInsuranceContract);
        Task<bool> DeleteLifeInsuranceContract(int postId);
    }
}
