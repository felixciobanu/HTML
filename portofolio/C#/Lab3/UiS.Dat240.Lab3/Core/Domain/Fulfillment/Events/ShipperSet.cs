using UiS.Dat240.Lab3.SharedKernel;
using System;


namespace UiS.Dat240.Lab3.Core.Domain.Fulfillment.Events{

public record ShipperSet : BaseDomainEvent
{
	public ShipperSet(Guid OrderId)
	{
        this.OrderId = OrderId;
	}

	public Guid OrderId { get; }	
}
}