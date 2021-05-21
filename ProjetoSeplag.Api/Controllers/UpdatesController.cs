using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoSeplag.Aplication.Updates.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSeplag.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatesController : ControllerBase
    {
        private readonly IUpdateServices updateServices;

        public UpdatesController(IUpdateServices updateServices)
        {
            this.updateServices = updateServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetUpdates()
        {
            return Ok(await updateServices.GetAll());
        }


    }
}
