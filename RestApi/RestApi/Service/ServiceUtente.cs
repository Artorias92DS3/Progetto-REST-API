using RestApi.Core.Astratte;
using RestApi.Core.DTO;
using RestApi.Core.Entities;

namespace RestApi.Service
{
    public class ServiceUtente : ServizioBase<Utente, UtenteDto>
    {
        public ServiceUtente(Dictionary<int, Utente> db) : base(db)
        {
        }

        protected override void ImpostaIdEntita(Utente entita, int id)
        {
            entita.Id = id;
        }

        protected override Utente MapInData(UtenteDto data)
        {
            return new Utente
            {
                Id = data.Id,
                Nome = data.Nome,
                Email = data.Email,
            };
        }

        protected override UtenteDto MapInDto(Utente entita)
        {
            return new UtenteDto
            {
                Id = entita.Id,
                Nome = entita.Nome,
                Email = entita.Email,
            };
        }
    }
}
