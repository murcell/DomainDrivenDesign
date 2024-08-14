namespace DomainDrivenDesign.Domain.Orders
{
	public enum OrderStatus
    {
        AwaitingApproval = 1, // Beklemede
		BeingApproval = 2, // hazırlanıyor
		InTransit = 3, // Beklemede
		Delivered = 4, // Beklemede
	}
}
