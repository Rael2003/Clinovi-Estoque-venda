using System;
using System.Collections.Generic;
using System.Text;

namespace Clinovi.Domain
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> ObterTodos();
        Task<Produto?> ObterPorId(Guid id);
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Produto produto);
    }
}
