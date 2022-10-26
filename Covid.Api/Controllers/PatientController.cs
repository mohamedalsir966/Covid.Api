using Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using Service.PatientFeatures.Commands;
using Service.PatientFeatures.Queries;

namespace Covid.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : BaseController
    {
        /// <summary>
        /// for adding new Patient
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewPatientCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// list of Patient
        /// </summary>
        ///  /// <param name="qurey"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll([FromQuery] QueryStringParameters qurey)
        {
            var requst = new GetAllPatientQuery { Qury = qurey };
            var result = await Mediator.Send(requst);

            return Ok(result);
        }
        /// <summary>
        /// get Patient  by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var requst = new GetPatientByIdQuery { Id = id };
            var result = await Mediator.Send(requst);
            return Ok(result);
        }
        /// <summary>
        /// delete Patient  by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var requst = new DeletePatientByIdCommand { Id = id };
            var result = await Mediator.Send(requst);
            return Ok(result);
        }
        /// <summary>
        /// Updates Patient based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// 
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePatientCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

    }
}
