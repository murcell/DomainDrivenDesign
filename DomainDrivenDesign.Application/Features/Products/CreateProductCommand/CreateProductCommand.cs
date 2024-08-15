using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Products.CreateProductCommand;

public sealed record CreateProductCommand(
string Name,
int Quantity,
decimal Amount,
string Currency,
Guid CategoryId) : IRequest;

internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
	private readonly IProductRepository _productRepository;
	private readonly IUnitOfWork _unitOfWork;
	public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
	{
		_productRepository = productRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
	{
		//business rule
		await _productRepository.CreateAsync(
			request.Name,
			request.Quantity,
			request.Amount,
			request.Currency,
			request.CategoryId,
			cancellationToken);

		await _unitOfWork.SaveChangesAsync(cancellationToken);
		
	}
}