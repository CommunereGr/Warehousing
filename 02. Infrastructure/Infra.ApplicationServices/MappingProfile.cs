using AutoMapper;
using Core.DomainModel.ProductAggregate.Entities;
using Infra.ApplicationServices.Dtos;

namespace Infra.ApplicationServices
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
