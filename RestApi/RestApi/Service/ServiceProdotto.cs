using RestApi.Core.Astratte;
using RestApi.Core.DTO;
using RestApi.Core.Entities;

namespace RestApi.Service
{
    public class ServiceProdotto : ServizioBase<Prodotto, ProdottoDto>
    {
        public ServiceProdotto(Dictionary<int, Prodotto> db) : base(db) { }

        protected override void ImpostaIdEntita(Prodotto entita, int id)
        {
            entita.Id = id;
        }

        protected override Prodotto MapInData(ProdottoDto data)
        {
            return new Prodotto
            {
                Id = data.Id,
                Nome = data.Nome,
                Prezzo = data.Prezzo,
            };
        }

        protected override ProdottoDto MapInDto(Prodotto entita)
        {
            return new ProdottoDto
            {
                Id = entita.Id,
                Nome = entita.Nome,
                Prezzo = entita.Prezzo,
            };
        }
    }
}
