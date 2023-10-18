using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UiS.Dat240.Lab3.Core.Domain.Ordering.Events;
using UiS.Dat240.Lab3.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace UiS.Dat240.Lab3.Core.Domain.Invoicing.Handlers
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

            var amount = 0.0M;

            foreach (var item in order.OrderLines)
            {
                amount += item.Price * item.Amount;
            }

            var address = new Address(order.Location.Building, order.Location.RoomNumber, order.Location.Notes);
            var customer = new Customer(order.Customer.Id, order.Customer.Name);
            var invoice = new Invoice
            {
                OrderId = order.Id,
                Address = address,
                Amount = amount,
                Customer = customer,
                Status = Status.Placed
            };
            _db.Invoices.Add(invoice);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
