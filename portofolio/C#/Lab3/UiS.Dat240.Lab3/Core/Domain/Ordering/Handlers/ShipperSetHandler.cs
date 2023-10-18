using System;
using System.Threading;
using System.Threading.Tasks;
using UiS.Dat240.Lab3.Core.Domain.Fulfillment.Events;
using UiS.Dat240.Lab3.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace UiS.Dat240.Lab3.Core.Domain.Ordering.Handlers
{
    public class ShipperSetHandler : INotificationHandler<ShipperSet>
    {
        private readonly ShopContext _db;

        public ShipperSetHandler(ShopContext db)
            => _db = db ?? throw new ArgumentNullException(nameof(db));

        public async Task Handle(ShipperSet notification, CancellationToken cancellationToken)
        {
            var order = await _db.Orders.SingleOrDefaultAsync(o => o.Id == notification.OrderId,
                cancellationToken: cancellationToken);
            if (order == null)
            {
                throw new Exception("orderen is null");
            }

            order.Status = Status.Shipped;
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
