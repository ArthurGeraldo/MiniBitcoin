using MiniBitcoin.ConsoleApp.Models;

namespace MiniBitcoin.ConsoleApp.Services;

public class CarteiraService
{
    private readonly Carteira _carteira;
    private readonly MercadoBitcoin _mercado;

    public CarteiraService(Carteira carteira, MercadoBitcoin mercado)
    {
        _carteira = carteira;
        _mercado = mercado;
    }

    public decimal CalcularPatrimonioTotal()
    {
        return _carteira.SaldoBrl +
               (_carteira.SaldoBitcoin * _mercado.CotacaoAtual);
    }
}