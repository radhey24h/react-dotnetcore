using Microsoft.EntityFrameworkCore;
using server.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Context=server.LifeInsuranceContext;

namespace server.Repository.CoveragePlanRepository
{
    public class CoveragePlanRepository : ICoveragePlanRepository
    {
        private readonly Context.LifeInsuranceContext _context;
        public CoveragePlanRepository(Context.LifeInsuranceContext context)
        {
            _context = context;
        }

        public  List<CoveragePlan> GetCoveragePlan()
        {
            return  _context.CoveragePlans.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
