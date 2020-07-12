using server.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repository.RateChartRepository
{
    public interface IRateChartRepository
    {
        List<RateChart> GetRateChart();
        
    }
}
