using DomainDrivenDesign.Domain.Categories;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Categories.GetAllCategories;

public sealed record GetAllCategoriesQuery() : IRequest<List<Category>>;

internal sealed record GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<Category>>
{
	private readonly ICategoryRepository _categoryRepository;

	public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository;
	}

	public async Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
	{
		return await _categoryRepository.GetAllAsync(cancellationToken);
	}
}
