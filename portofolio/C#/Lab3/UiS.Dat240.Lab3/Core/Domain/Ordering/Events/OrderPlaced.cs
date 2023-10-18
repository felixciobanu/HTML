using UiS.Dat240.Lab3.SharedKernel;
using System;

namespace UiS.Dat240.Lab3.Core.Domain.Ordering.Events;

public record OrderPlaced : BaseDomainEvent
{
	public OrderPlaced(Guid orderId)
	{
		Console.WriteLine(orderId);
		OrderId = orderId;
	}
	public Guid OrderId { get; }
}