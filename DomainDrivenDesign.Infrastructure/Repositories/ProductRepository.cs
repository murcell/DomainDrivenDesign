using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Infrastructure.Repositories
{
	internal class ProductRepository : IProductRepository
	{
		private readonly ApplicationMgDbContext _context;

		public ProductRepository(ApplicationMgDbContext context)
		{
			_context = context;
		}

		public async Task CreateAsync(string name, int quantity, decimal amount, string currency, Guid categoryId, CancellationToken cancellationToken = default)
		{
			Product product = new(
				Guid.NewGuid(),
				new(name),
				quantity,
				new(amount, Currency.FromCode(currency)),
				categoryId);

			await _context.Products.AddAsync(product, cancellationToken);
		}

		public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			return await _context.Products.ToListAsync(cancellationToken);
		}
	}
}
