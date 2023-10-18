namespace UiS.Dat240.Lab3.Core.Domain.Invoicing{

public class Customer
{
    public Customer(){

    }
    public Customer(int id, string name){
        this.Id = id;
        this.Name = name;
    }
    public int Id { get; protected set; }
    public string Name { get; protected set; }   
}
}