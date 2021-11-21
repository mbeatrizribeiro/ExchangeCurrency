# ExchangeCurrency

### Arquitetura de Projeto

O padrão de arquitetura escolhido para o desenvolvimento do projeto foi o **Model-View-Controller**, utilizando a estrutura [ASP.NET](http://ASP.NET) Core MVC.

A opção pelo padrão se deu por ser um pattern muito recomendado principalmente em aplicações web. Inclui características como separação entre os códigos, onde View e Controller gerenciam as relações entre camada Model e View.

A separação da lógica do negócio e a divisão de responsabilidades foram outras características que me levaram seguir este modelo.

Desta forma, respeitei os componentes principais de acordo como descrito em suas definições,  tanto o descrito por PRESSMAN (2011), quanto da própria documentação  [ASP.NET](http://ASP.NET) MVC da Microsoft, por Steve Smith, onde:

* A camada de dados, **Model,** tem como responsabilidade a representação de informações em que foram colocados modelos de request, response e enums de perfil.  

* A camada de visualização, **View**, responsável por disponibilizar a interface com o usuário do sistema e input de dados para o request. Utilizei HTML/CSS e Bootstrap para estilização das páginas.

* A camada de controle, **Controller**, responsável definir e interpretar as solicitações. Na ConvertCurrencyController por exemplo, o controller é responsável por solicitar a chamada do Mediador.

Como uma primeira versão, pode-se encontrar outras pastas no projeto. Iniciei neste viés para simplificar a criação, mas poderia ser dividido em outros projetos em uma segunda entrega, por exemplo. Assim, limpando a arquitetura e facilitando a visualização. 

No mais, as outras pastas encontradas são:

* **Handler**, possui a pasta de interface e a implementação do Handle, utilizado para garantir o Design Pattern de Comportamento Mediator.

* **Service**, contém a implementação da classe TaxPerProfile. Esta, tem como objetivo respeitar e executar a regra proposta pelo desafio, onde os perfis de usuário permitem parametrização de taxas distintas.

* **Integration**, que possui a interface para chamada da api ExchangeRate API. Foi escolhido o uso da biblioteca Refit.

### Principais Bibliotecas e Frameworks Utilizados

* **Refit**, foi a biblioteca escolhida para me auxiliar na comunicação com o serviço do ExchangeRate, para conseguir os valores das moedas atualmente. Desta forma, o projeto reduz redundância no código; suposto que em outra escolha, sem a biblioteca, utilizaria um objeto HttpClient, obteria a URL, realizaria a requisição e deserializar o objeto. Com o refit, o processo foi simplificado, apenas por sua definição de interface.

* **MediatR**, biblioteca utilizada para implementar o padrão de projeto comportamental Mediador. Utilizei-o para diminuição do acoplamento dos objetos, não sendo referidos um aos outros explicitamente. Toda comunicação entre os objetos são passadas pelo mediador.

* **XUnit**, framework para a criação de testes unitários, por ser mais flexível e abrangente. Por ter "nascido" a partir do NUnit possui muitas semelhanças, porém, ainda assim algumas diferenças me fizeram tomar esta decisão como por não ter a necessidade de retornar uma classe testável por exemplo, (utilizando [Facts], [Theory]), por exemplo.

* **NSubstitute**, biblioteca utilizada para criação dos moqs, a qual me auxiliou na escrita dos testes unitários, criação de objetos baseados em interface, e definição de contratos de retorno.

### Principais Design Patterns Utilizados

* **CQRS**, o Comand Query Responsability Segregation, utilizado com o auxilio do MediatR, separando a leitura e escrita, com base em queries e commands. Apesar de não utilizar nenhuma DTO neste projeto em específico, todas as consultas estão isoladas das implementações de serviço, passando pelo mediador para se comunicarem. 

* **Injeção de Dependência**, utilizado como uma técnica para alcançar o IoC (Inversão de Controle), entre as classes e suas dependências. (Microsoft, Injeção de Dependência no [ASP.NET](http://ASP.NET) CORE). Implementei este padrão no projeto tanto para facilitar os testes (códigos mais "testáveis"), quanto para me auxiliar a manter o princípio Dependency Inversion Principle, onde as dependências existentes no projeto vêm das abstrações, e não das implementações. Também o principio de Inversão de Dependência.
