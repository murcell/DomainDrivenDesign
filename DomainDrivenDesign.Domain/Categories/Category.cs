using DomainDrivenDesign.Domain.Products;

namespace DomainDrivenDesign.Domain.Categories;

public sealed class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Product> Products { get; set; } =null!
}
