using DomainDrivenDesign.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Products.GetAllProducts;

public sealed record GetAllProductsQuery() : IRequest<List<Product>>;

internal sealed class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
{
	private readonly IProductRepository _productRepository;

	public GetAllProductQueryHandler(IProductRepository productRepository)
	{
		_productRepository = productRepository;
	}

	public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
	{
		return await _productRepository.GetAllAsync(cancellationToken);
	}
}
