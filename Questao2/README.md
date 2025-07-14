# ⚽ Calculadora de Gols por Time em um Ano

Este projeto foi desenvolvido como solução para a **Questão 2** do teste técnico. O objetivo é implementar uma aplicação que consulta uma API pública de partidas de futebol e calcula o **número total de gols marcados por um determinado time em um determinado ano**.

---

## 🧾 Enunciado da Questão

Desenvolver uma aplicação que:

- Calcule a quantidade de **gols marcados por um time** em um determinado **ano**.
- Os dados são obtidos via **API pública** que permite filtros por:
  - `year`
  - `team1`
  - `team2`
  - `page`

A aplicação deve exibir o total de gols marcados para os seguintes casos:

1. Time: **Paris Saint-Germain**, Ano: **2013**  
   ✅ Saída esperada: `Team Paris Saint-Germain scored 109 goals in 2013`

2. Time: **Chelsea**, Ano: **2014**  
   ✅ Saída esperada: `Team Chelsea scored 92 goals in 2014`

---

## 🔧 Tecnologias Utilizadas

- **C#** (.NET)
- **HttpClient** para requisições HTTP
- **Newtonsoft.Json** para desserialização do JSON

---

## 📁 Estrutura do Projeto

- `Program.cs` – Contém toda a lógica do programa, incluindo requisição à API, manipulação de páginas e somatória dos gols.

---

## 🚀 Como Executar

### Pré-requisitos

- .NET 6.0 ou superior instalado

### Passos

- No terminal, dentro da pasta do projeto, execute:

```bash
dotnet restore
dotnet run
