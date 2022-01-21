using CodeHero.Wordle.Domain.Model;
using CodeHero.Wordle.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CodeHero.Wordle.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWordRepository _wordRepository;

        public WeatherForecastController(IWordRepository wordRepository) => _wordRepository = wordRepository;

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task Get()
        {
            var table = new Word()
            {
                Characters = "table"
            };

            var chair = new Word()
            {
                Characters = "chair"
            };

            await _wordRepository.AddAsync(table);
            await _wordRepository.AddAsync(chair);

            await _wordRepository.SaveChangesAsync();

            var words = await _wordRepository.FilterAsync(word => word.Characters.Contains("r"));
        }
    }
}