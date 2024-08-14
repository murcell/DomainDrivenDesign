namespace DomainDrivenDesign.Domain.Orders;

public sealed class Order
{
        public Guid Id { get; set; }
        public string OrderNUmber { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; } = null!;
    }
