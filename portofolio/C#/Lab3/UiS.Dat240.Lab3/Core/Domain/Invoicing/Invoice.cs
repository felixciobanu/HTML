using System;
using UiS.Dat240.Lab3.SharedKernel;

namespace UiS.Dat240.Lab3.Core.Domain.Invoicing
{
    public class Invoice : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Address Address { get; set; }
        public decimal Amount { get; set; }
        public Customer Customer { get; set; }
        public Status Status { get; set; }
    }
}
