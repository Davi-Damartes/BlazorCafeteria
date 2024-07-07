
# Loja Sonho de Café é um E-commerce Simplificado de uma Cafeteria.

Este projeto é uma aplicação de e-commerce simplificada desenvolvida com Blazor web app, utilizando EF Core e um banco de dados SQL Server. A aplicação inclui componentes modernos como QuickGrid para exibição de dados e Blazored. LocalStorage para armazenamento local. A API web subjacente, construída com ASP.NET Core, permite operações CRUD completas refletindo diretamente no banco de dados, enquanto a biblioteca CsvHelper facilita a exportação de dados csv.

## Funcionalidades

- Catálogo de Produtos: Navegação e exibição de produtos por categoria com opções de ordenação e paginação.
- Detalhes dos Produtos: Visualização detalhada de cada produto, incluindo descrição e foto.
- Promoções: Carousel dinâmico exibindo produtos em promoção.
- Gerenciamento de Produtos: Cadastro incluindo a opção de colocar imagem com validação de tamanho, reabastecimento, favoritamento e exclusão de produtos com validação de campos.
- Carrinho de Compras: Adição, remoção e ajuste de quantidade de itens no carrinho.
- Simulador de Pagamento: Processamento de compras com opções de pagamento via cartão, boleto ou dinheiro, refletindo na quantidade de estoque. Além de realizar a busca de endereço por CEP através de uma API externa.
- Local Storage para armazenamento de informações no Browser do Cliente.
- Controle de Funcionamento: Restrições de pagamento fora do horário de funcionamento da loja.
- Relatório de Faturamento: Tabela de faturamento mensal com opção de download em formato do Excel (.csv).  

## Testes Unitários com xUnit
- Utilizando uma variedade de ferramentas e técnicas para garantir a qualidade do código:
 
- Repositório: Implementação de testes para validar as operações de persistência de dados, simulando o comportamento do banco de dados com um banco em memória.
- Serviço com Chamada HTTP: Desenvolvendo testes para verificar a integração adequada com serviços externos (Api), utilizando simulações de chamadas HTTP com Mocks.
- Controlador: Testando as rotas e ações do controlador, verificando os diferentes resultados HTTP (200, 201, 400, 404, 500) para garantir o comportamento correto da API. 


 🔗Bibliotecas utilizadas: FluentAssertions, Mock, AutoFixture, FakeItEasy e Banco em Memória (Microsoft.EntityFrameworkCore.InMemory). 

## Demonstração

- Listagem dos Produtos
 
https://github.com/Davi-Damartes/BlazorCafeteria/assets/167019873/c5932993-70c8-454b-91dc-f8a61014eb02


- Produtos Separados pela Categoria.
  
https://github.com/Davi-Damartes/BlazorCafeteria/assets/167019873/394a505c-e4e8-4a66-b8fd-f54f48074ce0

- Produtos Favoritos

  https://github.com/Davi-Damartes/BlazorCafeteria/assets/167019873/ad764168-95ce-45e1-bfd5-4c0e29995456


- Simulação de Pagamento.

https://github.com/Davi-Damartes/BlazorCafeteria/assets/167019873/2fabb9d2-0787-4387-8310-63575fe0c892

- Reabastecendo Produto

  https://github.com/Davi-Damartes/BlazorCafeteria/assets/167019873/3e3e94a2-da82-47e9-96ce-31a780667a7f

- Download faturamento:

https://github.com/Davi-Damartes/BlazorCafeteria/assets/167019873/f9e40ecb-4fe8-4d50-b622-ca84db7e9c76


## Autor
- [@Davi-Damartes](https://www.github.com/octokatherine)

## Referência

 - [Referência do projeto feito no canal do Jose Macoratti.](https://www.youtube.com/watch?v=lQaXpJFxbxM&list=PLJ4k1IC8GhW1GFJbYD2uo-_pLfdvX6Pu9)


## 🔗 Links
[![portfolio](https://img.shields.io/badge/my_portfolio-000?style=for-the-badge&logo=ko-fi&logoColor=white)](https://github.com/Davi-Damartes?tab=repositories)
[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/davi-lima-643870313/)

## Rodando localmente

Clone o projeto

```bash
  git clone https://link-para-o-projeto
```

Entre no diretório do projeto

```bash
  cd my-project
```

Instale as dependências
```bash
  dotnet add package "Nomes.Dos.Pacotes"
```

Faça a criação do Banco de Dados:

```bash
  Add-migration "NomeMigration" -Context NomeDoSeuDB
```

Inicie o blazor server juntamente com a Api e rode o comando: 

```bash
  Dotnet watch run
```
ou através da tecla de Depuração: 

```bash
  F5
```

