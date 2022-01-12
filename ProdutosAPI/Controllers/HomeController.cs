using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.Models;
using ProdutosAPI.Repositories;
using ProdutosAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ProdutosAPI.Controllers
{
    [ApiController]
    [Route("api/produtoLogin")]
   
    public class HomeController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
        {
            // Recupera o usuário
            var user = UserRepository.Get(model.Username, model.Password);

            // Verifica se o usuário existe
            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });

            }
            else
            {
                // Gera o Token
                var token = TokenService.GenerateToken(model);
                return new
                {
                    user = user,
                    token = token
                };
            }

            

            // Oculta a senha
           // user.Password = "";

            // Retorna os dados
            
        }
    }
}
