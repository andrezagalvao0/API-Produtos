using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutosAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProdutosAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProdutosAPI.Controllers
{
    [Route("api/produto")]
    [ApiController]
    [Authorize]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ProdutosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Cadastra um produto desejado. OBS: Não é necessário informar o id, o banco incrementa de forma dinâmica.
        /// </summary>
        /// <remarks>
        /// Exemplo: 
        ///     
        ///     Post /Produto
        ///     {
        ///         "id": 0,
        ///         "nome": "Arroz",
        ///         "quantidade": 100,
        ///         "valor": 3.50
        ///      }
        /// </remarks>
        /// <param name="produto"></param>
        /// <returns>Um novo produto criado</returns>
        
        [HttpPost("cadastrarProdutos")]
        public async Task<IActionResult> CreateProduto(Produto produto)
        {
            _appDbContext.Produtos.Add(produto);
            await _appDbContext.SaveChangesAsync();

            return Ok(new
            {
                sucess = true,
                data = produto
            });
        }

        /// <summary>
        /// Lista os produtos cadastrados
        /// </summary>
        /// <returns>Os produtos armazenados</returns>
        /// <response code="200"> Retorna os produtos cadastrados</response>
        [HttpGet("consultarProdutos")]
        public async Task<IActionResult> GetProdutos()
        {
            return Ok(new
            {
                sucess = true,
                data = await _appDbContext.Produtos.ToListAsync()
            });
        }
    }
}
