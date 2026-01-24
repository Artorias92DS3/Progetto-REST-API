# Progetto-REST-API


# Descrizione Progetto
Progettare e implementare una REST API che utilizzi una classe astratta generica per gestire operazioni CRUD su entità differenti, facendo uso di DTO per il trasferimento dei dati e favorendo il riuso del codice


# Clone Repository
git clone https://github.com/Artorias92DS3/Progetto-REST-API.git

# Come Eseguire il Progetto

1. Aprire la soluzione `Progetto-REST-API.sln` in Visual Studio 2022.
2. Impostare `RestApi` come progetto di avvio.
3. Eseguire l'applicazione

# Requisiti
.NET 8
Visual Studio 2022


# Struttura del Progetto
- RestApi: Progetto principale che contiene i controller API REST.
- Core: Contiene le definizioni delle entità e dei DTO.
- Service: Implementa la logica di business e le operazioni CRUD generiche.
- Repository: Gestisce l'accesso ai dati in memoria.


# Scelte Architetturali

## 1. Una Classe Astratta Generica per le Operazioni CRUD
Invece di scrivere lo stesso codice per ogni tipo di dato (utenti, prodotti, ecc.), ho creato una classe base `ServizioBase` che contiene tutte le operazioni comuni: creare, leggere, aggiornare ed eliminare. 

Ogni volta che voglio gestire un nuovo tipo di dato, eredito semplicemente da questa classe e specifico solo le differenze. Questo significa meno codice duplicato e meno possibilità di errori.

## 2. Separazione tra Dati Interni ed Esterni

Ho separato come i dati vengono salvati internamente (Entità) da come vengono mostrati all'esterno (DTO):
- Le **Entità** sono il formato usato internamente dall'applicazione
- I **DTO** sono quello che l'API mostra agli utenti

Questo permette di cambiare l'architettura interna senza influenzare chi usa l'API.

## 3. Database Simulato in Memoria

Per questo progetto ho usato semplici dizionari in memoria invece di un vero database. I dati esistono solo mentre l'applicazione è in esecuzione e vengono persi quando la si chiude. 

Questa scelta semplifica il progetto e lo rende facile da testare, ma in produzione si userebbe un database vero (SQL Server, PostgreSQL, ecc.).

## 4. Controlli e Messaggi di Errore Chiari

L'API verifica che i dati ricevuti siano corretti (nome non vuoto, email valida, prezzo positivo) e restituisce messaggi di errore chiari in italiano quando qualcosa non va.



## Estensibilità

Per aggiungere una nuova entità (es. `Ordine`):

1. Creare l'entità in `Core/Entities/Ordine.cs`
2. Creare il DTO in `Core/DTO/OrdineDto.cs`
3. Creare il servizio `ServiceOrdine.cs` estendendo `ServizioBase<Ordine, OrdineDto>`
4. Implementare i metodi di mappatura `MapInDto` e `MapInData`
5. Creare il controller `OrdiniController.cs`
6. Registrare il servizio in `Program.cs`

Tutta la logica CRUD sarà già disponibile senza riscrivere codice!