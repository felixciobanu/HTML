using System;
using UiS.Dat240.Lab3.SharedKernel;
using System.Collections.Generic;

namespace UiS.Dat240.Lab3.Core.Domain.Ordering;

public class Location : ValueObject
{
    public Location(){
        Notes="";
    }
    
    public Location(string building, string roomNumber, string notes)
    {
        Building = building;
        RoomNumber = roomNumber;
        Notes = notes;
    }
    
    public Guid Id { get; protected set; }
    public string Building { get; set; }
    public string RoomNumber { get; set; }
    public string Notes { get; set; } 

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Building;
        yield return RoomNumber;
        yield return Notes;
    }

    public override string ToString(){
        return Building+", "+ RoomNumber +", " + Notes;
    }
}
