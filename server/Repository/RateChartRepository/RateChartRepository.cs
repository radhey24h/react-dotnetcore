using Microsoft.EntityFrameworkCore;
using server.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Context=server.LifeInsuranceContext;

namespace server.Repository.RateChartRepository
{
    public class RateChartRepository : IRateChartRepository
    {
        private readonly Context.LifeInsuranceContext _context;
        public RateChartRepository(Context.LifeInsuranceContext context)
        {
            _context = context;
        }

        public  List<RateChart> GetRateChart()
        {
            return  _context.RateCharts.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
