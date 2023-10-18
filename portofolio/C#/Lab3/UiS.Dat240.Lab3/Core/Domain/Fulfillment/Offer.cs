using System;
using UiS.Dat240.Lab3.SharedKernel;

namespace UiS.Dat240.Lab3.Core.Domain.Fulfillment{

public class Offer : BaseEntity
{
    public Offer(){

    }
    public int Id { get; protected set; }
    public Guid OrderId { get; set; }
    public int? ShipperId { get; set; }
    public Shipper Shipper { get; set; }
    public int? ReimbursementId { get; set; }
    public Reimbursement? Reimbursement { get; set; }
}
}