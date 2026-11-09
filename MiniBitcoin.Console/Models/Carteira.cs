
namespace MiniBitcoin.ConsoleApp.Models;

public class Carteira
{
    public decimal SaldoBrl { get; private set; }
    public decimal SaldoBitcoin { get; private set; }

    public Carteira(decimal saldoBrl, decimal saldoBitcoin)
    {
        if (saldoBrl < 0 || saldoBitcoin < 0)
            throw new ArgumentException("Os saldos não podem ser negativos.");

        SaldoBrl = saldoBrl;
        SaldoBitcoin = saldoBitcoin;
    }

    public void SacarBrl(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor deve ser positivo.");

        if (valor > SaldoBrl)
            throw new InvalidOperationException("Saldo insuficiente.");

        SaldoBrl -= valor;
    }

    public void SacarBitcoin(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor deve ser positivo.");

        if (valor > SaldoBitcoin)
            throw new InvalidOperationException("Saldo insuficiente.");

        SaldoBitcoin -= valor;
    }

    public void DepositarBrl(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor deve ser positivo.");

        SaldoBrl += valor;
    }

    public void DepositarBitcoin(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor deve ser positivo.");

        SaldoBitcoin += valor;
    }
}
