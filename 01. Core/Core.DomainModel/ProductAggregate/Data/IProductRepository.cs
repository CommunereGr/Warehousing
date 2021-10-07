using Core.DomainModel.ProductAggregate.Entities;
using System.Collections.Generic;

namespace Core.DomainModel.ProductAggregate.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Product Create(Product product);
        Product IncrementStock(int id, int size);
        Product DecrementStock(int id, int size);
    }
}
