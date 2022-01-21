using CodeHero.Wordle.Api;
using CodeHero.Wordle.Api.Extensions;
using CodeHero.Wordle.Application.Extensions;
using CodeHero.Wordle.Database.Extensions;
using CodeHero.Wordle.WordFetcher.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

var databaseConfiguration = configuration.GetSection(ApiConstants.AppSettingsDatabaseSection);
var wordFetcherConfiguration = configuration.GetSection(ApiConstants.AppSettingsDWordSupplierUrlSection);

services
    .AddDatabaseDependencies(databaseConfiguration)
    .AddWordFetcherDependencies(wordFetcherConfiguration)
    .AddApplicationDependencies()
    .AddApiDependencies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
