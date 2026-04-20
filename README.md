# GestaoBancariaGrpc

Serviço gRPC de gestão bancária desenvolvido em ASP.NET Core, com Entity Framework Core e SQLite. Projeto desenvolvido como estudo de caso para comparação de desempenho entre REST e gRPC.

## Tecnologias

- .NET 8
- ASP.NET Core gRPC
- Entity Framework Core
- SQLite
- Protocol Buffers (Protobuf)

## Arquitetura

O projeto segue arquitetura em camadas, compartilhando as mesmas regras de negócio do projeto REST — apenas a camada de apresentação difere:

```
GestaoBancariaGrpc.sln
├── Apresentacao/   → GrpcService, arquivo .proto, configuração
├── Dominio/        → Regras de negócio (idêntico ao REST)
├── Entidades/      → Modelos e enums (idêntico ao REST)
└── Repositorio/    → Acesso a dados, migrations, DataContext
```

O contrato da API é definido em `Apresentacao/Protos/gestao_bancaria.proto`.

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [dotnet-ef](https://learn.microsoft.com/pt-br/ef/core/cli/dotnet)

```bash
dotnet tool install --global dotnet-ef --version 8.0.0
```

## Como rodar

**1. Clone o repositório**
```bash
git clone https://github.com/jeanvitorvieira/GestaoBancariaGrpc.git
cd GestaoBancariaGrpc
```

**2. Aplique as migrations**
```bash
dotnet ef database update --project Repositorio/Repositorio.csproj --startup-project Apresentacao/Apresentacao.csproj
```

**3. Rode a aplicação**
```bash
dotnet run --project Apresentacao/Apresentacao.csproj
```

O serviço sobe em `http://localhost:5001`.

## Métodos disponíveis

Definidos em `gestao_bancaria.proto`:

| Método | Descrição |
|--------|-----------|
| `Inserir` | Criar conta bancária |
| `BuscarContas` | Listar todas as contas |
| `BuscarContaPorId` | Buscar conta por ID |
| `BuscarExtrato` | Extrato completo com movimentos |
| `Deletar` | Deletar conta |
| `InserirMovimento` | Inserir movimento (Pix) |

## Testando com grpcurl

```bash
# Inserir conta
grpcurl -plaintext -d '{
  "titular": "Jean Vitor",
  "numero_conta": "12345",
  "tipo_conta": 0
}' localhost:5001 gestaobancaria.ContasBancariasGrpc/Inserir

# Listar contas
grpcurl -plaintext localhost:5001 gestaobancaria.ContasBancariasGrpc/BuscarContas

# Buscar extrato
grpcurl -plaintext -d '{"id": 1}' localhost:5001 gestaobancaria.ContasBancariasGrpc/BuscarExtrato
```

## Testes de carga

Os scripts de benchmark estão na pasta `Benchmarks/` e utilizam [k6](https://k6.io).

```bash
# Popular o banco com 1.000 movimentos
k6 run Benchmarks/grpc_seed_movimentos.js

# Testar listagem de contas
k6 run Benchmarks/grpc_contas.js

# Testar extrato (payload pesado)
k6 run Benchmarks/grpc_extrato.js
```

## Artigo

Este projeto é parte de um estudo comparativo entre REST e gRPC publicado no Dev.to:

[Análise acerca do Framework gRPC: Comparações e Desempenhos](https://dev.to/jeanvitorvieira/analise-acerca-do-framework-grpc-google-remote-procedure-call-comparacoes-e-desempenhos-5amd)

O projeto REST equivalente está disponível em [GestaoBancariaRest](https://github.com/jeanvitorvieira/GestaoBancariaRest).

## Autores

- Bruno de Moraes Supriano
- Jean Vitor Vieira

Centro Universitário SATC — Engenharia de Software — 2026
