using System;
using UiS.Dat240.Lab3.SharedKernel;
using System.Collections.Generic;
using UiS.Dat240.Lab3.Core.Domain.Ordering.Dto;

namespace UiS.Dat240.Lab3.Core.Domain.Ordering{

    public class Order : BaseEntity
    {
        public Order(){
            Notes = "";
            OrderDate = DateTime.UtcNow;
        }

        public Guid Id { get; protected set; }
        public DateTime OrderDate { get; set; }
        public Location Location { get; set; }
        public string Notes { get; set; } 
        public Customer Customer { get; set; }
        public Status Status { get; set; }

        private readonly List<OrderLine> _orderLines = new();
        public IEnumerable<OrderLine> OrderLines => _orderLines.AsReadOnly();

        public void AddOrderLine(OrderLineDto data)
        {
            OrderLine orderLine = new(data.FoodItemId, data.FoodItemName, data.Price, data.Amount);
            _orderLines.Add(orderLine);		
        }

    }
}