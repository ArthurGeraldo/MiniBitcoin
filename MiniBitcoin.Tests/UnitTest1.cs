//
using MiniBitcoin.ConsoleApp.Models;
using Xunit;

namespace MiniBitcoin.Tests;

public class UnitTest1
{
    [Fact]
    public void Carteira_NaoDeveIniciarComSaldoNegativo()
    {
        Assert.Throws<ArgumentException>(() => new Carteira(-100, 0));
    }

    [Fact]
    public void Carteira_DeveIniciarComSaldoValido()
    {
        var carteira = new Carteira(1000, 0);

        Assert.Equal(1000, carteira.SaldoBrl);
        Assert.Equal(0, carteira.SaldoBitcoin);
    }

    [Fact]
    public void Carteira_NaoDevePermitirSaqueMaiorQueSaldo()
    {
    var carteira = new Carteira(100, 0);

    Assert.Throws<InvalidOperationException>(() => carteira.SacarBrl(200));
    }
}
