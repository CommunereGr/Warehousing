using AutoMapper;
using Core.DomainModel.ProductAggregate.Data;
using Infra.ApplicationServices.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.ApplicationServices.Queries.ProductAggregate
{
    public sealed class GetProductByIdQueryHandler
        : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(
            IProductRepository productRepository,
            IMapper mapper
        )
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<ProductDto> Handle(GetProductByIdQuery rq, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetById(rq.Id);
            var dto = _mapper.Map<ProductDto>(product);

            return Task.FromResult(dto);
        }
    }
}
