using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Livraria.Model;
using Livraria.Repositorio;
using Newtonsoft.Json;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorsController : ControllerBase
    {
        private readonly AutorRepositorio _contextoAutor = new AutorRepositorio();

        public AutorsController(Contexto contexto)
        {
            _contextoAutor.Contexto(contexto);
        }

        /// <summary>
        /// Lista de Autor
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutor()
        {
            try
            {
                return new JsonResult(_contextoAutor.GetAll());
            }
            catch (Exception ex)
            {

                return NotFound(ex.InnerException.Message);
            }
        }


        /// <summary>
        /// Consultar Autor
        /// </summary>
        /// <param name="id"></param> 
        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetAutor(int id)
        {
            try
            {
                var autor = _contextoAutor.GetId(id);

                if (autor == null)
                {
                    return NotFound();
                }

                return autor;
            }
            catch (Exception ex)
            {

                return NotFound(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Alterar Autor
        /// </summary>
        /// <param name="id"></param> 
        /// <param name="autor"></param>    
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int id, Autor autor)
        {
            if (id != autor.Id)
            {
                return BadRequest();
            }

            try
            {
                _contextoAutor.Update(autor);
              
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Salvar Autor
        /// </summary>
        /// <param name="autor"></param>   
        [HttpPost]
        public async Task<ActionResult<Autor>> PostAutor(Autor autor)
        {
            try
            {
                _contextoAutor.Add(autor);


                return CreatedAtAction("GetAutor", new { id = autor.Id }, autor);
            }
            catch (Exception ex)
            {

                return NotFound(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Deletar Autor
        /// </summary>
        /// <param name="id"></param>   
        [HttpDelete("{id}")]
        public async Task<ActionResult<Autor>> DeleteAutor(int id)
        {
            try
            {
                var autor = _contextoAutor.GetId(id);
                if (autor == null)
                {
                    return NotFound();
                }

                _contextoAutor.Remove(autor);
                

                return autor;
            }
            catch (Exception ex)
            {

                return NotFound(ex.InnerException.Message);
            }
        }

    }
}
