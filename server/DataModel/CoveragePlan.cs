using System;
using System.ComponentModel.DataAnnotations;

namespace server.DataModel
{
    public class CoveragePlan
    {
         [Key]
        public string Id { get; set; }
        public string CoveragePlanType { get; set; }
        public DateTime EligibilityDateFrom { get; set; }
        public DateTime EligibilityDateTo { get; set; }
        public string EligibilityCountry { get; set; }
    }
}