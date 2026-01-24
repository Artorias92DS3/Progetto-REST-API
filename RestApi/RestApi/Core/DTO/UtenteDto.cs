using System.ComponentModel.DataAnnotations;

namespace RestApi.Core.DTO
{
    /// <summary>
    /// Mapping data to Dto
    /// </summary>
    public class UtenteDto
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Il nome deve essere compreso tra 2 e 100 caratteri")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'email è obbligatoria")]
        [EmailAddress(ErrorMessage = "Il formato dell'email non è valido")]
        public string Email { get; set; } = string.Empty;
    }
}

