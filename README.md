# [FIAP - Pos Tech] Fast Food

FIAP Pos Tech - SOFTWARE ARCHITECTURE

SOAP2 - Grupo 7

#### Sumário
   * [O projeto](#o-projeto)
   * [Documentações](#documentações)
   * [Pré-requisitos](#pré-requisitos)
   * [Como rodar a aplicação <g-emoji class="g-emoji" alias="arrow_forward" fallback-src="https://github.githubassets.com/images/icons/emoji/unicode/25b6.png">▶️</g-emoji>](#como-rodar-a-aplicação-️)
   * [Tecnologias](#tecnologias)
   * [Arquitetura e Padrões](#arquitetura-e-padrões)
   * [Estrutura da solução](#estrutura-da-solução)
   * [Desenvolvedores <img class="emoji" title=":octocat:" alt=":octocat:" src="https://github.githubassets.com/images/icons/emoji/octocat.png" height="20" width="20" align="absmiddle">](#desenvolvedores-octocat)

## O projeto

O projeto consiste em um sistema de autoatendimento de fast food, que é composto por uma série de dispositivos e interfaces que permitem aos clientes selecionar e fazer pedidos sem precisar interagir com um atendente. 

No projeto atual temos as seguintes funcionalidades:
- Cadastro do Cliente
- Identificação do Cliente via CPF
- Criar, editar e remover de produto
- Buscar produtos por categoria
- Checkout do pedido com retorno dos dados de acompanhamento e pagamento
- Atualizar situação dos pedidos
- Listar os pedidos ativos
- Solicitação de exclusão dos dados pessoais do cliente (LGPD)

## Documentações

A imagem a seguir documenta o sistema utilizando a linguagem ubíqua, dos seguintes fluxos:
- Realização do pedido e pagamento
- Preparação e entrega do pedido

![Projeto](./docs/DDD.png)


- Miro do DDD: https://miro.com/app/board/uXjVMI-wOLc=/?share_link_id=8789531868

- Diagrama de Classes (necessita ser aberto no [Draw.io](https://www.drawio.com/)): (https://github.com/grupo-7-fastfood-pos-soat-fiap/fastfood-api/blob/main/docs/ProjetoGrupo7_v2.drawio)

- Relatório RIPD do sistema: (https://github.com/grupo-7-fastfood-pos-soat-fiap/fastfood-api/blob/main/docs/RIPD-FastFoodFIAP.pdf)

## Pré-requisitos

- SDK do .NET 7.0: Baixe em https://dotnet.microsoft.com/pt-br/download/dotnet/7.0.
- Docker: https://docs.docker.com/engine/install/

- IDE de sua preferência: pode ser executado com o Visual Studio Code (Windows, Linux or MacOS).


## Como rodar a aplicação localmente ▶️

1. Suba os containers (aplicação e banco de dados) utilizando o docker compose

   `docker-compose up -d`

2. Teste o sistema através do swagger:

   http://localhost:8000/swagger/index.html

## Como rodar a aplicação na nuvem

1. Consulte o repositório Terraform-Infra:

   https://github.com/grupo-7-fastfood-pos-soat-fiap/terraform-infra

## Tecnologias

- Runtime do .NET 7.0.5
    - Suporte para o Visual Studio
        - Visual Studio 2022 (v17.6)
        - Visual Studio 2022 for Mac (v17.6)
    - C# 11.0
    - ASP.NET WebApi
    - Entity Framework
    - AutoMapper
    - Swagger UI
- PostgreSQL 
- Docker

## Arquitetura e Padrões

![Arquitetura](./docs/CleanArchitecture.png)

- Arquitetura Limpa (Clean Architecture)
- Domain Driven Design (DDD)
- Domain Events
- CQRS
- Unit of Work
- Repository
- Saga Pattern

## Justificativa para adoção do padrão Saga coreografado

Como sistema adotou inicialmente o padrão CQRS com fornecimento de eventos e, sabendo que, no padrão Saga Coreografado, cada microsserviço é responsável por gerar as ações subsequentes necessárias, o padrão Saga coreografado foi o escolhido, pois atende perfeitamente, em virtude da baixa complexidade e da pouco quantidade de etapas necessárias para manutenção da consistência entre os microsserviços.  No sistema da lanchonete, o microsserviço de produção que controla o andamento dos pedidos, será o responsável por receber as mensagens da fila, provenientes dos eventos dos demais serviços. Como um evento só é disparado após a garantia de registro do comando que o gerou, a orquestração traria uma complexidade desnecessária para a aplicação, uma vez que, quase todos os andamentos dos pedidos são realizados por interação dos usuários, não havendo a necessidade de uma orquestração centralizada com visão global do fluxo de trabalho. Sendo assim, consideramos as seguintes características do padrão Saga coreografado para adota-lo:

- O fluxo de trabalho distribuído e descentralizado, sem um ponto central de controle.
- Cada serviço sabe como reagir a eventos específicos e como iniciar ações subsequentes.


## Estrutura da solução

![Projeto](./docs/Projeto.png) 


## Desenvolvedores :octocat:

| [<img src="https://avatars.githubusercontent.com/u/62022498?v=4" width=115><br><sub>Wellerson Willon Reis</sub>](https://github.com/brwillon) | [<img src="https://avatars.githubusercontent.com/u/15663232?v=4" width=115><br><sub>Ana Luisa Bavati</sub>](https://github.com/analuisabavati) |  [<img src="https://avatars.githubusercontent.com/u/67171626?v=4" width=115><br><sub>Luis Fernando</sub>](https://github.com/luisfernandodass) |
| :---: | :---: | :---:
