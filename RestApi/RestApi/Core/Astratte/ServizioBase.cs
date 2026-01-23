using RestApi.Core.Models;

namespace RestApi.Core.Astratte
{
    public abstract class ServizioBase<TEntity, TDto>
        where TDto : class
        where TEntity : class
    {
        protected readonly Dictionary<int, TEntity> db;
        protected int _id = 0;
        protected ServizioBase(Dictionary<int, TEntity> archivio)
        {
            db = archivio;
            _id = db.Keys.Any() ? db.Keys.Max() + 1 : 0;
        }

        public virtual TDto OttieniPerId(int id)
        {
            if (!db.TryGetValue(id, out var entita))
            {
                return null;
            }
            return MapInDto(entita);
        }
        
        
        /// <summary>
        /// recupero i data paginati
        /// </summary>
        /// <param name="numeroPagina"></param>
        /// <param name="dimensionePagina"></param>
        /// <returns></returns>
        public virtual RisultatoPaginato<TDto> OttieniTutti(int numeroPagina = 1, int dimensionePagina = 5)
        {
            var totaleElementi = db.Count;
            var data = db.Values
                        .Skip((numeroPagina - 1) * dimensionePagina)
                        .Take(dimensionePagina)
                        .ToList();

            var dtos = data.Select(MapInDto).ToList();

            RisultatoPaginato<TDto> risultatoPaginato = new RisultatoPaginato<TDto>
            {
                Elementi = dtos,
                NumeroPagina = numeroPagina,
                DimensionePagina = dimensionePagina,
                TotaleElementi = totaleElementi,
                TotalePagine = totaleElementi / dimensionePagina
            };

            return risultatoPaginato;

        }

        public virtual TDto CreaData(TDto dto)
        {
            var data = MapInData(dto);
            var prossimoid = _id++;
            ImpostaIdEntita(data, prossimoid);

            db[prossimoid] = data;

            return MapInDto(data);
        }

        /// <summary>
        /// Aggiorna un'entità esistente
        /// </summary>
        public virtual TDto? Aggiorna(int id, TDto dto)
        {          

            if (!db.ContainsKey(id))
                return null;

            var entita = MapInData(dto);
            ImpostaIdEntita(entita, id);

            db[id] = entita;

            return MapInDto(entita);
        }

        /// <summary>
        /// Elimina un'entità tramite il suo identificativo
        /// </summary>
        public bool Elimina(int id)
        {
            return db.Remove(id);
        }


        /// <summary>
        /// Mappa un'entitia nel suo Dto corrispondente
        /// </summary>
        /// <param name="entita"></param>
        /// <returns></returns>
        protected abstract TDto MapInDto(TEntity entita);
        protected abstract TEntity MapInData(TDto data);
        protected abstract void ImpostaIdEntita(TEntity entita, int id);
    }
}
