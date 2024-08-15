using DomainDrivenDesign.Application.Features.Categories.CreateCategory;
using DomainDrivenDesign.Application.Features.Categories.GetAllCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CategoriesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> GetProducts(GetAllCategoriesQuery request, CancellationToken cancellationToken)
		{
			return Ok(await _mediator.Send(request, cancellationToken));
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			await _mediator.Send(request, cancellationToken);
			return NoContent();
		}
	}
}
