using System;
using System.Collections.Generic;
using System.Text;

namespace Clinovi.Application
{
    public record CriarProdutoDto(string Nome, string Descricao, decimal Preco, int Estoque);

    public record AtualizarProdutoDto(string Nome, string Descricao, decimal Preco);

    public record ProdutoDto(Guid Id, string Nome, string Descricao, decimal Preco, int Estoque);

    public record VendaDto(int Quantidade);

    public interface IProdutoService
    {
        Task<List<ProdutoDto>> ObterTodos();
        Task<ProdutoDto?> ObterPorId(Guid id);
        Task Criar(CriarProdutoDto dto);
        Task Atualizar(Guid id, AtualizarProdutoDto dto);
        Task Remover(Guid id);
        Task Vender(Guid id, int quantidade);
    }
}
