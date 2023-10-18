using System;
using System.Threading;
using System.Threading.Tasks;
using UiS.Dat240.Lab3.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UiS.Dat240.Lab3.Core.Domain.Ordering.Pipelines{
	public class Get
	{
		public record Request() : IRequest<List<Order>?>;


		public class Handler : IRequestHandler<Request, List<Order>?>
		{
			private readonly ShopContext _db;

			public Handler(ShopContext db) => _db = db ?? throw new ArgumentNullException(nameof(db));

			public async Task<List<Order>?> Handle(Request request, CancellationToken cancellationToken)
				=> await _db.Orders.Include(c => c.Customer)
									.Include(c => c.OrderLines)
									.Include(c => c.Location)
									.ToListAsync(cancellationToken: cancellationToken);

		}
	}
}