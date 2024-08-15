﻿using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Orders.Events;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Orders.CreateOrder;

public sealed record CreateOrderCommand(
	List<CreateOrderDto> CreateOrderDtos) : IRequest;

internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
	private readonly IOrderRepository _orderRepository;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMediator _mediator;

	public CreateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMediator mediator)
	{
		_orderRepository = orderRepository;
		_unitOfWork = unitOfWork;
		_mediator = mediator;
	}

	public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
	{
		var order = await _orderRepository.OrderCreateAsync(request.CreateOrderDtos, cancellationToken);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		await _mediator.Publish(new OrderDomainEvent(order));
	}
}