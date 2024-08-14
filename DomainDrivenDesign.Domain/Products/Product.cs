﻿using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Products;

public sealed class Product : Entity
{
	public Product(Guid id,Name name, int quantity, Money price, Guid categoryId) : base(id)
	{
		Name = name;
		Quantity = quantity;
		Price = price;
		CategoryId = categoryId;
	}

	public Name Name { get; private set; } = null!;
    public int Quantity { get; private set; }
    public Money Price { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; set; }

	public void Update(string name, int quantity, decimal amount, string currency, Guid categoryId)
	{
		Name = new(name);
		Quantity = quantity;
		Price = new(amount, Currency.FromCode(currency));
		CategoryId = categoryId;
	}
}
