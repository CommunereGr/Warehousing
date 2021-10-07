using Infra.ApplicationServices.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Infra.ApplicationServices.Queries.ProductAggregate
{
    public sealed class GetAllProductQuery : IRequest<IEnumerable<ProductDto>>
    { }
}
