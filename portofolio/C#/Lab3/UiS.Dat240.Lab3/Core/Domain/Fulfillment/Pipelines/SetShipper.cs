using System;
using System.Threading;
using System.Threading.Tasks;
using UiS.Dat240.Lab3.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UiS.Dat240.Lab3.Core.Domain.Fulfillment.Events;

namespace UiS.Dat240.Lab3.Core.Domain.Fulfillment.Pipelines
{
    public class SetShipper
    {
        public record Request(
            string shipperName,
            Guid orderId
        ) : IRequest<Unit>;

        public record Response(bool Success, string[] Errors);

        public class Handler : IRequestHandler<Request, Unit>
        {
            private readonly ShopContext _db;

            public Handler(ShopContext db) => _db = db ?? throw new ArgumentNullException(nameof(db));

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var shipper = new Shipper(request.shipperName);

                var offeren = await _db.Offers.SingleOrDefaultAsync(o => o.OrderId == request.orderId,
                    cancellationToken: cancellationToken);
                if (offeren == null)
                {
                    throw new Exception("offeren is null");
                }

                offeren.Shipper = shipper;
                offeren.Events.Add(new ShipperSet(request.orderId));

                await _db.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
