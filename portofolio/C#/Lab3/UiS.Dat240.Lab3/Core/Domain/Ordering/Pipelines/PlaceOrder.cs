using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UiS.Dat240.Lab3.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UiS.Dat240.Lab3.Core.Domain.Ordering.Dto;
using UiS.Dat240.Lab3.Core.Domain.Ordering.Events;

namespace UiS.Dat240.Lab3.Core.Domain.Ordering.Pipelines{

	public class PlaceOrder
	{
		public record Request(
			Location Location, string Name, OrderLineDto[] OrderLines) : IRequest<Order>;

		public record Response(bool Success, string[] Errors);

		public class Handler : IRequestHandler<Request, Order>
		{
			private readonly ShopContext _db;

			public Handler(ShopContext db) => _db = db ?? throw new ArgumentNullException(nameof(db));

			public async Task<Order> Handle(Request request, CancellationToken cancellationToken)
			{
				Order order = new();
				order.Location = request.Location;
				order.Status = Status.Placed;
				foreach(var item in request.OrderLines){
					order.AddOrderLine(item);
				}
				var customer = await _db.Orders.Select(o => o.Customer).Where(o => 
					o.Name == request.Name).Take(1).SingleOrDefaultAsync(cancellationToken: cancellationToken) ?? new Customer(request.Name);
				order.Customer = customer;
				_db.Orders.Add(order);
				await _db.SaveChangesAsync(cancellationToken);
				var ordered = await _db.Orders.OrderByDescending(o => o.OrderDate).Take(1).SingleOrDefaultAsync(cancellationToken: cancellationToken); 
				ordered?.Events.Add(new OrderPlaced(ordered.Id));
				await _db.SaveChangesAsync(cancellationToken);
				return ordered;
			}
		}
	}
}