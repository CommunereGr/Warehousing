using AutoMapper;
using Core.DomainModel.ProductAggregate.Data;
using Infra.ApplicationServices.Dtos;
using Infra.Dal;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.ApplicationServices.Commands.ProductAggregate
{
    public sealed class DecrementProductStockCommandHandler
        : IRequestHandler<DecrementProductStockCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DecrementProductStockCommandHandler(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(DecrementProductStockCommand rq, CancellationToken cancellationToken)
        {
            var product = _productRepository.DecrementStock(rq.Id, rq.Size);
            await _unitOfWork.CommitAsync();

            var dto = _mapper.Map<ProductDto>(product);

            return dto;
        }
    }
}
