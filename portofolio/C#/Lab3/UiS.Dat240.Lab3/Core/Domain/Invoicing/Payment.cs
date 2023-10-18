using UiS.Dat240.Lab3.SharedKernel;

namespace UiS.Dat240.Lab3.Core.Domain.Invoicing{

public class Payment : BaseEntity
{
    public int Id { get; protected set; }
    public int Amount { get; protected set; }
}
}
