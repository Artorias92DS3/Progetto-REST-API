using Microsoft.AspNetCore.Mvc;
using RestApi.Core.DTO;
using RestApi.Service;

namespace RestApi.Controllers
{
    /// <summary>
    /// Controller REST per la gestione degli utenti
    /// </summary>
    [ApiController]
    [Route("api/utenti")]
    public class UtentiController : ControllerBase
    {
        private readonly ServiceUtente _servizioUtente;

        public UtentiController(ServiceUtente servizioUtente)
        {
            _servizioUtente = servizioUtente;
        }

        /// <summary>
        /// Ottiene una lista paginata di utenti
        /// </summary>
        [HttpGet]
        public IActionResult OttieniTutti(int numeroPagina = 1, int dimensionePagina = 10)
        {
            if (numeroPagina < 1 || dimensionePagina < 1)
            {
                return BadRequest("Il numero di pagina e la dimensione devono essere maggiori di zero");
            }

            var risultato = _servizioUtente.OttieniTutti(numeroPagina, dimensionePagina);
            return Ok(risultato);
        }

        /// <summary>
        /// Ottiene un record Utente per id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult OttieniPerId(int id)
        {
            var utente = _servizioUtente.OttieniPerId(id);
            if (utente == null)
            {
                return BadRequest($"Utente con ID: {id} non trovato");
            }

            return Ok(utente);
        }

        /// <summary>
        /// Crea un record Utente
        /// </summary>
        /// <param name="utente"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreaUtente(UtenteDto utente)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            var utenteCrate = _servizioUtente.CreaData(utente);

            return Ok(utenteCrate);

        }

        /// <summary>
        /// Aggiorna i dati dell'Utente con l'id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="utenteDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult AggiornaUtente(int id, UtenteDto utenteDto)
        {
            var utenteAggiornato = _servizioUtente.Aggiorna(id, utenteDto);
            if (utenteAggiornato == null)
            {
                return BadRequest($"Utente con ID: {id} non trovato");

            }
            return Ok(utenteAggiornato);
        }


        /// <summary>
        /// Cancella il record Utente con l'id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteUtente(int id)
        {
            var utenteCancellato = _servizioUtente.Elimina(id);
            if (utenteCancellato != true)
            {
                return BadRequest($"Utente con ID: {id} non trovato");
            }
            return NoContent();
        }
    }
}
        
