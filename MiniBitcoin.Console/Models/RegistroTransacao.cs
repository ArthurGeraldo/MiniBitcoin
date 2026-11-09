namespace MiniBitcoin.ConsoleApp.Models;

public class RegistroTransacao
{
    public string Tipo { get; set; } = "";
    public decimal QuantidadeBitcoin { get; set; }
    public decimal ValorBrl { get; set; }
    public decimal Cotacao { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;
}