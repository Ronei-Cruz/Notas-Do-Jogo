using MediatR;

namespace NotasDoJogo.Application.Commands.Queries
{
    public class EditarItemQuery<TRequest, TResponse> : IRequest<TResponse>
    {
        public int Id { get; set; }
        public TRequest Request { get; set; }
    }
}
