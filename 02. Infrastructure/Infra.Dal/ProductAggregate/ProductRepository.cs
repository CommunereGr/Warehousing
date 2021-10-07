using Core.DomainModel.ProductAggregate.Data;
using Core.DomainModel.ProductAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Dal.ProductAggregate
{
    public sealed class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product Create(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var entry = _dbContext.Products.Add(product);
            return entry.Entity;
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _dbContext.Products.Single(p => p.Id == id);
        }

        public Product IncrementStock(int id, int size)
        {
            var product = _dbContext.Products.Single(p => p.Id == id);
            product.IncrementStock(size);

            return product;
        }

        public Product DecrementStock(int id, int size)
        {
            var product = _dbContext.Products.Single(p => p.Id == id);
            product.DecrementStock(size);

            return product;
        }
    }
}
