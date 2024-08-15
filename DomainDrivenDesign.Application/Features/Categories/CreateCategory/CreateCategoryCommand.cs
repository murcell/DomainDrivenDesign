using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Categories.CreateCategory
{
	public sealed record CreateCategoryCommand(string Name):IRequest;

	internal sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IUnitOfWork _unitOfWork;

		public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
		{
			_categoryRepository = categoryRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			await _categoryRepository.CreateAsync(request.Name, cancellationToken);
			await _unitOfWork.SaveChangesAsync(cancellationToken);
		}
	}
}
