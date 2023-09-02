using Domain.Enums;
using Entities = Domain.Entities;

namespace Application.Guest.DTO;


public class GuestDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string IdNumber { get; set; } = null!;
    public int IdTypeCode { get; set; }

    public static Entities.Guest MapToEntity(GuestDTO guestDTO) => new Entities.Guest
    {
        Id = guestDTO.Id,
        Name = guestDTO.Name,
        Surname = guestDTO.Surname,
        Email = guestDTO.Email,
        DocumentId = new Domain.ValueObjects.PersonId
        {
            IdNumber = guestDTO.IdNumber,
            DocumentType = (DocumentType)guestDTO.IdTypeCode
        }
    };

}

