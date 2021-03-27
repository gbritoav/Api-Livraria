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
    public class LivrosController : ControllerBase
    {
        private readonly EditoraRepositorio _contextoEditora = new EditoraRepositorio();
        private readonly CategoriaRepositorio _contextoCategoria = new CategoriaRepositorio();
        private readonly AutorRepositorio _contextoAutor = new AutorRepositorio();
        private readonly LivroRepositorio _contextoLivro = new LivroRepositorio();

        public LivrosController(Contexto contexto)
        {
            _contextoEditora.Contexto(contexto);
            _contextoCategoria.Contexto(contexto);
            _contextoAutor.Contexto(contexto);
            _contextoLivro.Contexto(contexto);

        }

        /// <summary>
        /// Lista de Livro
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivro()
        {
            try
            {
                return new JsonResult(_contextoLivro.GetAll());
            }
            catch (Exception ex)
            {

                return NotFound(ex.InnerException.Message);
            }
        }


        /// <summary>
        /// Consultar Livro
        /// </summary>
        /// <param name="id"></param> 
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            try
            {
                var livro = _contextoLivro.GetId(id);

                if (livro == null)
                {
                    return NotFound();
                }

                return livro;
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Alterar Livro
        /// </summary>
        /// <param name="id"></param> 
        /// <param name="livro"></param>     
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, Livro livro)
        {
            if (id != livro.Id)
            {
                return BadRequest();
            }

            try
            {
                _contextoLivro.Update(livro);

            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Salvar Livro
        /// </summary>
        /// <param name="editora"></param>   
        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivro(Livro livro)
        {
            try
            {
                _contextoLivro.Add(livro);


                return CreatedAtAction("GetLivro", new { id = livro.Id }, livro);
            }
            catch (Exception ex)
            {

                return NotFound(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Deletar Livro
        /// </summary>
        /// <param name="id"></param>   
        [HttpDelete("{id}")]
        public async Task<ActionResult<Livro>> DeleteLivro(int id)
        {
            try
            {
                var livro = _contextoLivro.GetId(id);
                if (livro == null)
                {
                    return NotFound();
                }

                _contextoLivro.Remove(livro);


                return livro;
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
    }
}
