using Credit_Card_Management_System.Models;
using Credit_Card_Management_System.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Credit_Card_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {

        IApplicationRepository applicationRepository;

        public ApplicationController(IApplicationRepository _applicationRepository)
        {
            applicationRepository = _applicationRepository;
        }

        public ApplicationController()
        {

        }
       [HttpGet]
        [Route("GetApplications")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await applicationRepository.GetApplications();
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

        [HttpGet]
        [Route("GetApplicationById")]
        public IActionResult GetApplicationById(decimal Id)
        {
            try
            {
                var application = applicationRepository.GetApplicationById(Id);
                return Ok(application);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("AddApplication")]
        public async Task<IActionResult> AddApplication([FromBody] Application model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var applicationId = await applicationRepository.AddApplication(model);
                    if (applicationId > 0)
                    {
                        return Ok(applicationId);
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


        [HttpPost]
        [Route("UpdateApplicationStatus")]
        public async Task<IActionResult> UpdateApplicationStatus([FromBody] UpdateApplicationInput input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await applicationRepository.UpdateApplicationStatus(input.ApplicationId, input.CardStatus);
                    return Ok();
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("UpdateConsignmentStatus")]
        public async Task<IActionResult> UpdateConsignmentStatus([FromBody] ConsignamentInput input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await applicationRepository.UpdateConsignmentStatus(input);
                    return Ok();
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("CourierLog")]
        public async Task<IActionResult> CourierLog([FromBody] CourierLog input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await applicationRepository.CourierLog(input);
                    return Ok();
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }

        public void AddApplication()
        {
            throw new NotImplementedException();
        }
    }
}
