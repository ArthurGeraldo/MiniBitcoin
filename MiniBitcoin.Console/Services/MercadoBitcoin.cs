
namespace MiniBitcoin.ConsoleApp.Services;

public class MercadoBitcoin
{
    public decimal CotacaoAtual { get; private set; }

    public MercadoBitcoin(decimal cotacaoInicial)
    {
        if (cotacaoInicial <= 0)
            throw new ArgumentException("A cotação deve ser maior que zero.");

        CotacaoAtual = cotacaoInicial;
    }

    public void AtualizarCotacao(decimal novaCotacao)
    {
        if (novaCotacao <= 0)
            throw new ArgumentException("A cotação deve ser maior que zero.");

        CotacaoAtual = novaCotacao;
    }
}
