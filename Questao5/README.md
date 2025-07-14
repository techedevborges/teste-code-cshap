# Questão 5 - API Conta Corrente (.NET + SQLite)

## 📋 Descrição do Desafio

A aplicação simula parte de um sistema bancário, com foco em:

- 💳 **Movimentação de conta corrente** (crédito e débito)
- 📊 **Consulta de saldo atual** da conta corrente

A API foi construída com ASP.NET Core e utiliza SQLite como banco de dados, usando Dapper para acesso aos dados.

---

## 🚀 Tecnologias Utilizadas

- .NET 6 / .NET 7
- ASP.NET Core Web API
- SQLite
- Dapper
- Swagger (Swashbuckle)

---

## 🧠 Regras de Negócio

### 🔁 Movimentação

**Endpoint:** `POST /api/ContaCorrente/movimentar`

Requisição:

```json
{
  "idContaCorrente": "GUID",
  "tipoMovimento": "C", // ou "D"
  "valor": 100.00
}
```

### Validações da Movimentação

- ✅ Conta deve existir → INVALID_ACCOUNT
- ✅ Conta deve estar ativa → INACTIVE_ACCOUNT
- ✅ Valor deve ser positivo → INVALID_VALUE
- ✅ Tipo deve ser "C" (crédito) ou "D" (débito) → INVALID_TYPE

Resposta de sucesso:

```json
{
  "id": "ID do movimento gerado"
}
```

### 💰 Consulta de Saldo

**Endpoint:** `GET /api/ContaCorrente/saldo/{id}`

### Validações da Consulta

- ✅ Conta deve existir → INVALID_ACCOUNT
- ✅ Conta deve estar ativa → INACTIVE_ACCOUNT

Resposta de sucesso:

```json
{
  "numero": 123,
  "nome": "Katherine Sanchez",
  "dataHora": "11/07/2025 19:00:00",
  "saldo": 150.00
}
```

---

## 🗂️ Estrutura do Projeto

``` plaintext
/Questao5
├── Controllers/
│   └── ContaCorrenteController.cs
│
├── Domain/
│   ├── Entities/
│   │   ├── ContaCorrente.cs
│   │   └── Movimento.cs
│   └── Enumerators/
│       └── TipoMovimento.cs
│
├── Infrastructure/
│   ├── Sqlite/
│   │   ├── DatabaseBootstrap.cs
│   │   └── DatabaseConfig.cs
│   ├── Repositories/
│   │   ├── IContaCorrenteRepository.cs
│   │   └── ContaCorrenteRepository.cs
│   └── Services/
│       └── ContaCorrenteService.cs
│
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── database.sqlite
└── README.md
```

## ⚙️ Como Executar o Projeto

### 1. Restaurar pacotes e compilar

``` bash
dotnet restore
dotnet build
```

### 2. Rodar a aplicação

``` bash
dotnet run
```

### 3. Testar no navegador via Swagger

Acesse:

``` http
https://localhost:{porta}/swagger
```

Ou use Postman/Insomnia para testar os endpoints.

### 🛑 Observações

- As contas já estão pré-cadastradas no banco SQLite.
- A base de dados (database.sqlite) é criada e inicializada automaticamente com `DatabaseBootstrap.cs`.
- Apenas contas ativas podem ser movimentadas ou consultadas.
