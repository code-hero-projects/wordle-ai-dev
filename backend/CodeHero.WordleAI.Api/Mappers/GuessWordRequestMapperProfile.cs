using AutoMapper;
using CodeHero.WordleAI.Api.Requests.PostWord;
using CodeHero.WordleAI.Application.Commands.GuessWord;
using CodeHero.WordleAI.Application.Commands.GuessWord.Model;

namespace CodeHero.WordleAI.Api.Mappers
{
    public class GuessWordRequestMapperProfile : Profile
    {
        public GuessWordRequestMapperProfile()
        {
            CreateMap<CorrectLetter, CorrectLetterRequest>();
            CreateMap<MisplacedLetter, MisplacedLetterRequest>();
            CreateMap<PostWordRequest, GuessWordRequest>();
        }
    }
}
