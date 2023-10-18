using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UiS.Dat240.Lab3.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UiS.Dat240.Lab3.Core.Domain.Ordering;
using UiS.Dat240.Lab3.Core.Domain.Ordering.Dto;
using UiS.Dat240.Lab3.Core.Domain.Ordering.Services;



namespace UiS.Dat240.Lab3.Core.Domain.Cart.Pipelines;
public class CartCheckout
{
	public record Request(Guid CartId, string CustomerName, Location Location) : IRequest<Unit>;
	public class Handler : IRequestHandler<Request, Unit>
	{
		private readonly ShopContext _db;
		private readonly IOrderingService _orderingService;

		public Handler(ShopContext db, IOrderingService orderService){
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _orderingService = orderService;
        }

		public async Task<Unit> Handle(Request request, CancellationToken cancellationToken){
			var cart = await _db.ShoppingCart.Include(c => c.Items)
                                .Where(c => c.Id == request.CartId).FirstOrDefaultAsync();
            
            var products = cart.Items.Select( i => 
										 new OrderLineDto(
                                             i.Sku,
                                             i.Name,
                                             i.Count,
                                             i.Price
                                        ));
            await _orderingService.PlaceOrder(request.Location, request.CustomerName, products.ToArray());           
            return Unit.Value;
        }                

	}
}