using server.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repository.CoveragePlanRepository
{
    public interface ICoveragePlanRepository
    {
        List<CoveragePlan> GetCoveragePlan();
        
    }
}
