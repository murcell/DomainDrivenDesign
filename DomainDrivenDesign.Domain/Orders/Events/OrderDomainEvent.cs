using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Orders.Events
{
    public sealed class OrderDomainEvent : INotification
    {
        public Order Order { get; }
        public OrderDomainEvent(Order order)
        {
            Order = order;
        }
    }
}
