using Microsoft.AspNetCore.Mvc;
using RestApi.Core.DTO;
using RestApi.Service;

namespace RestApi.Controllers
{
    public class ProdottoController : ControllerBase
    {
        private readonly ServiceProdotto _serviceProdotto;

        public ProdottoController(ServiceProdotto serviceProdotto)
        {
            _serviceProdotto = serviceProdotto;
        }


        [HttpGet]
        public IActionResult OttieniTutti(int numeroPagina = 1, int dimensonePagina = 1)
        {
            if (numeroPagina < 1 || dimensonePagina < 1)
            {
                return BadRequest("Il numero di pagina e la dimensione devono essere maggiori di zero");
            }

            var prodotti = _serviceProdotto.OttieniTutti(numeroPagina, dimensonePagina);
            return Ok(prodotti);

        }

        [HttpGet("{id}")]
        public IActionResult OttieniPerId(int id)
        {
            var prodotto = _serviceProdotto.OttieniPerId(id);
            if (prodotto == null)
            {
                return BadRequest($"Utente con ID: {id} non trovato");
            }
            return Ok(prodotto);
        }

        [HttpPost]
        public IActionResult CreaProdotto(ProdottoDto prodotto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var prodottoAggiornato = _serviceProdotto.CreaData(prodotto);
            return Ok(prodottoAggiornato);
        }

        [HttpPut("{id}")]
        public IActionResult AggiornaProdotto(int id, ProdottoDto prodotto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var prodottoAggiornato = _serviceProdotto.Aggiorna(id, prodotto);
            if (prodottoAggiornato == null)
            {
                return BadRequest($"Utente con ID: {id} non trovato");
            }
            return Ok(prodottoAggiornato);
        }

        [HttpDelete("{id}")]
        public IActionResult CancellaProdotto(int id)
        {
            var prodottoCancellato = _serviceProdotto.Elimina(id);
            if (prodottoCancellato != true)
            {
                return BadRequest($"Utente con ID: {id} non trovato");
            }
            return Ok(prodottoCancellato);
        }

    }
}
