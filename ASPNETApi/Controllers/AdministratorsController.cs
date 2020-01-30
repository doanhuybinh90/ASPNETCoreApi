using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ASPNETApi.Controllers.DTOs;
using Domain.Entities;
using Domain.Interfaces.Services.Administrators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorsController : ControllerBase
    {
        private IAdministratorService _service;

        public AdministratorsController(IAdministratorService service)
        {
            _service = service;
        }
        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] IAdministratorService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetID")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] InputCreateAdmin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var administrator = new Administrator()
                {
                    Id = Guid.NewGuid(),
                    Name = admin.Name,
                    Email = admin.Email,
                    Cnpj = admin.Cnpj,
                    Password = admin.Password,
                    Bookings = new List<Booking>()
                };
                var result = await _service.Post(administrator);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetID", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] InputUpdateAdmin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var administrator = await _service.Get(admin.Id);
                administrator.Name = admin.Name;
                administrator.Email = admin.Email;
                administrator.Password = admin.Password;
                administrator.Cnpj = admin.Cnpj;
                

                var result = await _service.Put(administrator);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}