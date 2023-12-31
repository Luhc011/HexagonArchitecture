﻿using Domain.ValueObjects;

namespace Domain.Entities;

public class Guest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public PersonId DocumentId { get; set; } = null!;
}
