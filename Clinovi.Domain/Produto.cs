using Clinovi.Domain.Exceptions;

namespace Clinovi.Domain;

public class Produto
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }

    public Produto(string nome, string descricao, decimal preco, int estoque)
    {
        Validar(nome, preco, estoque);

        Id = Guid.NewGuid();
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Estoque = estoque;
    }

    public void Atualizar(string nome, string descricao, decimal preco)
    {
        Validar(nome, preco, Estoque);

        Nome = nome;
        Descricao = descricao;
        Preco = preco;
    }

    public void Vender(int quantidade)
    {
        if (quantidade <= 0)
            throw new DomainException("Quantidade inválida");

        if (Estoque < quantidade)
            throw new DomainException("Estoque insuficiente");

        Estoque -= quantidade;
    }

    private void Validar(string nome, decimal preco, int estoque)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("Nome obrigatório");

        if (preco < 0)
            throw new DomainException("Preço inválido");

        if (estoque < 0)
            throw new DomainException("Estoque inválido");
    }
}