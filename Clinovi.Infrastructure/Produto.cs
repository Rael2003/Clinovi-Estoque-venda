using Clinovi.Domain;
using Microsoft.EntityFrameworkCore;

namespace Clinovi.Infrastructure;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Produto>> ObterTodos()
        => await _context.Produtos.ToListAsync();

    public async Task<Produto?> ObterPorId(Guid id)
        => await _context.Produtos.FindAsync(id);

    public async Task Adicionar(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
    }

    public async Task Remover(Produto produto)
    {
        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
    }
}