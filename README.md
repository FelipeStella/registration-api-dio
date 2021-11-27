# Exemplo de API de cadastro de usuários e cursos com autenticação via JWT

## 1. Introdução

O projeto foi criado com base no curso de *Configuração da arquitetura back-end com .NET Core* realizado no portal da DIO.

## 2.Propósito

Aplicar conceitos de IOC, DI Patterns, documentação de API com swagger e estrutura de pastas de uma API Restfull.

## 3.Tecnologia empregada

 - .NET Core com C#.
 - Sql Server

## 4. Dependências

- Microsoft.AspNetCore.Authentication - tipos comuns usados pelos vários componentes de middleware de autenticação
- Microsoft.AspNetCore.Authentication.JwtBearer - middleware que permite que um aplicativo receba um token de portador OpenID Connect.
- Microsoft.EntityFrameworkCore - Entity Framework Core é um mapeador de banco de dados de objetos moderno para .NET. Ele oferece suporte a consultas LINQ, controle de alterações, atualizações e migrações de esquema. EF Core funciona com SQL Server, Banco de Dados SQL do Azure, SQLite, Azure Cosmos DB, MySQL, PostgreSQL e outros bancos de dados por meio de uma API de plug-in do provedor.
- Microsoft.EntityFrameworkCore.Relational - Componentes essenciais do Shared Entity Framework para provedores de banco de dados relacional.
- Microsoft.EntityFrameworkCore.SqlServer - Provedor de banco de dados Microsoft SQL Server para Entity Framework Core.
- Swashbuckle.AspNetCore - Ferramentas Swagger para documentar APIs construídas no ASP.NET Core
- Swashbuckle.AspNetCore.Annotations - Fornece atributos personalizados que podem ser aplicados a controladores, ações e modelos para enriquecer o Swagger gerado

## 5. Estrutura

#### 5.1. Controllers

Utilizados para o tratamento das requisições Http.

#### 5.2. Filters

Utilizados validar o envio das informações.

#### 5.3. Infrastructure/Data

Camada de acesso aos dados

###### 5.3.1. Mappings

Configuração das tabelas criadas no banco de dados

###### 5.3.1. Repositories

Utilizadas para operações no banco de dados

#### 5.4. Migrations

Criadas pelo EntityFramwork

#### 5.5. Models

Camada de modelos

###### 5.5.1. Entities

Utilizadas para formatar as entidades

###### 5.5.2. ViewModels

Utilizadas para formatar o recebimento e envio de parâmetros

#### 5.6. Services

Camada de serviços

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

