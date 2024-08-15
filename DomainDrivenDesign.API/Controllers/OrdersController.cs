using DomainDrivenDesign.Application.Features.Orders.CreateOrder;
using DomainDrivenDesign.Application.Features.Orders.GetAllOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IMediator _mediator;

		public OrdersController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> GetProducts(GetAllOrderQuery request, CancellationToken cancellationToken)
		{
			return Ok(await _mediator.Send(request, cancellationToken));
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateOrderCommand request, CancellationToken cancellationToken)
		{
			await _mediator.Send(request, cancellationToken);
			return NoContent();
		}
	}
}
