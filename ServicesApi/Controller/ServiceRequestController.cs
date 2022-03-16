using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesApi.Models;
using ServicesApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IServiceRequestRepository _serviceRequestRepository;

        public ServiceRequestController(IServiceRequestRepository serviceRequestRepository)
        {
            _serviceRequestRepository = serviceRequestRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceRequest>>> GetServiceRequests()
        {
            var serviceRequests = await _serviceRequestRepository.Get();

            if (!serviceRequests.Any())
            {
                return NoContent();
            }

            return Ok(serviceRequests);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceRequest>> GetServiceRequests(Guid id)
        {
            return await _serviceRequestRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceRequest>> PostServiceRequest([FromBody] ServiceRequest serviceRequest)
        {
            var newServiceRquest = await _serviceRequestRepository.Create(serviceRequest);
            return CreatedAtAction(nameof(GetServiceRequests), new { id = newServiceRquest.Id }, newServiceRquest);
        }

        [HttpPut]
        public async Task<ActionResult> PutServiceRequest(Guid id, [FromBody] ServiceRequest serviceRequest)
        {
            if(id != serviceRequest.Id)
            {
                return BadRequest();
            }

            var serviceRequestFounded = await _serviceRequestRepository.Get(id);

            if (serviceRequestFounded == null)
            {
                return NotFound();
            }

            await _serviceRequestRepository.Update(serviceRequest);

            return Ok(serviceRequest);
        }
    }
}
