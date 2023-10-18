using UiS.Dat240.Lab3.SharedKernel;

namespace UiS.Dat240.Lab3.Core.Domain.Fulfillment;

public class Reimbursement : BaseEntity
{
    public Reimbursement(){
        
    }

    public int Id { get; protected set; }
    public int? InvoiceId { get;  set; }
    public int? ShipperId { get;  set; }
    public Shipper Shipper { get;  set; }
    public decimal? Amount { get;  set; }


    public override string ToString(){
        return "Invoice Id: "+  InvoiceId + ", Amount: " + Amount;
    }
}
