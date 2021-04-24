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
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaRepositorio _contextoCategoria = new CategoriaRepositorio();
       

        /// <summary>
        /// Método para obter todos os cadastros disponíveis
        /// </summary>            
        /// <returns>Retorna uma lista de cadastro</returns>   
        [HttpGet]
        [Authorize(Roles = "Comun,Adm")]
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
        /// Método para obter um valor específico
        /// </summary>
        /// <param name="id">Id do valor que será obtido</param>
        /// <returns>
        /// Retorna o valor de acordo com o Id informado
        /// </returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Comun,Adm")]
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
        /// Método para alterar um cadastro já salvo
        /// </summary>
        /// <param name="id">Id do cadastros</param> 
        /// <param name="categoria">Informações da categoria para alteração</param>   
        [HttpPut("{id}")]
        [Authorize(Roles = "Comun,Adm")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _contextoCategoria.Update(categoria);
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
        /// <param name="categoria">Informaçoes do carastro</param>   
        [HttpPost]
        [Authorize(Roles = "Comun,Adm")]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contextoCategoria.Save(categoria);


                    return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);
                }
                else 
                {
                    return categoria;
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
        public async Task<ActionResult<Categoria>> DeleteAutor(int id)
        {
            try
            {
                var categoria = _contextoCategoria.GetId(id);
                if (categoria == null)
                {
                    return NotFound();
                }

                _contextoCategoria.Delete(categoria);


                return categoria;
            }
            catch (Exception ex)
            {

                return NotFound(ex.InnerException.Message);
            }
        }
    }
}
