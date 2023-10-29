# Visão geral do Omnichannel

Este sistema foi desenvolvido seguindo princípios de microserviços, utilizando mensageria e cache distribuído.

**Como executar o projeto por linha de comando**
+ O projeto foi configurado para ser executado apenas clicando no botão verde do Visual Studio Community 2022.
+ Para executar os testes de unidade, o usuário pode utilizar o Test Explorer do Visual Studio Community 2022.
+ O sistema utiliza containêres para montar seu ambiente, então o mais recomendado é utilizar a estrutura já pronta que se encontra na pasta `3 - Container Orchestration`.

Comando:
 ```
 docker-compose up
```

**Interface de utilização**

No projeto há a disposição um JSON referente a uma collection de postman e cada api do projeto também contém swagger configurado.
+ Arquivo Postman: [Omnichannel Collection](https://github.com/devhenriq/Omnichannel/blob/master/Omnichannel.postman_collection.json "Omnichannel Collection")

------------
## Documentação
##### Diagrama de contexto
![Context](https://github.com/devhenriq/Omnichannel/blob/master/Documentation/Context.png "Context")

##### Diagrama de container
![Container](https://github.com/devhenriq/Omnichannel/blob/master/Documentation/Container.png "Container")

##### Diagrama de componentes
![Component](https://github.com/devhenriq/Omnichannel/blob/master/Documentation/Component.png "Component")

------------

## Informações adicionais:
* Utiliza .NET 7.
* XUnit utilizado como framework de testes.
* Swagger configurado.
* Utiliza Redis.
* Utiliza PostgreSQL.
