using Infra.ApplicationServices.Dtos;
using MediatR;

namespace Infra.ApplicationServices.Queries.ProductAggregate
{
    public sealed class GetProductByIdQuery : IRequest<ProductDto>
    {
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
