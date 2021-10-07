using Infra.ApplicationServices.Commands.ProductAggregate;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace App.Api.Swagger.Examples
{
    public sealed class CreateProductCommandExample : IExamplesProvider<CreateProductCommand>
    {
        public CreateProductCommand GetExamples()
        {
            return new CreateProductCommand
            {
                Name = "Black shoes",
                Price = 20,
                Stock = 10,
            };
        }
    }
}
