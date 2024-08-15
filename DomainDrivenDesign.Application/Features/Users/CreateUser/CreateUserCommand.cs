using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDrivenDesign.Domain.Users;
using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Orders.Events;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Users.Events;

namespace DomainDrivenDesign.Application.Features.Users.CreateUser;

public sealed record CreateUserCommand(
	string Name, 
	string Email, 
	string Password, 
	string Country, 
	string City, 
	string Street, 
	string PostalCode, 
	string FullAddress) :IRequest;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
	private readonly IUserRepository _userRepository;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMediator _mediator;
	public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMediator mediator)
	{
		_userRepository = userRepository;
		_unitOfWork = unitOfWork;
		_mediator = mediator;
	}

	public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		// business rules
		var user = await _userRepository.CreateAsync(
			request.Name, 
			request.Email, 
			request.Password, 
			request.Country, 
			request.City, 
			request.Street, 
			request.PostalCode, 
			request.FullAddress,
		cancellationToken);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		await _mediator.Publish(new UserDomainEvent(user));
	}
}