using System;
namespace UiS.Dat240.Lab3.Core.Domain.Ordering{

public class OrderLine
{
    public OrderLine(int itemId, string item, decimal price, int amount)
    {
        ItemId = itemId;
        Item = item;
        Price = price;
        Amount = amount;
    }

    public Guid Id { get; protected set; }

	public int ItemId { get; private set; }
    public string Item { get; protected set; }
    public decimal Price { get; protected set; }
    public int Amount { get; protected set; }
}
}