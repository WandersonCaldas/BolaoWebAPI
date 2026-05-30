# 🎲 BolaoWebAPI

API REST desenvolvida em .NET 8 para gerenciamento de bolões de loteria.

O projeto foi criado com foco em aprendizado de arquitetura de APIs utilizando ASP.NET Core, Entity Framework Core, SQL Server e AutoMapper, aplicando conceitos de modelagem de domínio, relacionamentos, regras de negócio e consultas consolidadas.

## 🚀 Funcionalidades

* Cadastro de Modalidades
* Cadastro de Bolões
* Cadastro de Participantes
* Controle de Cotas
* Controle de Pagamentos
* Cadastro de Jogos
* Cadastro de Resultados
* Conferência Automática de Acertos
* Dashboard do Bolão
* Rateio Proporcional de Prêmios

## 🛠 Tecnologias

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* AutoMapper
* Swagger / OpenAPI

## 📁 Estrutura da Solução

```text
BolaoWebAPI.Api
├── Controllers
├── Requests
├── Responses
└── Mappings

BolaoWebAPI.Domain
└── Entities

BolaoWebAPI.Infrastructure
├── Data
├── Configurations
└── Migrations
```

## 📊 Principais Entidades

* Modalidade
* Bolao
* Participante
* BolaoParticipante
* Jogo
* Resultado

## 📈 Funcionalidades de Negócio

### Dashboard

Permite visualizar informações consolidadas do bolão:

* Participantes
* Jogos cadastrados
* Cotas vendidas
* Cotas disponíveis
* Valor arrecadado
* Valor recebido
* Valor pendente

### Conferência de Jogos

Realiza a conferência automática dos jogos cadastrados com o resultado informado.

Exemplo:

```json
{
  "jogoId": 1,
  "quantidadeAcertos": 5,
  "numerosAcertados": [
    "01",
    "02",
    "03",
    "04",
    "05"
  ]
}
```

### Rateio de Prêmios

Calcula automaticamente a distribuição do prêmio com base na quantidade de cotas de cada participante.

Exemplo:

```json
{
  "nomeParticipante": "João",
  "quantidadeCotas": 5,
  "percentualParticipacao": 50,
  "valorPremio": 50000
}
```

## 📚 Documentação

Documentação complementar disponível em:

* [Modelo de Dados](docs/modelo-banco.md)

## 🎯 Objetivo

Este projeto foi desenvolvido para fins de estudo e prática de desenvolvimento de APIs REST utilizando .NET, Entity Framework Core e SQL Server, simulando cenários comuns encontrados em sistemas corporativos.
