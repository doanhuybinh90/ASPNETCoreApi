using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Domain.DTOs.Visitor;
using Domain.Entities;
using Domain.Interfaces.Services.VIsitors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private IVisitorService _service;
        public VisitorController(IVisitorService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] IVisitorService service)
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
        [Route("{id}", Name ="GetWithID")]
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
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] InputCreateVisitor createVisitor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var visitor = new Visitor
                {
                    Id = Guid.NewGuid(),
                    Name = createVisitor.Name,
                    Email = createVisitor.Email,
                    Cpf = createVisitor.Cpf,
                    Password = createVisitor.Password,
                    Bookings = new List<Booking>()
                };
                var result = await _service.Post(visitor);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.Id})), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody]InputUpdateVisitor updateVisitor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var visitor = await _service.Get(updateVisitor.Id);
                visitor.Name = updateVisitor.Name;
                visitor.Email = updateVisitor.Email;
                visitor.Password = updateVisitor.Password;
                visitor.Cpf = updateVisitor.Cpf;

                var result = await _service.Put(visitor);
                if(result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [Authorize("Bearer")]
        [HttpDelete ("{id}")]
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
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
