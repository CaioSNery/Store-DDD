#  Projeto DDD .NET - Store

## 🚀 Descrição

API RESTful desenvolvida em **.NET 8**, utilizando **Domain-Driven Design (DDD)**, com foco em boas práticas, escalabilidade e organização de código.  
O sistema é estruturado em camadas claras, separando **Domínio, Aplicação, Infraestrutura e API**, facilitando manutenção e evolução.

---

## 🏗 Estrutura do Projeto

O projeto segue a arquitetura **DDD**:

- **Domain**: Entidades, agregados, interfaces de repositório e regras de negócio.
- **Application / Services**: Serviços que orquestram a lógica de negócios.
- **Infrastructure / Repository**: Implementações de acesso a dados e serviços externos.
- **API**: Endpoints REST, Controllers, DTOs e configuração de autenticação JWT.

**Outros recursos incluídos:**

- ✅ Validações **Fail Fast** com [Flunt](https://github.com/andrebaltieri/flunt)
- 🔄 Mapeamento DTO ↔ Entidade com **AutoMapper**
- 🔑 Autenticação via **JWT**
- 🧹 Boas práticas de **Clean Architecture** e **Repository Pattern**

---

## ⚙ Tecnologias utilizadas

- .NET 8.0 / C#
- Entity Framework Core 8
- SQL Server
- AutoMapper
- Flunt
- JWT
- Twilio
- Git / GitHub
- VS Code

---

## 📝 Funcionalidades Principais

- Cadastro e gerenciamento de entidades (Clientes, Produtos, Vendas)
- Validações imediatas (**Fail Fast**) para evitar inconsistências
- Registro de vendas/consultas com atualização de estoque/agenda
- Autenticação e autorização via JWT
- Estrutura preparada para testes unitários com MSTest e mocks

---



