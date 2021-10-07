using Infra.ApplicationServices.Dtos;
using MediatR;

namespace Infra.ApplicationServices.Commands.ProductAggregate
{
    public sealed class CreateProductCommand : IRequest<ProductDto>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}
