using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Orders;

public sealed class Order : Entity
{
	private Order(Guid id) : base(id)
	{

	}

	public Order(Guid id, string orderNUmber, DateTime createdDate, OrderStatus status) : base(id)
	{
		OrderNUmber = orderNUmber;
		CreatedDate = createdDate;
		Status = status;
	}

	public string OrderNUmber { get; private set; } = null!;
	public DateTime CreatedDate { get; private set; }
	public OrderStatus Status { get; private set; }
	public ICollection<OrderLine> OrderLines { get; private set; } = new List<OrderLine>();

	public void CreateOrder(List<CreateOrderDto> createOrderDtos)
	{
		foreach (var item in createOrderDtos)
		{
			if (item.Quantity < 1)
			{
				throw new ArgumentException("Sipariş adedi 1'den az olamaz..!");
			}

			OrderLine orderLine = new OrderLine(
				Guid.NewGuid(),
				Id,
				item.ProductId,
				item.Quantity,
				new(item.Amount, Currency.FromCode(item.Curency)));

			OrderLines.Add(orderLine);
		}
	}

	public void RemoveOrderLine(Guid orderlineId)
	{
		var orderLine = OrderLines.FirstOrDefault(x => x.Id == orderlineId);
		if (orderLine is null)
		{
			throw new ArgumentException("Silmek istediğiniz sipraiş kalemi bulunamadı..!");
		}
		OrderLines.Remove(orderLine);
	}


}
