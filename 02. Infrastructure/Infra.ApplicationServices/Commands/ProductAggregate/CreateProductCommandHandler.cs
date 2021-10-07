using AutoMapper;
using Core.DomainModel.ProductAggregate.Data;
using Core.DomainModel.ProductAggregate.Entities;
using Infra.ApplicationServices.Dtos;
using Infra.Dal;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.ApplicationServices.Commands.ProductAggregate
{
    public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(CreateProductCommand rq, CancellationToken cancellationToken)
        {
            var product = Product.Create(rq.Name, rq.Price, rq.Stock);

            _productRepository.Create(product);
            await _unitOfWork.CommitAsync();

            var dto = _mapper.Map<ProductDto>(product);

            return dto;
        }
    }
}
