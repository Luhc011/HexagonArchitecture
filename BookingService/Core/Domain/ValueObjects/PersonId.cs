using Domain.Enums;

namespace Domain.ValueObjects;

public class PersonId
{
    public string IdNumber { get; set; } = null!;
    public DocumentType DocumentType { get; set; }
}
