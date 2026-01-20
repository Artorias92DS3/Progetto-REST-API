namespace RestApi.Core.Entities
{
    /// <summary>
    /// rappresenta il prodotto
    /// </summary>
    public class Prodotto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Prezzo { get; set; }
    }
}
