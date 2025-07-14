# 📊 Consulta de Atendimentos por Assunto e Ano

Este projeto apresenta a **solução SQL** para uma consulta que identifica os assuntos de atendimento com maior recorrência em determinados anos, com base nos dados registrados em uma tabela de banco de dados Oracle.

---

## 📝 Enunciado da Questão

Você deve escrever uma **query SQL** que:

- Exiba:
  - O **assunto**
  - O **ano**
  - A **quantidade de ocorrências**
- Filtre apenas os registros com **mais de 3 ocorrências no mesmo ano**.
- Ordene os resultados por:
  - **Ano (em ordem crescente)**
  - **Quantidade de ocorrências (em ordem decrescente)**

---

## 🧾 Estrutura da Tabela

```sql
CREATE TABLE atendimentos (
  id RAW(16) DEFAULT SYS_GUID() NOT NULL,
  assunto VARCHAR2(100) NOT NULL,
  ano NUMBER(4)
);
```

## 📥 Dados de Teste (Inserções)

```sql
-- Exemplo de inserções:
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao atendimento','2021');
INSERT INTO atendimentos (assunto, ano) VALUES ('Reclamacao produto','2021');
-- (Demais inserções estão no enunciado)
```

## ✅ Resultado Esperado

A consulta deve retornar apenas os assuntos que se repetem mais de 3 vezes no mesmo ano, ordenando primeiro pelo `ano` (ASC) e depois pela `quantidade` (DESC).

## 🧠 Lógica da Solução

A query agrupa os dados por `assunto` e `ano` usando `GROUP BY`, filtra os grupos com `HAVING COUNT(*) > 3`, e finalmente ordena com `ORDER BY`.

## 💡 Solução SQL

```sql
SELECT 
    assunto, 
    ano, 
    COUNT(*) AS quantidade
FROM 
    atendimentos
GROUP BY 
    assunto, ano
HAVING 
    COUNT(*) > 3
ORDER BY 
    ano ASC, quantidade DESC;
```

## 🧪 Comportamento Esperado

- Suponha os seguintes dados para o ano de 2021:

| Assunto                | Ano  | Ocorrências |
| ---------------------- | ---- | ----------- |
| Reclamacao produto     | 2021 | 6           |
| Reclamacao atendimento | 2021 | 4           |

- E para o ano de 2022:

| Assunto                | Ano  | Ocorrências     |
| ---------------------- | ---- | --------------- |
| Reclamacao cadastro    | 2022 | 8               |
| Reclamacao atendimento | 2022 | 3 (não aparece) |

- A saída será:

Reclamacao atendimento | 2021 | 4
Reclamacao produto     | 2021 | 6
Reclamacao cadastro    | 2022 | 8

(Apenas os assuntos com mais de 3 ocorrências são retornados).
