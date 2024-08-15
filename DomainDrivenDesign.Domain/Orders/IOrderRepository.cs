using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Orders
{
	public interface IOrderRepository
	{
		Task<Order> OrderCreateAsync(List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken=default);
		Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default);
	}
}
