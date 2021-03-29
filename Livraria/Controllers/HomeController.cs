using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public ActionResult<string> GetHome()
        {
            return "Seja bem vindo a livraria, uma api desenvolvida por Gabriel Brito Alves";
        }
    }
}