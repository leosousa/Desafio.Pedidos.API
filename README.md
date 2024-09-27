# Pedidos.API
API de gerenciamento de pedidos e produtos utilizando o .Net 8 como parte de uma entrevista

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
- Camada de exposi��o das rotas de API dispon�veis.

### Domain (Dom�nio)
- Camada de dom�nio e cora��o do sistema, contendo os casos de uso do sistemaas, entidades e interfaces de comunica��o com outras camadas.

### Infra (Infraestrutura)
- Camada de infra que prov� recursos utilizados pelo sistema, tais como a comunica��o com o banco de dados.

## Primeiros passos

### Requisitos para rodar a aplica��o
Para rodar a aplica��o precisa dos seguintes requisitos instalados na m�quina
- SDK do .Net Core 8
- Docker

#### Rodando a aplica��o
Siga os passos abaixo para rodar a aplica��o com o Docker

1. Rodando a aplica��o via Docker
Abra um terminal, acesse a pasta raiz onde est� a  solution e rode o comando abaixo:
```
docker-compose up
```

2. Acesse a url localmente
Acesse ```http://localhost:8081/swagger/index.html```

## Ajustes futuros
- Remo��o de duplica��o de c�digo e abstra��o das a��es de reposit�rio
- Adi��o de testes unit�rios
- Cria��o de projeto frontend para consumo da aplica��o
- Deixar rodando em uma cloud