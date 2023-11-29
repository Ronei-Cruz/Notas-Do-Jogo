using MediatR;

namespace NotasDoJogo.Application.Commands.Request
{
    public class ObterItemQuery<T> : IRequest<T>
    {
        public int Id { get; set; }
        public ObterItemQuery(int itemId)
        {
            Id = itemId;
        }
    }
}
