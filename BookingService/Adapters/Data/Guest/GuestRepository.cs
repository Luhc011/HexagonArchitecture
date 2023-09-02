using Domain.Ports;

namespace Data.Guest;

public class GuestRepository : IGuestRepository
{
    private readonly HotelDbContext _context;

    public GuestRepository(HotelDbContext context)
    {
        _context = context;
    }

    public async Task<int> Create(Domain.Entities.Guest guest)
    {
        _context.Guests.Add(guest);
        await _context.SaveChangesAsync();
        return guest.Id;
    }

    public Task<Domain.Entities.Guest> Get(int id)
    {
        throw new NotImplementedException();
    }
}
