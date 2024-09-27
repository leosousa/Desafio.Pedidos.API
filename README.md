# Pedidos.API
API de gerenciamento de pedidos e produtos utilizando o .Net 8.

## Tecnologias utilizadas
- .Net Core 8
- Entity Framework Core 8
- MediatR
- FluentValidation
- CQRS
- Sql Server
- DDD
- Docker

## Arquitetura
### API
- Camada de exposição das rotas de API disponíveis.

### Domain (Domínio)
- Camada de domínio e coração do sistema, contendo os casos de uso do sistemaas, entidades e interfaces de comunicação com outras camadas.

### Infra (Infraestrutura)
- Camada de infra que provê recursos utilizados pelo sistema, tais como a comunicação com o banco de dados.

## Primeiros passos

### Requisitos para rodar a aplicação
Para rodar a aplicação precisa dos seguintes requisitos instalados na máquina
- SDK do .Net Core 8
- Docker

#### Rodando a aplicação
Siga os passos abaixo para rodar a aplicação com o Docker

1. Rodando a aplicação via Docker
Abra um terminal, acesse a pasta raiz onde está a  solution e rode o comando abaixo:
```
docker-compose up
```

2. Acesse a url localmente
Acesse ```http://localhost:8081/swagger/index.html```

## Ajustes futuros
- Remoção de duplicação de código e abstração das ações de repositório
- Adição de testes unitários
- Criação de projeto frontend para consumo da aplicação
- Deixar rodando em uma cloud