using CodeHero.Wordle.Api;
using CodeHero.Wordle.Api.Extensions;
using CodeHero.Wordle.Application.Extensions;
using CodeHero.Wordle.Database;
using CodeHero.Wordle.Database.Extensions;
using CodeHero.Wordle.WordFetcher;
using CodeHero.Wordle.WordFetcher.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

var databaseConfiguration = configuration.GetSection(ApiConstants.AppSettingsDatabaseSection);

services
    .AddDatabaseDependencies(databaseConfiguration)
    .AddWordFetcherDependencies()
    .AddApplicationDependencies()
    .AddApiDependencies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.InitialiseDatabase();
await app.InitialiseWordDataSet();

app.Run();
