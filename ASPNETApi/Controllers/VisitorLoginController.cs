using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorLoginController : ControllerBase
    {
        [HttpPost]
        public async Task<object> Login([FromBody] InputLoginVisitor visitorLogin, [FromServices] IVisitorLoginService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(visitorLogin == null)
            {
                return BadRequest();
            }

            try
            {
                var visitor = new Visitor
                {
                    Email = visitorLogin.Email,
                    Password = visitorLogin.Password,
                };
                var result = await service.FindByLogin(visitor);
                if(result != null)
                {
                    return result;
                }
                else
                {
                    return NotFound();
                }
            }
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}