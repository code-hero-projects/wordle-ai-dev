using CodeHero.WordleAI.Api;
using CodeHero.WordleAI.Api.Extensions;
using CodeHero.WordleAI.Application.Extensions;
using CodeHero.WordleAI.Database;
using CodeHero.WordleAI.Database.Extensions;
using CodeHero.WordleAI.WordSupplier;
using CodeHero.WordleAI.WordSupplier.Extensions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

var databaseConfiguration = configuration.GetSection(ApiConstants.AppSettingsDatabaseSection);

services
    .AddDatabaseDependencies(databaseConfiguration)
    .AddWordSupplierDependencies()
    .AddApplicationDependencies()
    .AddApiDependencies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

await app
    .InitialiseDatabase()
    .InitialiseWordDataSet();

app.Run();
