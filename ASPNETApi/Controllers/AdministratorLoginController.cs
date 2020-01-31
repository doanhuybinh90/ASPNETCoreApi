using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.DTOs.Administrator;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorLoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] InputLoginAdmin admin, [FromServices] IAdministratorLoginService service)
        {
            if (!ModelState.IsValid )
                
            {
                return BadRequest(ModelState);
            }
            if (admin == null)
            {
                return BadRequest();
            }

            try
            {
                var administrator = new Administrator
                {
                    Email = admin.Email,
                    Password = admin.Password,
                };
                var result = await service.FindByLogin(administrator);
                if (result != null)
                {
                    return result;
                }
                
                else
                {
                    return NotFound();
                }
                
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
