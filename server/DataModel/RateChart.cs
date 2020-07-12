using System;
using System.ComponentModel.DataAnnotations;

namespace server.DataModel
{
    public class RateChart
    {
         [Key]
        public string Id { get; set; }
        public string CoveragePlan { get; set; }
        public string CustomerGender { get; set; }
        public string CustomerAge { get; set; }
        public decimal NetPrice { get; set; }
    }
}