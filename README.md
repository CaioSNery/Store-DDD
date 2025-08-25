# Projeto DDD .NET - Store

## 🚀 Descrição
API RESTful desenvolvida em **.NET 8**, seguindo os princípios de **Domain-Driven Design (DDD)**. O sistema foi estruturado com foco em boas práticas, escalabilidade e organização de código, utilizando camadas claramente definidas para facilitar manutenção e evolução.

Recentemente, foi incluído o **módulo de Delivery**, permitindo o controle de status de envio de pedidos (`WaitingDelivery` → `Shipped`) de forma segura e automatizada.

---

## 🏗 Estrutura do Projeto
O projeto segue a arquitetura DDD com separação de responsabilidades:

- **Domain**: Entidades, agregados, interfaces de repositório e regras de negócio.
- **Application / Services**: Serviços que orquestram a lógica de negócio.
- **Infrastructure / Repository**: Implementações de acesso a dados e serviços externos.
- **API**: Endpoints REST, Controllers, DTOs e configuração de autenticação JWT.

### 🆕 Novas Funcionalidades
- **Delivery / Shipping**:  
  - Controle de status de pedidos (`WaitingDelivery`, `Shipped`).  
  - Possibilidade de envio automático via backend ou jobs agendados.  
  - Integração segura com regras de negócio, evitando envio de pedidos não pagos.  

---

## ⚙ Tecnologias utilizadas
- .NET 8.0 / C#
- Entity Framework Core 8
- SQL Server
- AutoMapper
- Flunt (Validações Fail Fast)
- JWT (Autenticação)
- Twilio (Notificações via SMS/WhatsApp)
- Git / GitHub
- Visual Studio Code

---

## 📝 Funcionalidades Principais
- Cadastro e gerenciamento de entidades (Clientes, Produtos, Vendas)
- Validações imediatas (Fail Fast) para garantir integridade dos dados
- Registro de vendas com atualização automática de estoque
- Controle de **status de pedidos e envio (Delivery)**
- Autenticação e autorização via JWT
- Estrutura preparada para testes unitários com MSTest e mocks
- Boas práticas de **Clean Architecture** e **Repository Pattern**

---

## ⚡ Melhorias Implementadas Hoje
1. **Delivery / Shipping**:  
   - Método `Ship()` validando status antes de atualizar para `Shipped`.  
   - Possibilidade de envio automático via backend ou jobs agendados.  
   - Evita envio de pedidos ainda não pagos.  

2. Pequenos ajustes no fluxo de `Cancel()` para suportar **processamento assíncrono** em background (ex.: timeout ou conciliação).  

3. Atualização da documentação e diagramas para refletir o **novo fluxo de pedidos e envio**.

---

> 💡 Observação: O projeto está preparado para evoluções futuras, como integração com transportadoras externas ou fila de mensagens para envio assíncrono de pedidos.


