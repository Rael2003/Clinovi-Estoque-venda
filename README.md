# Sistema de Gestão de Catálogo de Produtos e Vendas

API desenvolvida em .NET para gerenciamento de produtos e simulação de vendas, com foco em organização de código, separação de responsabilidades e aplicação de conceitos de Domain-Driven Design (DDD).

---

## Como executar a aplicação localmente

### Pré-requisitos

* .NET 8 SDK ou superior instalado

### Passos

* Abra solução e execute:

```bash
dotnet restore
dotnet run --project Clinovi.API
```

---

## Acessar a API

Após subir a aplicação, acesse:

```
http://localhost:5000/swagger
```

ou

```
https://localhost:5001/swagger
```

---

## Tecnologias utilizadas

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core (InMemory)
* Swagger (Swashbuckle)
* Injeção de Dependência nativa do .NET

---

## Arquitetura (DDD)

O projeto foi dividido em camadas com responsabilidades bem definidas:

### Domain

Contém o núcleo da aplicação:

* Entidade `Produto`
* Regras de negócio (validação de estoque, preço, etc.)
* Exceções de domínio (`DomainException`)
* Interfaces de repositório

### Application

Responsável por orquestrar os casos de uso:

* Services (ex: `ProdutoService`)
* DTOs de entrada e saída
* Exceções de aplicação (`AppException`)

### Infrastructure

Camada de acesso a dados:

* `DbContext` (EF Core)
* Implementação dos repositórios

### API (Presentation)

Camada de entrada da aplicação:

* Controllers
* Configuração de rotas
* Swagger
* Middleware global de tratamento de erros

---

## Sobre as decisões de arquitetura

A separação em camadas foi adotada para manter o domínio isolado de detalhes de infraestrutura e facilitar a evolução do projeto.

Alguns pontos importantes:

* As regras críticas (como controle de estoque) ficam dentro da entidade `Produto`
* A camada de Application apenas coordena o fluxo, sem conter regra de negócio
* Exceções são separadas por responsabilidade (domínio vs aplicação)
* Um middleware centraliza o tratamento de erros e padroniza as respostas da API

---

## Tratamento de erros

A aplicação utiliza um middleware global para interceptar exceções e retornar respostas padronizadas:

* `DomainException` → erros de regra de negócio (ex: estoque insuficiente)
* `AppException` → erros de fluxo (ex: produto não encontrado)
* `Exception` → erro interno inesperado

---

## Observações

* O banco de dados utilizado é em memória
* API documentada via Swagger 

---
