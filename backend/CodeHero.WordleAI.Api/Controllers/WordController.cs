using AutoMapper;
using CodeHero.WordleAI.Api.Requests.PostWord;
using CodeHero.WordleAI.Application.Commands.GuessWord;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeHero.WordleAI.Api.Controllers
{
    [ApiController]
    [Route("api/word")]
    public class WordController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public WordController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostWordRequest request)
        {
            var guessWordRequest = _mapper.Map<GuessWordRequest>(request);
            var response = await _mediator.Send(guessWordRequest);
            return Ok(response);
        }
    }
}