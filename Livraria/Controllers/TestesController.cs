using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestesController : Controller
    {

        /// <summary>
        /// Teste
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<string>> GetTeste()
        {
            string teste = "Bem vindo!";
            return new JsonResult(teste);
        }

    }
}