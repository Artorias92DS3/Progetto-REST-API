using Microsoft.AspNetCore.Mvc;
using RestApi.Core.DTO;
using RestApi.Service;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/prodotti")]
    public class ProdottoController : ControllerBase
    {
        private readonly ServiceProdotto _serviceProdotto;

        public ProdottoController(ServiceProdotto serviceProdotto)
        {
            _serviceProdotto = serviceProdotto;
        }

        /// <summary>
        /// Ottieni tutti i prodotti con paginazione
        /// </summary>
        /// <param name="numeroPagina"></param>
        /// <param name="dimensonePagina"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OttieniTutti(int numeroPagina = 1, int dimensonePagina = 10)
        {
            if (numeroPagina < 1 || dimensonePagina < 1)
            {
                return BadRequest("Il numero di pagina e la dimensione devono essere maggiori di zero");
            }

            var prodotti = _serviceProdotto.OttieniTutti(numeroPagina, dimensonePagina);
            return Ok(prodotti);

        }

        /// <summary>
        /// Ottieni prodotto per ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult OttieniPerId(int id)
        {
            var prodotto = _serviceProdotto.OttieniPerId(id);
            if (prodotto == null)
            {
                return BadRequest($"Prodotto con ID: {id} non trovato");
            }
            return Ok(prodotto);
        }

        /// <summary>
        /// Crea un nuovo prodotto
        /// </summary>
        /// <param name="prodotto"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Aggiorna un prodotto esistente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="prodotto"></param>
        /// <returns></returns>
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
                return BadRequest($"Prodotto con ID: {id} non trovato");
            }
            return Ok(prodottoAggiornato);
        }

        /// <summary>
        /// Elimina un prodotto per ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult CancellaProdotto(int id)
        {
            var prodottoCancellato = _serviceProdotto.Elimina(id);
            if (prodottoCancellato != true)
            {
                return BadRequest($"Prodotto con ID: {id} non trovato");
            }
            return Ok(prodottoCancellato);
        }

    }
}
