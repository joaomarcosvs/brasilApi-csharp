# brasilApiCS

Um cliente em C# para consumir dados da BrasilApi de forma simples e eficiente.

## O que é
Um aplicativo console em C# (.NET 9.0) que consulta endpoints públicos da BrasilApi para obter informações como CEP, CNPJ, CPF, euf?

## Estrutura

├── Controllers/ — lógica de orquestração entre entrada e serviços

├── Dtos/ — classes de transferência de dados (requests/responses)

├── Interfaces/ — contratos para abstração de serviços

├── Mappings/ — conversores automáticos (ex: AutoMapper)

├── Models/ — modelos de dados usados internamente

├── Services/ — implementações de chamadas à API BrasilApi

├── Rest/ — classes responsáveis por requisições HTTP

├── Properties/ — arquivos de configuração do projeto

├── IntegraBrasilApi.csproj

├── Program.cs — ponto de entrada do programa

├── appsettings.json / appsettings.Development.json — configurações de ambiente

└── IntegraBrasilApi.http — exemplos ou testes de chamadas HTTP

## Requisitos
- .NET SDK 9.0 ou superior
- Acesso à internet para consumar a BrasilApi

## Como usar
1. Clone este repositório:
   ```bash
   git clone https://github.com/joaomarcosvs/brasilApiCS.git
   cd brasilApiCS
2. Restaurar dependências:
   ```bash
   dotnet restore
3. Compile e execute:
   ```bash
   dotnet run

##  Explicação

### 1. Visão geral
O `brasilApiCS` é uma aplicação console bem estruturada escrita em C# no .NET 9.0. Ela faz requisições à BrasilApi (serviço REST público no Brasil) para obter dados — tipo CEP, CNPJ, CPF etc.

### 2. Padrão de arquitetura e organização das pastas

- **Controllers**: são as pontes — recebem ordem de execução e controlam qual serviço deve ser chamado.
- **Interfaces**: definem os contratos, deixando o código modular e testável com inversion-of-control (IoC).
- **Services**: concentram a lógica da chamada à API e tratativa das respostas.
- **Rest**: isolam a comunicação HTTP, normalmente via `HttpClient` ou algo similar.
- **Dtos**: formatam dados que vão e vêm da API — requests e responses.
- **Models**: usados internamente pela aplicação, separados dos Dtos.
- **Mappings**: automatizam transformações entre Dto e Model (facilitando reutilização e manutenção).
- **Properties / appsettings**: armazenam configurações, como URLs, timeouts, chaves (se houver).

### 3. Fluxo de execução (pipeline)
1. O `Program.cs` inicia.
2. `Controller` recebe a ação (por exemplo, “consulta um CEP”).
3. `Controller` chama o `Service` correspondente.
4. `Service` usa o componente de `Rest` para enviar requisição HTTP.
5. A resposta JSON chega e vira `Dto`.
6. `Dto` é convertido em `Model` por meio do `Mapping`.
7. O resultado chega ao `Controller`, que exibe ou processa como quiser.

### 4. Para que serve cada componente
- **Controller**: orquestra e atua como fachada para o uso pelo usuário.
- **Interface**: garante flexibilidade — você pode trocar implementações (mock, real, teste).
- **Service**: regras de consumo da API, tratamento de dados, logs de erros, etc.
- **Rest**: execução de requisição HTTP pura, separado do resto para facilitar testes.
- **Dto**: espelham exatamente as estruturas JSON da API.
- **Models**: estrutura interna limpa, sua lógica não fica dependente da BrasilApi.
- **Mappings**: evitam copiar/cortar colar — transformações limpas e centralizadas.
- **appsettings.json**: configura sua aplicação sem tocar no código — ótimo para diferentes ambientes.
- **IntegraBrasilApi.http**: um catálogo rápido de requisições via HTTP (talvez usado durante testes via VS Code REST client).

### 5. Como estender
- Crie um `IDto` e `IModel` para novo endpoint.
- Crie um serviço (`INomeService` + `NomeService`) que implemente a lógica de chamada.
- Adicione um método no `Controller` para chamar seu novo serviço.
- Certifique-se de ajustar `Mappings` e `Rest` se necessário.
- Configurar em `Program.cs` para ser executado ou testado.

### 6. Vantagens
- **Manutenção**: código limpo e organizado por função.
- **Testabilidade**: com `Interfaces`, mocks são triviais.
- **Extensão**: da próxima vez que a BrasilApi liberar um endpoint, você só replica o padrão.
- **Desacoplamento**: sua lógica de negócio não está misturada com detalhes do protocolo HTTP ou da API.
