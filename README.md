# MiniBitcoin

Sistema de simulação de uma carteira de Bitcoin desenvolvido em C# com .NET 10, como atividade da disciplina de Gestão e Qualidade de Software.

## Funcionalidades

- Consulta da cotação simulada do Bitcoin.
- Consulta do saldo em reais e Bitcoin.
- Compra de Bitcoin utilizando saldo em reais.
- Venda de Bitcoin para conversão em reais.
- Histórico de transações realizadas.
- Cálculo do patrimônio total da carteira.
- Validação para impedir saldos negativos e operações sem saldo suficiente.

## Tecnologias utilizadas

- C#
- .NET 10
- xUnit
- Git e GitHub

## Estrutura do projeto

```text
MiniBitcoin/
├── MiniBitcoin.Console/
│   ├── Models/
│   │   ├── Carteira.cs
│   │   └── RegistroTransacao.cs
│   ├── Services/
│   │   ├── CarteiraService.cs
│   │   ├── MercadoBitcoin.cs
│   │   └── TransacaoService.cs
│   └── Program.cs
├── MiniBitcoin.Tests/
│   ├── UnitTest1.cs
│   └── TransacaoTests.cs
├── .gitignore
├── MiniBitcoin.sln
└── README.md
```

## Como executar

É necessário ter o SDK do .NET 10 instalado.

Clone o repositório:

```bash
git clone URL_DO_REPOSITORIO
```

Entre na pasta:

```bash
cd MiniBitcoin
```

Execute o projeto:

```bash
dotnet run --project MiniBitcoin.Console
```

## Executar os testes

Para executar os testes automatizados:

```bash
dotnet test
```

Os testes verificam as regras da carteira, incluindo validação de saldos, compra e venda de Bitcoin.

## Observações

A cotação utilizada é simulada e definida inicialmente no código. O sistema não realiza operações financeiras reais.

---

Desenvolvido por **Arthur Geraldo Santos Silva**
RA: **4251924719**