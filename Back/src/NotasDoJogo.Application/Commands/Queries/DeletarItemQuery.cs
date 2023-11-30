using MediatR;

namespace NotasDoJogo.Application.Commands.Queries
{
    public class DeletarItemQuery<T> : IRequest<T>
    {
        public int Id { get; set; }
        public DeletarItemQuery(int itemId)
        {
            Id = itemId;
        }
    }
}
