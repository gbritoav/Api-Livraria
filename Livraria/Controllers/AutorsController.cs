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
using Microsoft.AspNetCore.Authorization;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorsController : ControllerBase
    {
        private readonly AutorRepositorio _contextoAutor = new AutorRepositorio();

        /// <summary>
        /// Método para obter todos os cadastros disponíveis
        /// </summary>            
        /// <returns>Retorna uma lista de cadastro</returns>       
        [HttpGet]
        [Authorize]
        [Authorize(Roles = "Comun,Adm")]
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
        /// Método para obter um valor específico
        /// </summary>
        /// <param name="id">Id do valor que será obtido</param>
        /// <returns>
        /// Retorna o valor de acordo com o Id informado
        /// </returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Comun,Adm")]
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
        /// Método para alterar um cadastro já salvo
        /// </summary>
        /// <param name="id">Id do cadastros</param> 
        /// <param name="autor">Informações do cadastro para alteração</param>    
        [HttpPut("{id}")]
        [Authorize(Roles = "Comun,Adm")]
        public async Task<IActionResult> PutAutor(int id, Autor autor)
        {
            if (id != autor.Id)
            {
                return BadRequest();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _contextoAutor.Update(autor);
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
        /// <param name="autor">Informações do autor para cadastrar</param>   
        [HttpPost]
        [Authorize(Roles = "Comun,Adm")]
        public async Task<ActionResult<Autor>> PostAutor(Autor autor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contextoAutor.Save(autor);


                    return CreatedAtAction("GetAutor", new { id = autor.Id }, autor);
                }
                else
                {
                    return autor;
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
        public async Task<ActionResult<Autor>> DeleteAutor(int id)
        {
            try
            {
                var autor = _contextoAutor.GetId(id);
                if (autor == null)
                {
                    return NotFound();
                }

                _contextoAutor.Delete(autor);
                

                return autor;
            }
            catch (Exception ex)
            {

                return NotFound(ex.InnerException.Message);
            }
        }

    }
}
