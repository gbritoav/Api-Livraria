using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Model;
using Livraria.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestesController : Controller
    {

        private readonly AutorRepositorio _contextoAutor = new AutorRepositorio();

        public TestesController(Contexto contexto)
        {
            _contextoAutor.Contexto(contexto);
        }


        /// <summary>
        /// Teste
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<string>> GetTeste()
        {
            //var teste2 = _contextoAutor.GetAll();
            string teste = "Bem vindo ";// + teste2.First().Nome;
            return new JsonResult(teste);
        }

    }
}