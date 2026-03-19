using Clinovi.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinovi.API
{
    [ApiController]
    [Route("produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.ObterTodos());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var produto = await _service.ObterPorId(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CriarProdutoDto dto)
        {
            await _service.Criar(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, AtualizarProdutoDto dto)
        {
            await _service.Atualizar(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.Remover(id);
            return Ok();
        }

        [HttpPost("{id}/vender")]
        public async Task<IActionResult> Vender(Guid id, VendaDto dto)
        {
            await _service.Vender(id, dto.Quantidade);
            return Ok();
        }
    }   
}
