using System;

<<<<<<< HEAD
namespace Dsw2026Tpi.Domain.Entities;

=======
>>>>>>> development
public class Doctor : EntityBase
{
    public string Name { get; private set; }
    public string LicenseNumber { get; private set; }
    public bool IsActive { get; private set; }
<<<<<<< HEAD
    public bool Deleted { get; private set; }
    public Guid? SpecialityId { get; set; }
    public virtual Speciality? Speciality { get; private set; }

    private readonly List<AvailabilitySlot> _availabilitySlots = new();
=======
    public Guid? SpecialityId { get; private set; }
    public Speciality? Speciality { get; private set; }
>>>>>>> development

#pragma warning disable CS8618
    private Doctor() { }
#pragma warning restore CS8618

    public Doctor(string name, string licenseNumber, Speciality speciality, Guid? id = null) : base(id)
    {
        Name = name;
        LicenseNumber = licenseNumber;
        Speciality = speciality;
        SpecialityId = speciality.Id;
        IsActive = true;
<<<<<<< HEAD
        Deleted = false;
    }

    public void Deactivate() => IsActive = false;
    public void Delete() => Deleted = true;

    public void AddAvailabilitySlot(AvailabilitySlot slot)
=======

    }
    public void Update(string name, string licenseNumber, Speciality speciality)
    {
        Name = name;
        LicenseNumber = licenseNumber;
        Speciality = speciality;
        SpecialityId = speciality.Id;
    }
    public void Deactivate()
>>>>>>> development
    {
        _availabilitySlots.Add(slot);
    }
<<<<<<< HEAD
}
=======

  
}
>>>>>>> development
