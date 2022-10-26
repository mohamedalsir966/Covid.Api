using Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.PatientFeatures.Queries;
using Service.PatientVaccinFeatures.Commands;
using Service.PatientVaccinFeatures.Queries;

namespace Covid.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientVaccin : BaseController
    {
        /// <summary>
        /// for adding new PatientVaccin
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddPatientVaccin(CreatePatientVaccinCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// list of Patient
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var requst = new GetAllPatientVaccinQuery { };
            var result = await Mediator.Send(requst);

            return Ok(result);
        }
    }
}
