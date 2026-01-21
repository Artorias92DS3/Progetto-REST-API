using System.ComponentModel.DataAnnotations;

namespace RestApi.Core.DTO
{
    /// <summary>
    /// Mapping data to Dto
    /// </summary>
    public class ProdottoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome del prodotto è obbligatorio")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Il nome deve essere compreso tra 3 e 200 caratteri")]
        public string Nome { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Il prezzo deve essere maggiore di zero")]
        public decimal Prezzo { get; set; }
    }
}
