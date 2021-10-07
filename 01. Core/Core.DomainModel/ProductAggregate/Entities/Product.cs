using System;

namespace Core.DomainModel.ProductAggregate.Entities
{
    public sealed class Product
    {
        private Product()
        {}

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }
        public int Stock { get; private set; }

        public static Product Create(string name, int price, int stock)
        {
            return new Product
            {
                Name = name,
                Price = price,
                Stock = stock,
            };
        }

        public void IncrementStock(int size)
        {
            Stock += size;
        }

        public void DecrementStock(int size)
        {
            if (size > Stock)
            {
                throw new ArgumentException("Decrement size can NOT be greater then available stocke.");
            }

            Stock -= size;
        }
    }
}
