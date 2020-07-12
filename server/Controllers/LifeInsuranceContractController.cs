using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using server.DataModel;
using server.Models;
using server.Repository;
using server.Repository.CoveragePlanRepository;
using server.Repository.RateChartRepository;
using System;
using System.Threading.Tasks;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LifeInsuranceContractController : ControllerBase
    {

        private readonly ILifeInsuranceRepository _lifeInsuranceRepository;
        private readonly ICoveragePlanRepository _coveragePlanRepository;
        private readonly IRateChartRepository _rateChartRepository;
        public LifeInsuranceContractController(ILifeInsuranceRepository lifeInsuranceRepository, ICoveragePlanRepository coveragePlanRepository, IRateChartRepository rateChartRepository)
        {
            _lifeInsuranceRepository = lifeInsuranceRepository;
            _coveragePlanRepository= coveragePlanRepository;
            _rateChartRepository= rateChartRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetLifeInsuranceContract()
        {
            try
            {
                var categories = await _lifeInsuranceRepository.GetLifeInsuranceContractAsync();
                if (categories == null)
                {
                    return NotFound();
                }

                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("AddPost")]
        public async Task<IActionResult> CreateLifeInsuranceContract([FromBody] Customer model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LifeInsuranceContract lifeInsuranceContract = new LifeInsuranceContract();

                    CoveragePlanAndRates coveragePlanAndRates = new CoveragePlanAndRates(_coveragePlanRepository, _rateChartRepository);

                    lifeInsuranceContract = coveragePlanAndRates.GetCoveragePlanAndRates(model);
                    lifeInsuranceContract = await _lifeInsuranceRepository.CreateLifeInsuranceContract(lifeInsuranceContract);
                    if (lifeInsuranceContract.Id > 0)
                    {
                        return Ok(lifeInsuranceContract.Id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateLifeInsuranceContract")]
        public async Task<IActionResult> UpdatePost([FromBody] Customer model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LifeInsuranceContract lifeInsuranceContract = new LifeInsuranceContract();
                    CoveragePlanAndRates coveragePlanAndRates = new CoveragePlanAndRates();
                    lifeInsuranceContract = coveragePlanAndRates.GetCoveragePlanAndRates(model);
                    await _lifeInsuranceRepository.UpdateLifeInsuranceContract(lifeInsuranceContract);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteLifeInsuranceContract")]
        public async Task<IActionResult> DeleteLifeInsuranceContract(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                bool result = await _lifeInsuranceRepository.DeleteLifeInsuranceContract(id);
                if (!result)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        

    }
}
