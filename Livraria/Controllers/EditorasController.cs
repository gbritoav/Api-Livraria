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
        /// Lista de Editora
        /// </summary>
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
        /// Consultar Editora
        /// </summary>
        /// <param name="id"></param> 
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
        /// Alterar Editora
        /// </summary>
        /// <param name="id"></param> 
        /// <param name="editora"></param>     
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditora(int id, Editora editora)
        {
            if (id != editora.Id)
            {
                return BadRequest();
            }

            try
            {
                _contextoEditora.Update(editora);

            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Salvar Editora
        /// </summary>
        /// <param name="editora"></param>   
        [HttpPost]
        public async Task<ActionResult<Editora>> PostEditora(Editora editora)
        {
            try
            {
                _contextoEditora.Add(editora);


                return CreatedAtAction("GetEditora", new { id = editora.Id }, editora);
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
