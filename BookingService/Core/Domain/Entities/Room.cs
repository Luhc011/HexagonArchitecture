using Domain.ValueObjects;

namespace Domain.Entities;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Level { get; set; }
    public bool InMaintenance { get; set; }
    public Price Price { get; set; } = null!;
    public bool IsAvailable
    {
        get
        {
            if (InMaintenance || HasGuest)
                return false;
            return true;
        }
    }

    public bool HasGuest
    {
        get
        {
            return true;
        }
    }
}
