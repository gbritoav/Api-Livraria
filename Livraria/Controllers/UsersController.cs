﻿
using Livraria.Model;
using Livraria.Repository;
using Livraria.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Livraria.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _contextoUser = new UserRepository();

        // teste
        // teste 2
        // teste 3

        // teste 4
        // teste 5
        /// <summary>
        /// Método para obter todos os cadastros disponíveis
        /// </summary>            
        /// <returns>Retorna uma lista de cadastro</returns>       
        [HttpGet]
        //[Authorize(Roles ="Adm")]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            try
            {

                List<User> usuarios = new List<User>();

                User usu = new User();

                usu.Id = 0;
                usu.Nome = "Gabriel";
                usu.Senha = "asd";
                usu.Email = "teste@com";

                User usu2 = new User();

                usu2.Id = 1;
                usu2.Nome = "Tadeu";
                usu2.Senha = "123";
                usu2.Email = "tadeu@yahoo.com.br";

                usuarios.Add(usu);
                usuarios.Add(usu2);

                return new JsonResult(usuarios);
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
        [Authorize(Roles = "Adm")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var user = _contextoUser.GetId(id);

                if (user == null)
                {
                    return NotFound();
                }

                return user;
            }
            catch (Exception ex)
            {

                return NotFound(ex.InnerException.Message);
            }
        }


        /// <summary>
        /// Método para logar
        /// </summary>
        /// <param name="user">Informações do cadastro para alteração</param>    
        /// <returns>
        /// Retorna usuario sem senha e o token de acesso
        /// </returns>        
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> GetLogin(User user)
        {
            try
            {
                var _user = _contextoUser.GetAll();

                var filter = (from u in _user
                              where u.Nome.Contains(user.Nome) &&
                              u.Senha.Contains(user.Senha)
                              select u).First();

                if (filter == null)
                {
                    return NotFound(new { message = "Usuario ou senha invalido" });
                }

                var token = TokenServices.GeranateToken(filter);
                filter.Senha = "";
                return new
                {
                    user = filter,
                    token = token
                };
            }
            catch (Exception ex)
            {

                return NotFound(ex.InnerException.Message);
            }
        }


        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => string.Format("Autenticado - {0}", User.Identity.Name);


        /// <summary>
        /// Método para alterar um cadastro já salvo
        /// </summary>
        /// <param name="id">Id do cadastros</param> 
        /// <param name="user">Informações do cadastro para alteração</param>    
        [HttpPut("{id}")]
        [Authorize(Roles = "Comun,Adm")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _contextoUser.Update(user);
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
        /// <param name="user">Informações do usuario para cadastrado</param>   
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contextoUser.Save(user);


                    return CreatedAtAction("GetUser", new { id = user.Id }, user);
                }
                else
                {
                    return user;
                }
            }
            catch (Exception ex)
            {

                return NotFound(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Método para publicar um cadastro
        /// </summary>
        /// <param name="users">Informações do usuario para cadastrado</param>  
        [HttpPost("PostUserJson")]
        public string PostUserJson([FromBody] JsonElement users)
        {
            try
            {
                var teste = users.GetProperty("value");
                List<User> list = new List<User>();

                foreach (var item in teste.EnumerateArray())
                {
                    list.Add(new User
                    {
                        Nome = item.GetProperty("displayName").GetString()
                    });           
              
                }

                string result = "";
                foreach (var item in list)
                {
                    result += "Usuário " + item.Nome + " - atualizado " +"\n";
                }

                return result;
            }
            catch (Exception ex)
            {

                return ex.Message.ToString();
            }
        }


        /// <summary>
        /// Método para deletar cadastro
        /// </summary>
        /// <param name="id">Id do cadastros que será deletado</param>   
        [HttpDelete("{id}")]
        [Authorize(Roles = "Adm")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                var user = _contextoUser.GetId(id);
                if (user == null)
                {
                    return NotFound();
                }

                _contextoUser.Delete(user);


                return user;
            }
            catch (Exception ex)
            {

                return NotFound(ex.InnerException.Message);
            }
        }

    }
}
