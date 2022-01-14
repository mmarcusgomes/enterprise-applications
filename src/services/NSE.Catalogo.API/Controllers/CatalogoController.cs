﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSE.Catalogo.API.Data;
using NSE.Catalogo.API.Models;
using NSE.WebAPI.Core.Identidade;

namespace NSE.Catalogo.API.Controllers
{

    [ApiController]
    [Authorize]
    public class CatalogoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public CatalogoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        [AllowAnonymous]
        [HttpGet("catalogo/produtos")]
        public async Task<IEnumerable<Produto>> Index()
        {
            return await _produtoRepository.ObterTodos();
        }
        [ClaimsAuthorize("Catalogo","Ler")]
        [HttpGet("catalogo/produtos/{id}")]
        public async Task<Produto> ProdutoDetalhe(Guid id)
        {
            //throw new Exception("Erro");
            return await _produtoRepository.ObterPorId(id);
        }
    }
}
