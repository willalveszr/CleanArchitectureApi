# Clean Architecture API

Este projeto é simples, uma API REST desenvolvida em **.NET 8**, seguindo os princípios da **Clean Architecture**.  
O objetivo é demonstrar boas práticas de separação de responsabilidades, injeção de dependência, uso de DTOs e mapeamentos.

---

## ⚙️ Tecnologias Utilizadas

- .NET 8 / ASP.NET Core  
- Entity Framework Core  
- AutoMapper  
- Clean Architecture  
- MySQL Server (pode ser alterado para outro banco)  

---

## 📂 Estrutura do Projeto
```
├── Domain
│ ├── Entities # Entidades de domínio (regras de negócio)
│ └── Interfaces # Contratos (ex: repositórios)
│
├── Application
│ ├── DTOs # Objetos de transferência de dados
│ ├── Interfaces # Contratos de serviços
│ ├── Mappings # Configurações do AutoMapper
│ └── Services # Implementação da lógica de aplicação
│
├── Infrastructure
│ ├── Context # DbContext (Entity Framework Core)
│ ├── Migrations # Migrações do banco
│ └── Repositories # Implementações dos repositórios
│
└── Api
├── Controllers # Endpoints da API
├── Program.cs # Configurações de inicialização
└── appsettings.json
```

---

## 🚀 Como Executar
1. **Clone o repositório**:  
```
git clone https://github.com/seu-usuario/CleanArchitectureApi.git
```
