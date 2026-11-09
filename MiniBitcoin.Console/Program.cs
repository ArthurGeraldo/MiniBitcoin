using MiniBitcoin.ConsoleApp.Models;
using MiniBitcoin.ConsoleApp.Services;

var carteira = new Carteira(10000, 0);
var mercado = new MercadoBitcoin(350000);
var transacoes = new TransacaoService(carteira, mercado);
var carteiraService = new CarteiraService(carteira, mercado);

bool executando = true;

while (executando)
{
    Console.Clear();

    Console.WriteLine("==========================");
    Console.WriteLine("       MINIBITCOIN");
    Console.WriteLine("==========================");
    Console.WriteLine("1 - Consultar cotação");
    Console.WriteLine("2 - Consultar carteira");
    Console.WriteLine("3 - Comprar Bitcoin");
    Console.WriteLine("4 - Vender Bitcoin");
    Console.WriteLine("5 - Histórico de transações");
    Console.WriteLine("6 - Consultar patrimônio total");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("==========================");
    Console.Write("Escolha: ");

    string? opcao = Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1":
                Console.WriteLine($"Cotação atual: R$ {mercado.CotacaoAtual:N2}");
                break;

            case "2":
                Console.WriteLine($"Saldo em reais: R$ {carteira.SaldoBrl:N2}");
                Console.WriteLine($"Saldo em Bitcoin: {carteira.SaldoBitcoin:N8} BTC");
                break;

            case "3":
                Console.Write("Valor em reais para comprar: ");
                decimal compra = decimal.Parse(Console.ReadLine()!);
                transacoes.ComprarBitcoin(compra);
                Console.WriteLine("Compra realizada!");
                break;

            case "4":
                Console.Write("Quantidade de Bitcoin para vender: ");
                decimal venda = decimal.Parse(Console.ReadLine()!);
                transacoes.VenderBitcoin(venda);
                Console.WriteLine("Venda realizada!");
                break;

            case "5":
                foreach (var item in transacoes.Historico)
                {
                    Console.WriteLine(
                        $"{item.Data:g} | {item.Tipo} | " +
                        $"{item.QuantidadeBitcoin:N8} BTC | " +
                        $"R$ {item.ValorBrl:N2}");
                }
                break;

            case "6":
                Console.WriteLine(
                    $"Patrimônio total: R$ {carteiraService.CalcularPatrimonioTotal():N2}");
                break;

            case "0":
                executando = false;
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    catch (Exception erro)
    {
        Console.WriteLine($"Erro: {erro.Message}");
    }

    if (executando)
    {
        Console.WriteLine("\nPressione ENTER para continuar...");
        Console.ReadLine();
    }
}

Console.WriteLine("Obrigado por usar o MiniBitcoin!");