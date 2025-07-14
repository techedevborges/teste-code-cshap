# Resolução da Questão - Git e Editor de Texto

## Enunciado

A sequência de comandos abaixo é executada em um repositório Git utilizando o editor `nano` para criação e edição de arquivos:

```
git init
nano README.md
nano default.html
git add .
git commit -m "Commit 1"
git rm default.html
nano style.css
git add style.css
git commit -m "Commit 2"
git checkout -b testing
nano script.js
git add *.js
git commit -m "Commit 3"
git checkout master
```

Ao final da execução dessa sequência, a pergunta é:

> Quais arquivos, **além de `README.md`**, permanecem no diretório de trabalho no branch `master`?

---

## Análise Passo a Passo

- `README.md`: Criado e comitado em `master`. → **Presente**
- `default.html`: Criado e comitado, mas **removido** antes do segundo commit. → **Ausente**
- `style.css`: Criado e comitado em `master`. → **Presente**
- `script.js`: Criado e comitado **no branch `testing`** apenas. → **Ausente em `master`**

---

## Resposta Correta

**[x] style.css, apenas.**

Somente o arquivo `style.css` permanece, além do `README.md`, no diretório de trabalho do branch `master`.

---
