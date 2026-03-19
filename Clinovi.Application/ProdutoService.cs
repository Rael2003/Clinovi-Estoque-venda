using Clinovi.Application.Exceptions;
using Clinovi.Domain;

namespace Clinovi.Application;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repository;

    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProdutoDto>> ObterTodos()
    {
        var produtos = await _repository.ObterTodos();

        return produtos.Select(p => new ProdutoDto(p.Id, p.Nome, p.Descricao, p.Preco, p.Estoque)).ToList();
    }

    public async Task<ProdutoDto?> ObterPorId(Guid id)
    {
        var produto = await _repository.ObterPorId(id);

        if (produto == null) return null;

        return new ProdutoDto(produto.Id, produto.Nome, produto.Descricao, produto.Preco, produto.Estoque);
    }

    public async Task Criar(CriarProdutoDto dto)
    {
        var produto = new Produto(dto.Nome, dto.Descricao, dto.Preco, dto.Estoque);

        await _repository.Adicionar(produto);
    }

    public async Task Atualizar(Guid id, AtualizarProdutoDto dto)
    {
        var produto = await _repository.ObterPorId(id);

        if (produto == null)
            throw new AppException("Produto não encontrado");

        produto.Atualizar(dto.Nome, dto.Descricao, dto.Preco);

        await _repository.Atualizar(produto);
    }

    public async Task Remover(Guid id)
    {
        var produto = await _repository.ObterPorId(id);

        if (produto == null)
            throw new AppException("Produto não encontrado");

        await _repository.Remover(produto);
    }

    public async Task Vender(Guid id, int quantidade)
    {
        var produto = await _repository.ObterPorId(id);

        if (produto == null)
            throw new AppException("Produto não encontrado");

        produto.Vender(quantidade);

        await _repository.Atualizar(produto);
    }
}
