using RestApi.Core.Entities;

namespace RestApi.Repository
{
    public class PersistenzaDati
    {
        private static PersistenzaDati? _istanza;
        private static readonly object _lock = new();

        public Dictionary<int, Utente> Utenti { get; } = new();
        public Dictionary<int, Prodotto> Prodotti { get; } = new();

        private PersistenzaDati()
        {
            InizializzaDati();
        }

        public static PersistenzaDati Istanza
        {
            get
            {
                if (_istanza == null)
                {
                    lock (_lock)
                    {
                        if (_istanza == null)
                            _istanza = new PersistenzaDati();
                    }
                }
                return _istanza;
            }
        }
        /// <summary>
        /// Inizializza i dati di esempio
        /// </summary>
        private void InizializzaDati()
        {
            var utente1 = new Utente
            {
                Id = 1,
                Nome = "Mario Rossi",
                Email = "mario.rossi@esempio.it"
            };
            var utente2 = new Utente
            {
                Id = 2,
                Nome = "Laura Bianchi",
                Email = "laura.bianchi@esempio.it"
            };
            var utente3 = new Utente
            {
                Id = 3,
                Nome = "Giuseppe Verdi",
                Email = "giuseppe.verdi@esempio.it"
            };

            Utenti[utente1.Id] = utente1;
            Utenti[utente2.Id] = utente2;
            Utenti[utente3.Id] = utente3;

            var prodotto1 = new Prodotto
            {
                Id = 1,
                Nome = "Laptop Dell XPS 15",
                Prezzo = 1299.99m
            };
            var prodotto2 = new Prodotto
            {
                Id = 2,
                Nome = "Mouse Logitech MX Master 3",
                Prezzo = 99.99m
            };
            var prodotto3 = new Prodotto
            {
                Id = 3,
                Nome = "Tastiera Meccanica Keychron K2",
                Prezzo = 89.99m
            };
            var prodotto4 = new Prodotto
            {
                Id = 4,
                Nome = "Monitor Samsung 27 pollici 4K",
                Prezzo = 349.99m
            };

            Prodotti[prodotto1.Id] = prodotto1;
            Prodotti[prodotto2.Id] = prodotto2;
            Prodotti[prodotto3.Id] = prodotto3;
            Prodotti[prodotto4.Id] = prodotto4;
        }
    }
}
