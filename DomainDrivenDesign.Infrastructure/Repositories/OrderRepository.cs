using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Infrastructure.Repositories
{
	internal class OrderRepository : IOrderRepository
	{
		private readonly ApplicationMgDbContext _context;

		public OrderRepository(ApplicationMgDbContext context)
		{
			_context = context;
		}

		public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			return
				await _context.Orders
				.Include(p => p.OrderLines)
				.ThenInclude(p => p.Product)
				.ToListAsync(cancellationToken);
		}

		public async Task<Order> OrderCreateAsync(List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken = default)
		{
			Order order = new(
				Guid.NewGuid(),
				"1",
				DateTime.Now,
				OrderStatus.AwaitingApproval);

			order.CreateOrder(createOrderDtos);

			await _context.Orders.AddAsync(order, cancellationToken);
			return order;
		}
	}
}
