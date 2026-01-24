using RestApi.Repository;
using RestApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opzioni =>
{
    opzioni.SwaggerDoc("v1", new()
    {
        Title = "REST API",
        Version = "v1",
        Description = "API REST con classe astratta generica per operazioni CRUD su Utenti e Prodotti",
        Contact = new()
        {
            Name = "Marco",
            Email = "marco@esempio.it"
        }
    });

    // Abilita i commenti XML per la documentazione Swagger
    var percorsoFileXml = Path.Combine(AppContext.BaseDirectory, "RestApi.xml");
    if (File.Exists(percorsoFileXml))
    {
        opzioni.IncludeXmlComments(percorsoFileXml);
    }
});
// Registrazione dello storage singleton
var archiviazione = PersistenzaDati.Istanza;

// Registrazione dei servizi con lo storage condiviso
builder.Services.AddSingleton(new ServiceUtente(archiviazione.Utenti));
builder.Services.AddSingleton(new ServiceProdotto(archiviazione.Prodotti));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
