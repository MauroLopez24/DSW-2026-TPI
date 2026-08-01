using System;

namespace Dsw2026Tpi.Domain.Entities;

public class Speciality : EntityBase
{
<<<<<<< HEAD
    public string Name { get; init; }
    public string Description { get; init; }
    public bool Deleted { get; private set; }
=======
    public string Name { get; private set; }
    public string Description { get; private set; }
>>>>>>> development

#pragma warning disable CS8618
    private Speciality() { }
#pragma warning restore CS8618

    public Speciality(string name, string description, Guid? id = null) : base(id)
    {
        Name = name;
        Description = description;
        Deleted = false;
    }

<<<<<<< HEAD
    public void Delete() => Deleted = true;
}
=======
    public void Update(string name, string description)
    {
        Name = name;
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }
}
>>>>>>> development
