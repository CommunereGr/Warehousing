using Infra.ApplicationServices.Dtos;
using MediatR;

namespace Infra.ApplicationServices.Commands.ProductAggregate
{
    public sealed class DecrementProductStockCommand : IRequest<ProductDto>
    {
        public int Id { get; set; }
        public int Size { get; set; }
    }
}
