using System;
using System.Threading;
using System.Threading.Tasks;
using UiS.Dat240.Lab3.Core.Domain.Ordering.Events;
using UiS.Dat240.Lab3.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace UiS.Dat240.Lab3.Core.Domain.Fulfillment.Handlers
{
    public class OrderPlacedHandler : INotificationHandler<OrderPlaced>
    {
        private readonly ShopContext _db;

        public OrderPlacedHandler(ShopContext db)
            => _db = db ?? throw new System.ArgumentNullException(nameof(db));

        public async Task Handle(OrderPlaced notification, CancellationToken cancellationToken)
        {
            var order = await _db.Orders
                .Include(c => c.Customer)
                .Include(c => c.Location)
                .Include(c => c.OrderLines)
                .SingleOrDefaultAsync(o => o.Id == notification.OrderId, cancellationToken: cancellationToken);

            Console.WriteLine("test");
            if (order == null)
            {
                throw new Exception("orderen is null");
            }

            var amount = 0.0M;
            foreach (var item in order.OrderLines)
            {
                amount += item.Price * item.Amount;
            }

            Reimbursement reimbursement = new()
            {
                Amount = amount
            };

            Offer offer = new()
            {
                OrderId = notification.OrderId,
                Reimbursement = reimbursement
            };

            _db.Offers.Add(offer);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
