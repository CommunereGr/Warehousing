using AutoMapper;
using Core.DomainModel.ProductAggregate.Data;
using Infra.ApplicationServices.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.ApplicationServices.Queries.ProductAggregate
{
    public sealed class GetAllProductQueryHandler
        : IRequestHandler<GetAllProductQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(
            IProductRepository productRepository,
            IMapper mapper
        )
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<ProductDto>> Handle(
            GetAllProductQuery rq,
            CancellationToken cancellationToken
        )
        {
            var products = _productRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            return Task.FromResult(dtos);
        }
    }
}
