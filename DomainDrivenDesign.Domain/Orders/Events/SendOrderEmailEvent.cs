using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Orders.Events
{
	public sealed class SendOrderSmslEvent : INotificationHandler<OrderDomainEvent>
	{
		public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
		{
			// mail sendin process
			return Task.CompletedTask;
		}
	}
}
