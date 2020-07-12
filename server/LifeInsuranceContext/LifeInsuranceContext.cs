using Microsoft.EntityFrameworkCore;
using server.DataModel;

namespace server.LifeInsuranceContext
{
    public class LifeInsuranceContext : DbContext
    {
        public LifeInsuranceContext(DbContextOptions<LifeInsuranceContext> options)
            : base(options)
        {
        }
        public virtual DbSet<LifeInsuranceContract> LifeInsuranceContracts { get; set; }
        public virtual DbSet<RateChart> RateCharts { get; set; }
        public virtual DbSet<CoveragePlan> CoveragePlans { get; set; }
    }
}
