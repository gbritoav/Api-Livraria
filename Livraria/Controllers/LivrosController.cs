using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Livraria.Model;
using Livraria.Repositorio;
using Microsoft.AspNetCore.Authorization;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {

        private readonly LivroRepositorio _contextoLivro = new LivroRepositorio();


        /// <summary>
        /// Método para obter todos os cadastros disponíveis
        /// </summary>            
        /// <returns>Retorna uma lista de cadastro</returns>       
        [HttpGet]
        [Authorize(Roles = "Comun,Adm")]
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
        /// Método para obter um valor específico
        /// </summary>
        /// <param name="id">Id do valor que será obtido</param>
        /// <returns>
        /// Retorna o valor de acordo com o Id informado
        [HttpGet("{id}")]
        [Authorize(Roles = "Comun,Adm")]
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
        /// Método para alterar um cadastro já salvo
        /// </summary>
        /// <param name="id">Id do cadastros</param> 
        /// <param name="livro">Informaçoes do carastro para alteração</param>       
        [HttpPut("{id}")]
        [Authorize(Roles = "Comun,Adm")]
        public async Task<IActionResult> PutLivro(int id, Livro livro)
        {
            if (id != livro.Id)
            {
                return BadRequest();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _contextoLivro.Update(livro);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Método para publicar um cadastro
        /// </summary>
        /// <param name="livroau">Informaçoes do livro para cadastrar</param>   
        [HttpPost]
        [Authorize(Roles = "Comun,Adm")]
        public async Task<ActionResult<Livro>> PostLivro(Livro livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contextoLivro.Save(livro);

                    return CreatedAtAction("GetLivro", new { id = livro.Id }, livro);
                }
                else
                {
                    return livro;
                }

            }
            catch (Exception ex)
            {

                return NotFound(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Método para deletar cadastro
        /// </summary>
        /// <param name="id">Id do cadastros que será deletado</param>    
        [HttpDelete("{id}")]
        [Authorize(Roles = "Comun,Adm")]
        public async Task<ActionResult<Livro>> DeleteLivro(int id)
        {
            try
            {
                var livro = _contextoLivro.GetId(id);
                if (livro == null)
                {
                    return NotFound();
                }

                _contextoLivro.Delete(livro);


                return livro;
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
    }
}
