### Projeto
**Desenvolvido por:** Fernando José <br />
**Descrição:** <br />
Projeto desenvolvido para atuar como processador de pagamentos. A ideia é receber uma solicitação de pagamento por meio de uma API Rest, que será publicada no SQS para que um consumidor possa processar o pagamento e aplicar as regras de negócio correspondentes.

O desafio principal é criar um mecanismo de regras de negócio dinâmico, pois as regras tendem a mudar com frequência. O objetivo é minimizar ou eliminar completamente a necessidade de alterações no sistema para aplicar e implementar novas regras. Inicialmente, considerei a utilização de um arquivo JSON para armazenar todas as regras de negócio, com a possibilidade de, no futuro, permitir que os usuários criem e modifiquem essas regras por meio de um sistema próprio.

Embora a primeira abordagem seja utilizar um arquivo JSON, estou aberto a considerar outras opções, como armazenar as regras em um banco de dados relacional ou não relacional, dependendo da evolução e das necessidades do projeto. Para isso, é necessário um refinamento adicional e uma compreensão mais profunda do problema em colaboração com todas as partes envolvidas no projeto.

### Padrões e Tecnologias utilizadas
#### Padrões
- DDD
- CQRS
- API Rest
- Pattern Strategy
- Pattern Decorate (implementação futura)
- Pattern Repository 

#### BackEnd
- .Net 8
- Lambda Function
- Swagger
- EF Core
- SQS
- IoC
- C#

#### Testes de Unidade e Testes Integrados
- XUnit
- Moq
- Bogus (faker)
- Selenium (implementação futura)

#### Banco de dados
- SQL Server

### Configuração Inicial
Configuração necessária antes de iniciar

#### SqlServer
- Criar um banco de dados a sua escolha (usei CleanArchCqrs)
- Executar o comando "update-database"

#### BackEnd
- Alterar a connection string no arquivo appsettings.json com a conn que estiver usando

### Configuração
#### Pré requisitos
- .Net 8
- Sql Server

#### BackEnd Api
- Abrir Terminal
- Acessar a pasta onde está o projeto
- Acessar a pasta .\Src\CleanArchCqrs.Api
- dotnet restore
- dotnet build
- dotnet run

#### Testes de Unidade
- Abrir Terminal
- Acessar a pasta onde está o projeto
- Acessar a pasta .\Src\CleanArchCqrs.UnitTest
- dotnet restore
- dotnet build
- dotnet test

### Desenhos do fluxo da API e do Consumer (Lambda Function)
![Fluxo - Api - Gravar uma intenção de pagamento](https://github.com/fernandogjose/CleanArchCqrs/blob/main/Files/Architecture/api-gravar-inten%C3%A7%C3%A3o-de-pagamento.jpg)
![Fluxo - Api - Consultar o resultado do processamento do pagamento](https://github.com/fernandogjose/CleanArchCqrs/blob/main/Files/Architecture/api-consultar-o-resultado-do-pagamento-da-api.jpg)
![Fluxo - Consumer - Processar as regras de negócio e o pagamento](https://github.com/fernandogjose/CleanArchCqrs/blob/main/Files/Architecture/consumer-processar-o-pagamento.jpg)

### Desenho da arquitetura da solução
![Arquitetura da solução](https://github.com/fernandogjose/CleanArchCqrs/blob/main/Files/Architecture/arquitetura-de-solucao.jpg)