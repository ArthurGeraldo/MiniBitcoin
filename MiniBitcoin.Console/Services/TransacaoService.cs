using System.Collections.Generic;
using MiniBitcoin.ConsoleApp.Models;

namespace MiniBitcoin.ConsoleApp.Services;

public class TransacaoService
{
    private readonly Carteira _carteira;
    private readonly MercadoBitcoin _mercado;

    public TransacaoService(Carteira carteira, MercadoBitcoin mercado)
    {
        _carteira = carteira;
        _mercado = mercado;
    }

    public void ComprarBitcoin(decimal valorBrl)
    {
        if (valorBrl <= 0)
            throw new ArgumentException("Valor inválido.");

        if (valorBrl > _carteira.SaldoBrl)
            throw new InvalidOperationException("Saldo em reais insuficiente.");

        decimal quantidadeBitcoin = valorBrl / _mercado.CotacaoAtual;

        _carteira.SacarBrl(valorBrl);
        _carteira.DepositarBitcoin(quantidadeBitcoin);

        _historico.Add(new RegistroTransacao
        {
        Tipo = "Compra",
        QuantidadeBitcoin = quantidadeBitcoin,
        ValorBrl = valorBrl,
        Cotacao = _mercado.CotacaoAtual
        });
    }

    public void VenderBitcoin(decimal quantidadeBitcoin)
    {
        if (quantidadeBitcoin <= 0)
            throw new ArgumentException("Quantidade inválida.");

        if (quantidadeBitcoin > _carteira.SaldoBitcoin)
            throw new InvalidOperationException("Saldo em Bitcoin insuficiente.");

        decimal valorBrl = quantidadeBitcoin * _mercado.CotacaoAtual;

        _carteira.SacarBitcoin(quantidadeBitcoin);
        _carteira.DepositarBrl(valorBrl);

        _historico.Add(new RegistroTransacao
        {
            Tipo = "Venda",
            QuantidadeBitcoin = quantidadeBitcoin,
            ValorBrl = valorBrl,
            Cotacao = _mercado.CotacaoAtual
        });
    }
    private readonly List<RegistroTransacao> _historico = new();

    public IReadOnlyList<RegistroTransacao> Historico => _historico;
}
