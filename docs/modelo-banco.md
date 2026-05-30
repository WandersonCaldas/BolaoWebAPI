# Modelo de Dados

## Visão Geral

O sistema BolaoWebAPI foi desenvolvido para gerenciamento de bolões de loteria, permitindo o cadastro de modalidades, bolões, participantes, jogos, resultados e cálculo automático de rateio de prêmios.

---

# Entidades

## Modalidade

Representa uma modalidade de loteria.

### Campos

| Campo                   | Tipo    |
| ----------------------- | ------- |
| Id                      | bigint  |
| Nome                    | varchar |
| QuantidadeMinimaNumeros | int     |
| QuantidadeMaximaNumeros | int     |
| NumeroMinimo            | int     |
| NumeroMaximo            | int     |
| Ativo                   | bit     |

### Exemplos

* Mega-Sena
* Lotofácil
* Quina
* Lotomania

---

## Bolao

Representa um bolão cadastrado no sistema.

### Campos

| Campo           | Tipo     |
| --------------- | -------- |
| Id              | bigint   |
| ModalidadeId    | bigint   |
| Nome            | varchar  |
| Descricao       | varchar  |
| ValorCota       | decimal  |
| QuantidadeCotas | int      |
| DataSorteio     | datetime |
| Ativo           | bit      |

### Relacionamentos

* N:1 com Modalidade

---

## Participante

Representa uma pessoa participante do sistema.

### Campos

| Campo    | Tipo    |
| -------- | ------- |
| Id       | bigint  |
| Nome     | varchar |
| Telefone | varchar |
| Email    | varchar |
| Ativo    | bit     |

---

## BolaoParticipante

Representa a participação de um participante em um bolão.

### Campos

| Campo           | Tipo    |
| --------------- | ------- |
| Id              | bigint  |
| BolaoId         | bigint  |
| ParticipanteId  | bigint  |
| QuantidadeCotas | int     |
| ValorCota       | decimal |
| ValorTotal      | decimal |
| Pago            | bit     |

### Relacionamentos

* N:1 com Bolao
* N:1 com Participante

### Regras

* Um participante pode participar de vários bolões.
* Um bolão pode possuir vários participantes.
* O valor total é calculado pela quantidade de cotas multiplicada pelo valor da cota.

---

## Jogo

Representa um jogo realizado dentro de um bolão.

### Campos

| Campo        | Tipo     |
| ------------ | -------- |
| Id           | bigint   |
| BolaoId      | bigint   |
| Numeros      | varchar  |
| DataCadastro | datetime |

### Exemplo

```text
01,02,03,04,05,06
```

### Relacionamentos

* N:1 com Bolao

---

## Resultado

Representa o resultado oficial do sorteio.

### Campos

| Campo            | Tipo     |
| ---------------- | -------- |
| Id               | bigint   |
| BolaoId          | bigint   |
| NumerosSorteados | varchar  |
| DataResultado    | datetime |

### Exemplo

```text
01,02,03,04,05,06
```

### Relacionamentos

* N:1 com Bolao

---

# Diagrama Simplificado

```text
Modalidade
    │
    └───< Bolao
              │
              ├───< Jogo
              │
              ├───< Resultado
              │
              └───< BolaoParticipante >─── Participante
```

# Funcionalidades Implementadas

* Cadastro de modalidades
* Cadastro de bolões
* Cadastro de participantes
* Controle de cotas
* Controle de pagamentos
* Cadastro de jogos
* Cadastro de resultados
* Conferência automática de acertos
* Dashboard do bolão
* Rateio proporcional de prêmios

# Tecnologias Utilizadas

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* AutoMapper
* Swagger/OpenAPI
