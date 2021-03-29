using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Model;
using Livraria.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestesController : Controller
    {

        private readonly Contexto _context;

        public TestesController(Contexto context)
        {
            _context = context;
        }

        /// <summary>
        /// Teste
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutor()
        {
            return await _context.Autor.ToListAsync();
        }

    }
}