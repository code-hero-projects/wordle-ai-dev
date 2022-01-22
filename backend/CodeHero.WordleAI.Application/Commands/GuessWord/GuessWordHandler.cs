using MediatR;

namespace CodeHero.WordleAI.Application.Commands.GuessWord
{
    public class GuessWordHandler : IRequestHandler<GuessWordRequest, GuessWordResponse>
    {
        public Task<GuessWordResponse> Handle(GuessWordRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
