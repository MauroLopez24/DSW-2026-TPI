<<<<<<< HEAD
﻿using System;

namespace Dsw2026Tpi.Domain.Entities;

public class AvailabilitySlot : EntityBase
{
    public Guid DoctorId { get; private set; }
    public virtual Doctor Doctor { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public bool IsBooked { get; private set; }
    public bool Deleted { get; private set; }

    public virtual Appointment? Appointment { get; private set; }
=======
namespace Dsw2026Tpi.Domain.Entities;
using Dsw2026Tpi.CrossCutting.Identity;

public class AvailabilitySlot : EntityBase
{
    public Guid AvailabilityRuleId { get; private set; }
    public AvailabilityRule? AvailabilityRule { get; private set; }
    public DateOnly SlotDate { get; private set; }
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set; }
    public string Status { get; private set; }
>>>>>>> development

#pragma warning disable CS8618
    private AvailabilitySlot() { }
#pragma warning restore CS8618

<<<<<<< HEAD
    public AvailabilitySlot(Guid doctorId, DateTime startTime, DateTime endTime, Guid? id = null) : base(id)
    {
        DoctorId = doctorId;
        StartTime = startTime;
        EndTime = endTime;
        IsBooked = false;
        Deleted = false;
    }

    public void Book() => IsBooked = true;
    public void Release() => IsBooked = false;
    public void Delete() => Deleted = true;
}
=======
    public AvailabilitySlot(Guid availabilityRuleId, DateOnly slotDate, TimeOnly startTime, TimeOnly endTime, Guid? id = null) : base(id)
    {
        AvailabilityRuleId = availabilityRuleId;
        SlotDate = slotDate;
        StartTime = startTime;
        EndTime = endTime;
        Status = AvailabilitySlotStatus.Available;
    }
}
>>>>>>> development
