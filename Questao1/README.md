# 💰 Projeto Conta Bancária (C#)

## 📋 Descrição

Este projeto é uma simulação simples de uma **conta bancária**, desenvolvida em C# como parte de um exercício de lógica de programação e orientação a objetos.

Ele permite:

- Criar contas com ou sem depósito inicial
- Realizar depósitos
- Realizar saques com taxa fixa
- Exibir os dados atualizados da conta

---

## 📦 Estrutura do Projeto

```plaintext
/Questao1
├── ContaBancaria.cs        # Classe principal com a lógica da conta
├── Questao1.csproj         # Arquivo de configuração do projeto C#
├── Program.cs              # (se existir) ponto de entrada do app
└── README.md               # Este arquivo
```

---

## 🧠 Regras de Negócio

- Cada conta possui
  - Número
  - Titular
  - Saldo
- Saques têm uma taxa fixa de R$3,50
- O saldo só pode ser alterado por métodos de depósito ou saque
- O número da conta é imutável
- O nome do titular pode ser alterado

## 🧱 Classe: ContaBancaria

### 🔹 Atributos privados

``` code
private double _saldo;
private const double TaxaSaque = 3.50;
```

### 🔹 Propriedades

``` code
public int Numero { get; }       // Somente leitura
public string Titular { get; set; }  // Leitura e escrita
```

### 🔹 Construtores

``` code
// Sem depósito inicial
new ContaBancaria(123, "Maria");

// Com depósito inicial
new ContaBancaria(456, "João", 1000.00);
```

### 🔹 Métodos principais

- Deposito(double quantia)
- Saque(double quantia) (com taxa)
- ToString() → retorna os dados formatados da conta

## 🚀 Como Executar

Certifique-se de ter o .NET SDK instalado:

``` bash
dotnet --version
```

Compile e execute:

``` bash
dotnet run
```

## 🧪 Exemplo de uso

``` code
ContaBancaria conta = new ContaBancaria(123, "Ana", 500.00);
Console.WriteLine(conta); // Conta 123, Titular: Ana, Saldo: $ 500.00

conta.Deposito(200.00);
Console.WriteLine(conta); // Conta 123, Titular: Ana, Saldo: $ 700.00

conta.Saque(100.00);
Console.WriteLine(conta); // Conta 123, Titular: Ana, Saldo: $ 596.50
```

## 📌 Observações

- O método ToString() usa CultureInfo.InvariantCulture para exibir o saldo com ponto como separador decimal.
- Os métodos encapsulam o acesso ao saldo, que é mantido privado, respeitando o princípio do encapsulamento.
