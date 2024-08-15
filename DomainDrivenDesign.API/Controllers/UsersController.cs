using DomainDrivenDesign.Application.Features.Users.CreateUser;
using DomainDrivenDesign.Application.Features.Users.GetAllUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UsersController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> GetUsers(GetAllUsersQuery request, CancellationToken cancellationToken)
		{
			return Ok(await _mediator.Send(request,cancellationToken));
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateUserCommand request, CancellationToken cancellationToken)
		{
			await _mediator.Send(request,cancellationToken);
			return NoContent();
		}

	}
}
