# Exemplo de API de cadastro de usuários e cursos com autenticação via JWT

## 1. Introdução

O projeto foi criado com base no curso de *Configuração da arquitetura back-end com .NET Core* realizado no portal da DIO.

## 2.Propósito

Aplicar conceitos de IOC, DI Patterns, documentação de API com swagger e estrutura de pastas de uma API Restfull.

## 3.Ferramentas

 - .NET Core com C# com sdk .NET 6.0.100
 - Sql Server com entity framework
 - Visual Studio 2022

## 4. Dependências

- Microsoft.AspNetCore.Authentication v2.2.0 - tipos comuns usados pelos vários componentes de middleware de autenticação
- Microsoft.AspNetCore.Authentication.JwtBearer v6.0.0 - middleware que permite que um aplicativo receba um token de portador OpenID Connect.
- Microsoft.EntityFrameworkCore v6.0.0 - Entity Framework Core é um mapeador de banco de dados de objetos moderno para .NET. Ele oferece suporte a consultas LINQ, controle de alterações, atualizações e migrações de esquema. EF Core funciona com SQL Server, Banco de Dados SQL do Azure, SQLite, Azure Cosmos DB, MySQL, PostgreSQL e outros bancos de dados por meio de uma API de plug-in do provedor.
- Microsoft.EntityFrameworkCore.Relational v6.0.0 - Componentes essenciais do Shared Entity Framework para provedores de banco de dados relacional.
- Microsoft.EntityFrameworkCore.SqlServer v6.0.0 - Provedor de banco de dados Microsoft SQL Server para Entity Framework Core.
- Swashbuckle.AspNetCore v6.2.3 - Ferramentas Swagger para documentar APIs construídas no ASP.NET Core
- Swashbuckle.AspNetCore.Annotations v6.2.3 - Fornece atributos personalizados que podem ser aplicados a controladores, ações e modelos para enriquecer o Swagger gerado

## 5. Estrutura

 - Controllers - Utilizados para o tratamento das requisições Http.
 - Filters - Utilizados validar o envio das informações.
 - Infrastructure/Data - Camada de acesso aos dados
    - Mappings - Configuração das tabelas criadas no banco de dados
    - Repositories - Utilizadas para operações no banco de dados
 - Migrations - Criadas pelo EntityFramwork
 - Models - Camada de modelos
    - Entities - Utilizadas para formatar as entidades
    - ViewModels - Utilizadas para formatar o recebimento e envio de parâmetros
 - Services - Camada de serviços

# 6. Setup

- Clone o projeto
- Adicione as depedências
- Informe a connectionString do banco de dados no arquivo appsettings.json no formato a seguir: 
          
          `"ConnectionStrings": { "DefaultConnection": "" },`

- Informe a chave do secret JWT no arquivo appsettings.json no formato a seguir: 

          `"JwtConfigurations": { "Secret": "" },`
          
- Adicione a migration com o comando: `Add-Migration "nome-da-migration"`
- Crie as tabelas no banco de dados com o comando: `Update-Database`

O projeto estará pronto para inicialização

# 7. Informações Adicionais

As interfaces são utilizadas para inverção de controle na aplicação e a injeção das dependências dos controllers, repositories e services é realizada no arquivo de setup, no caso o Program.cs

