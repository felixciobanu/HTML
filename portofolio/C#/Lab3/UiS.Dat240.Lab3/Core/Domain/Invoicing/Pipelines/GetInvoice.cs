using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UiS.Dat240.Lab3.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace UiS.Dat240.Lab3.Core.Domain.Invoicing.Pipelines{

public class GetInvoice
{
	public record Request(Guid id) : IRequest<Invoice?>;


	public class Handler : IRequestHandler<Request, Invoice?>
	{
		private readonly ShopContext _db;

		public Handler(ShopContext db) => _db = db ?? throw new ArgumentNullException(nameof(db));

		public async Task<Invoice?> Handle(Request request, CancellationToken cancellationToken)
			=> await _db.Invoices.Include(c => c.Customer)
			                    .Include(c => c.Address)
                                .Where( o => o.OrderId == request.id)
										.SingleOrDefaultAsync();

	}
}
}