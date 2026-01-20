namespace RestApi.Core.Models
{
    public class RisultatoPaginato<T>
    {
        public List<T> Elementi { get; set; } = new();
        public int NumeroPagina { get; set; }
        public int DimensionePagina { get; set; }
        public int TotaleElementi { get; set; }
        public int TotalePagine { get; set; }
        public bool HaPrecedente => NumeroPagina > 1;
        public bool HaSuccessivo => NumeroPagina < TotalePagine;
    }
}
