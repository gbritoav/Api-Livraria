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
    public class EditorasController : ControllerBase
    {
        private readonly EditoraRepositorio _contextoEditora = new EditoraRepositorio();

        public EditorasController(Contexto contexto)
        {
            _contextoEditora.Contexto(contexto);
        }

        /// <summary>
        /// Método para obter todos os cadastros disponíveis
        /// </summary>            
        /// <returns>Retorna uma lista de cadastro</returns>       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editora>>> GetEditora()
        {
            try
            {
                return new JsonResult(_contextoEditora.GetAll());
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
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Editora>> GetEditora(int id)
        {
            try
            {
                var editora = _contextoEditora.GetId(id);

                if (editora == null)
                {
                    return NotFound();
                }

                return editora;
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
        /// <param name="editora">Informaçoes do carastro para alteração</param>   
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditora(int id, Editora editora)
        {
            if (id != editora.Id)
            {
                return BadRequest();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _contextoEditora.Update(editora);
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
        /// <param name="editora">Informaçoes da editora para cadastro</param>   
        [HttpPost]
        public async Task<ActionResult<Editora>> PostEditora(Editora editora)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contextoEditora.Add(editora);
                }
                else
                {
                    return editora;
                }

                return CreatedAtAction("GetEditora", new { id = editora.Id }, editora);
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
        public async Task<ActionResult<Editora>> DeleteEditora(int id)
        {
            try
            {
                var editora = _contextoEditora.GetId(id);
                if (editora == null)
                {
                    return NotFound();
                }

                _contextoEditora.Remove(editora);


                return editora;
            }
            catch (Exception ex)
            {

                return NotFound(ex.InnerException.Message);
            }
        }
    }
}
