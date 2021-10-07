using App.Api.ApiResponse;
using Infra.ApplicationServices.Commands.ProductAggregate;
using Infra.ApplicationServices.Queries.ProductAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductQuery();
            var rs = await _mediator.Send(query);
            return rs.ToActionResult();
        }

        /// <summary>
        /// Retrieves products by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProductByIdQuery(id);
            var rs = await _mediator.Send(query);
            return rs.ToActionResult();
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var rs = await _mediator.Send(command);
            return rs.ToActionResult();
        }

        /// <summary>
        /// Increments stock of the requested product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("stock/increment")]
        public async Task<IActionResult> IncrementStock(IncrementProductStockCommand command)
        {
            var rs = await _mediator.Send(command);
            return rs.ToActionResult();
        }

        /// <summary>
        /// Decrements stock of the requested product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("stock/decrement")]
        public async Task<IActionResult> DecrementStock(DecrementProductStockCommand command)
        {
            var rs = await _mediator.Send(command);
            return rs.ToActionResult();
        }
    }
}
