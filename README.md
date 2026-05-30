# BolaoWebAPI

API REST desenvolvida em .NET para gerenciamento de bolões de loteria.

O projeto foi criado com foco em aprendizado de arquitetura de APIs utilizando ASP.NET Core, Entity Framework Core, SQL Server e AutoMapper, aplicando conceitos de modelagem de domínio, relacionamentos, regras de negócio e consultas consolidadas.

## Funcionalidades

### Modalidades

* Cadastro de modalidades de loteria
* Consulta de modalidades
* Alteração de modalidades
* Exclusão lógica

Exemplos:

* Mega-Sena
* Lotofácil
* Quina
* Lotomania
* Timemania

### Bolões

* Cadastro de bolões
* Alteração de bolões
* Exclusão lógica
* Consulta de bolões
* Resumo do bolão
* Dashboard do bolão

### Participantes

* Cadastro de participantes
* Alteração de participantes
* Exclusão lógica
* Consulta de participantes

### Participação em Bolões

* Vinculação de participantes ao bolão
* Controle de cotas
* Controle de pagamento
* Atualização da quantidade de cotas
* Remoção de participantes do bolão

### Jogos

* Cadastro de jogos
* Alteração de jogos
* Exclusão de jogos
* Consulta de jogos por bolão

### Resultados

* Cadastro de resultados de sorteios
* Consulta de resultados por bolão
* Exclusão de resultados

### Conferência de Jogos

* Conferência automática dos jogos cadastrados
* Identificação dos números acertados
* Quantidade de acertos por jogo
* Ordenação dos jogos por quantidade de acertos

### Rateio de Prêmios

* Cálculo automático de rateio
* Distribuição proporcional às cotas adquiridas
* Exibição do percentual de participação
* Cálculo individual do valor a receber

## Tecnologias Utilizadas

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* AutoMapper
* Swagger / OpenAPI

## Estrutura da Solução

BolaoWebAPI.Api

* Controllers
* Requests
* Responses
* Mappings

BolaoWebAPI.Domain

* Entities

BolaoWebAPI.Infrastructure

* DbContext
* Configurations
* Migrations

## Entidades Principais

* Modalidade
* Bolao
* Participante
* BolaoParticipante
* Jogo
* Resultado

## Conceitos Aplicados

* Entity Framework Core
* Migrations
* AutoMapper
* DTOs
* Relacionamentos
* Chaves estrangeiras
* Consultas agregadas
* Regras de negócio
* Dashboard
* Rateio proporcional
* Conferência automática de resultados

## Objetivo

Este projeto foi desenvolvido com fins educacionais para praticar conceitos utilizados em APIs corporativas modernas utilizando a plataforma .NET.
