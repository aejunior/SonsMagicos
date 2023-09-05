# Teste 2: A Loja de Instrumentos Musicais Mágicos
## Contexto 
Uma loja vende instrumentos musicais mágicos. Cada instrumento tem um nome, tipo (corda, sopro, percussão), preço e uma propriedade mágica (ex: flauta que faz o ouvinte dormir). A loja quer uma API RESTful para gerenciar seu inventário. Lista de Requisitos

### Instrumentos
|Nome|<TipoDeInstrumento>Tipo|Preco|Propriedade|
|--|--|--|--|
| <> | <> | <> | <> |

### Tipo de Instrumento 
|TipoDeInstrumento|
|---|
|corda|
|sopro|
|percussão|

## Requisitos

- [x] Implementar uma API RESTful com endpoints para adicionar, remover, atualizar e listar instrumentos.
- [x] Armazenar informações dos instrumentos em um banco de dados de sua escolha.
- [x] Criar uma funcionalidade que calcule o preço total de todos os instrumentos de um tipo específico (ex: todos os instrumentos de corda).
- [x] Criar uma funcionalidade de busca textual (texto exato) para as propriedades mágicas (ex: ao buscar "dormir", deve retornar todos os instrumentos com poderes que contenham "dormir")
- [x] O código deve ser bem organizado, comentado e seguir padrões de desenvolvimento, como os princípios SOLID.
- [x] Implementar uma camada de autenticação básica para acessar os endpoints da API.
- [x] O projeto deve ser feito em .NET 6.0 ou 7.0 e deve executar em windows/linux.
- [x] Deve ser utilizado o Entity Framework Core como ORM.

## Entrega
- Código fonte da aplicação (pode ser um repositório GIT público)
- Documentação em Markdown ou PDF explicando como executar o código, incluindo as rotas da API.
- Indicação da versão e tipo do banco de dados utilizado.
- Instruções para criar o banco de dados e tabelas necessárias (pode ser um script SQL ou um README específico).


A entrega do teste deve ser feita até o dia 7 de setembro de 2023 - quinta-feira da próxima semana.

Referências
- [Clean Architecture Essencial - ASP .NET Core com C#](https://www.udemy.com/course/clean-architecture-essencial-asp-net-core-com-c/learn/lecture/26063534)
- [Unit of Work](https://www.macoratti.net/16/01/net_uow2.htm) 
- [WebApi](https://www.macoratti.net/19/11/aspc_webapi1.htm)
- [Injeção de dependência](https://www.macoratti.net/17/04/aspcore_di1.htm)
- [Identity](https://balta.io/blog/aspnet-core-autenticacao-autorizacao)
- [Identity](https://www.macoratti.net/17/05/aspncore_identi1.htm)
- [Swagger](https://macoratti.net/22/04/swagger_aprdoc2.htm)
- [Swagger](https://medium.com/tableless/documenta%C3%A7%C3%A3o-de-apis-com-swagger-no-asp-net-core-e7bc3caa9185)
- [AnemicDomainModel](https://martinfowler.com/bliki/AnemicDomainModel.html)
- [Implementar repositórios personalizados com o Entity Framework Core](https://learn.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core#implement-custom-repositories-with-entity-framework-core)
- [MediatR Wiki](https://github.com/jbogard/MediatR/wiki)