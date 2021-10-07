using AutoMapper;
using Core.DomainModel.ProductAggregate.Data;
using Infra.ApplicationServices.Dtos;
using Infra.Dal;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.ApplicationServices.Commands.ProductAggregate
{
    public sealed class IncrementProductStockCommandHandler
        : IRequestHandler<IncrementProductStockCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IncrementProductStockCommandHandler(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(IncrementProductStockCommand rq, CancellationToken cancellationToken)
        {
            var product = _productRepository.IncrementStock(rq.Id, rq.Size);
            await _unitOfWork.CommitAsync();

            var dto = _mapper.Map<ProductDto>(product);

            return dto;
        }
    }
}
