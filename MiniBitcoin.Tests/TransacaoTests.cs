using MiniBitcoin.ConsoleApp.Models;
using MiniBitcoin.ConsoleApp.Services;
using Xunit;

namespace MiniBitcoin.Tests;

public class TransacaoTests
{
    [Fact]
    public void ComprarBitcoin_DeveAtualizarSaldos()
    {
        var carteira = new Carteira(1000, 0);
        var mercado = new MercadoBitcoin(100000);
        var servico = new TransacaoService(carteira, mercado);

        servico.ComprarBitcoin(500);

        Assert.Equal(500, carteira.SaldoBrl);
        Assert.Equal(0.005m, carteira.SaldoBitcoin);
    }

    [Fact]
    public void ComprarBitcoin_NaoDevePermitirSaldoInsuficiente()
    {
        var carteira = new Carteira(100, 0);
        var mercado = new MercadoBitcoin(100000);
        var servico = new TransacaoService(carteira, mercado);

        Assert.Throws<InvalidOperationException>(
            () => servico.ComprarBitcoin(200));
    }

    [Fact]
    public void VenderBitcoin_DeveAtualizarSaldos()
    {
        var carteira = new Carteira(0, 0.01m);
        var mercado = new MercadoBitcoin(100000);
        var servico = new TransacaoService(carteira, mercado);

        servico.VenderBitcoin(0.005m);

        Assert.Equal(500m, carteira.SaldoBrl);
        Assert.Equal(0.005m, carteira.SaldoBitcoin);
    }

    [Fact]
    public void VenderBitcoin_NaoDevePermitirSaldoInsuficiente()
    {
        var carteira = new Carteira(0, 0.001m);
        var mercado = new MercadoBitcoin(100000);
        var servico = new TransacaoService(carteira, mercado);

        Assert.Throws<InvalidOperationException>(
            () => servico.VenderBitcoin(0.005m));
    }
}