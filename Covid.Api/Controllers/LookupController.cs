using Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using Service.LookupFeaturs.Commands;
using Service.LookupFeaturs.Queries;
using Service.PatientFeatures.Commands;
using Service.PatientFeatures.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Covid.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LookupController : BaseController
    {
        /// <summary>
        /// add Vaccin  
        /// </summary>
        /// <param name=command></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddVaccin(CreateVaccinCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// get Vaccin  by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetVaccin(Guid id)
        {
            return Ok(await Mediator.Send(new GetVaccinByIdQuery { VaccinId = id }));
        }
        /// <summary>
        /// list of Vaccines
        /// </summary>
        ///  /// <param name="qurey"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllVaccines([FromQuery] QueryStringParameters qurey)
        {
            var requst = new GetAllVaccinesQuery { Qury = qurey };
            var result = await Mediator.Send(requst);
            return Ok(result);
        }
        /// <summary>
        /// dlete Vaccin based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var requst = new DeleteVaccinCommand { Id = id };
            var result = await Mediator.Send(requst);
            return Ok(result);
        }
        /// <summary>
        /// Updates Patient based on Id.   
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// 
        [HttpPut]
        public async Task<IActionResult> Update(UpdateVaccinCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }


    }
}
