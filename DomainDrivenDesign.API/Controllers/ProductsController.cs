using DomainDrivenDesign.Application.Features.Products.CreateProductCommand;
using DomainDrivenDesign.Application.Features.Products.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ProductsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> GetProducts(GetAllProductsQuery request, CancellationToken cancellationToken)
		{
			return Ok(await _mediator.Send(request, cancellationToken));
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateProductCommand request, CancellationToken cancellationToken)
		{
			await _mediator.Send(request, cancellationToken);
			return NoContent();
		}
	}
}
