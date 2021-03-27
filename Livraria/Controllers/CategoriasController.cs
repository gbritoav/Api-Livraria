using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Livraria.Model;
using Livraria.Repositorio;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaRepositorio _contextoCategoria = new CategoriaRepositorio();

        public CategoriasController(Contexto contexto)
        {
            _contextoCategoria.Contexto(contexto);
        }

        /// <summary>
        /// Lista de Categoria
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria()
        {
            try
            {
                return new JsonResult(_contextoCategoria.GetAll());
            }
            catch (Exception ex)
            {

                return NotFound(ex.InnerException.Message);
            }
        }


        /// <summary>
        /// Consultar Categoria
        /// </summary>
        /// <param name="id"></param> 
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            try
            {
                var autor = _contextoCategoria.GetId(id);

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
        /// Alterar Categoria
        /// </summary>
        /// <param name="id"></param> 
        /// <param name="categoria"></param>     
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            try
            {
                _contextoCategoria.Update(categoria);

            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Salvar Categoria
        /// </summary>
        /// <param name="categoria"></param>   
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            try
            {
                _contextoCategoria.Add(categoria);


                return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);
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
        public async Task<ActionResult<Categoria>> DeleteAutor(int id)
        {
            try
            {
                var categoria = _contextoCategoria.GetId(id);
                if (categoria == null)
                {
                    return NotFound();
                }

                _contextoCategoria.Remove(categoria);


                return categoria;
            }
            catch (Exception ex)
            {

                return NotFound(ex.InnerException.Message);
            }
        }
    }
}
