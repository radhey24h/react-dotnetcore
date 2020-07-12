using server.DataModel;
using server.Repository.CoveragePlanRepository;
using server.Repository.RateChartRepository;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace server.Models
{
    public class CoveragePlanAndRates
    {
        private ICoveragePlanRepository coveragePlanRepository;
        private IRateChartRepository rateChartRepository;

        public CoveragePlanAndRates(ICoveragePlanRepository coveragePlanRepository, IRateChartRepository rateChartRepository)
        {
            this.coveragePlanRepository = coveragePlanRepository;
            this.rateChartRepository = rateChartRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LifeInsuranceContract GetCoveragePlanAndRates(Customer customer)
        {
            LifeInsuranceContract lifeInsuranceContract = new LifeInsuranceContract();

            lifeInsuranceContract.Name = customer.Name;
            lifeInsuranceContract.Address = customer.Address;
            lifeInsuranceContract.DOB = customer.DOB;
            lifeInsuranceContract.Gender = customer.Gender;
            lifeInsuranceContract.Country = customer.Country;
            lifeInsuranceContract.Saledate = customer.Saledate;
            lifeInsuranceContract.CoveragePlan = GetNewCoveragePlan(customer);
            lifeInsuranceContract.NetPrice = GetNewRates(customer, lifeInsuranceContract.CoveragePlan);

            return lifeInsuranceContract;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        private string GetNewCoveragePlan(Customer customer)
        {

            string coveragePlan = string.Empty;
            if (coveragePlanRepository.GetCoveragePlan() != null)
                coveragePlan = coveragePlanRepository.GetCoveragePlan().FirstOrDefault(
                    x => x.EligibilityDateFrom > customer.Saledate
                    && x.EligibilityDateTo < customer.Saledate
                    && x.EligibilityCountry == customer.Country
                    ).CoveragePlanType;

            return coveragePlan;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        private decimal GetNewRates(Customer customer, string coveragePlan)
        {
            decimal newRates = 0;
            if (rateChartRepository.GetRateChart() != null)
                newRates = rateChartRepository.GetRateChart().FirstOrDefault(
                    x => x.CoveragePlan == coveragePlan
                    && x.CustomerGender == customer.Gender
                    && IsValidCustomerAge(x.CustomerAge, customer.DOB)
                    ).NetPrice;

            return newRates;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerAge"></param>
        /// <param name="dOB"></param>
        /// <returns></returns>
        private bool IsValidCustomerAge(string customerAge, DateTime dOB)
        {
            int age = DateTime.Now.Year - dOB.Year;
            var value = Regex.Replace(customerAge, "[^0-9]+", string.Empty);
            string operation = customerAge.Substring(0, customerAge.IndexOf(value));
            var output = Convert.ToInt32(value);
            switch (operation)
            {
                case "<=": return age <= output;
                case ">": return age > output;
            }

            return false;
        }
    }
}
