using System.Threading.Tasks;
using UiS.Dat240.Lab3.Core.Domain.Ordering.Dto;
using MediatR;
using UiS.Dat240.Lab3.Core.Domain.Ordering.Pipelines;

namespace UiS.Dat240.Lab3.Core.Domain.Ordering.Services{


public class OrderingService : IOrderingService
{ 
    private readonly IMediator _mediator;

	public OrderingService(IMediator mediator) => _mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));

    public async Task<int> PlaceOrder(Location location, string customerName, OrderLineDto[] orderLines){
		var order = await _mediator.Send(new PlaceOrder.Request(location, customerName, orderLines));
        
        return 0;
    }
}
}