using System;
using System.ComponentModel.DataAnnotations;

namespace server.DataModel
{
    public class LifeInsuranceContract
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public DateTime Saledate { get; set; }
        public string CoveragePlan { get; set; }
        public decimal NetPrice { get; set; }
    }
}