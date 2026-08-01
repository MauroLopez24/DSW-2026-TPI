using Dsw2026Tpi.Application.Dtos;
using Dsw2026Tpi.Application.Interfaces;
using Dsw2026Tpi.CrossCutting.Exceptions;
using Dsw2026Tpi.CrossCutting.Resources;
using Dsw2026Tpi.Domain.Entities;
using Dsw2026Tpi.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Dsw2026Tpi.Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IPersistence _persistence;
    private readonly ILogger<DoctorService> _logger;

    public DoctorService(IPersistence persistence, ILogger<DoctorService> logger)
    {
        _persistence = persistence;
        _logger = logger;
    }

    public async Task<Pagination<DoctorModel.Response>> GetAll(int pageSize, int pageIndex, string? name = null)
    {
<<<<<<< HEAD
        var doctors = await _persistence.Paginate<Doctor, string>(
            pageSize,
            pageIndex,
            d => (string.IsNullOrWhiteSpace(name) || d.Name.Contains(name)) && !d.Deleted,
            d => d.Name,
            nameof(Doctor.Speciality));
=======
        var doctors = await _persistence.Paginate<Doctor, string>(pageSize,pageIndex, d => d.IsActive && (string.IsNullOrWhiteSpace(name) ||
                  d.Name.Contains(name)), d => d.Name, nameof(Doctor.Speciality));
>>>>>>> development

        return doctors.Map(d => new DoctorModel.Response(
            d.Id,
            d.Name,
            d.LicenseNumber,
            new DoctorModel.SpecialityDto(d.Speciality?.Id, d.Speciality?.Name)));
    }

<<<<<<< HEAD
    public async Task<DoctorModel.Response?> GetById(Guid id)
    {
        var doctor = await _persistence.GetById<Doctor>(id, nameof(Doctor.Speciality));
        if (doctor is null || doctor.Deleted)
            return null;

        return new DoctorModel.Response(
            doctor.Id,
            doctor.Name,
            doctor.LicenseNumber,
            new DoctorModel.SpecialityDto(doctor.Speciality?.Id, doctor.Speciality?.Name));
    }

    public async Task<DoctorModel.Response> Create(DoctorModel.Request request)
    {
        ValidateRequest(request);

        var specialty = await _persistence.GetById<Speciality>(request.SpecialityId);
        if (specialty is null || specialty.Deleted)
            throw new EntityNotFoundException(nameof(Speciality));

        var doctor = new Doctor(request.Name, request.LicenseNumber, specialty);
        await _persistence.Add(doctor);

        _logger.LogInformation("Médico creado: {Name} (Id: {Id})", doctor.Name, doctor.Id);

        return new DoctorModel.Response(
            doctor.Id,
            doctor.Name,
            doctor.LicenseNumber,
            new DoctorModel.SpecialityDto(specialty.Id, specialty.Name));
=======
    public async Task<DoctorModel.Response> Create(DoctorModel.Request request)
    {
        await ValidateRequest(request);

        var speciality =await _persistence.GetById<Speciality>(request.SpecialityId);

        if (speciality is null)
        {
            throw new EntityNotFoundException(nameof(Speciality));
        }

        var doctor = new Doctor(request.Name,request.LicenseNumber, speciality);

        await _persistence.Add(doctor);
        return MapResponse(doctor);
>>>>>>> development
    }

    public async Task<DoctorModel.Response> Update(Guid id, DoctorModel.Request request)
    {
<<<<<<< HEAD
        ValidateRequest(request);

        var doctor = await _persistence.GetById<Doctor>(id, nameof(Doctor.Speciality));
        if (doctor is null || doctor.Deleted)
            throw new EntityNotFoundException(nameof(Doctor));

        var specialty = await _persistence.GetById<Speciality>(request.SpecialityId);
        if (specialty is null || specialty.Deleted)
            throw new EntityNotFoundException(nameof(Speciality));

        var updatedDoctor = new Doctor(request.Name, request.LicenseNumber, specialty, id);
        await _persistence.Update(updatedDoctor);

        _logger.LogInformation("Médico actualizado: {Name} (Id: {Id})", updatedDoctor.Name, updatedDoctor.Id);

        return new DoctorModel.Response(
            updatedDoctor.Id,
            updatedDoctor.Name,
            updatedDoctor.LicenseNumber,
            new DoctorModel.SpecialityDto(specialty.Id, specialty.Name));
=======
        var doctor = await _persistence.GetById<Doctor>(id, nameof(Doctor.Speciality));

        if (doctor is null || !doctor.IsActive)
        {
            throw new EntityNotFoundException(nameof(Doctor));
        }

        await ValidateRequest(request, id);

        var speciality = await _persistence.GetById<Speciality>(request.SpecialityId);

        if (speciality is null)
        {
            throw new EntityNotFoundException(nameof(Speciality));
        }

        doctor.Update(request.Name, request.LicenseNumber, speciality);

        await _persistence.Update(doctor);

        return MapResponse(doctor);
>>>>>>> development
    }

    public async Task Delete(Guid id)
    {
        var doctor = await _persistence.GetById<Doctor>(id);
<<<<<<< HEAD
        if (doctor is null || doctor.Deleted)
            throw new EntityNotFoundException(nameof(Doctor));

        doctor.Delete();
        await _persistence.Update(doctor);

        _logger.LogInformation("Médico eliminado (soft): {Name} (Id: {Id})", doctor.Name, doctor.Id);
    }

    private static void ValidateRequest(DoctorModel.Request request)
    {
        if (string.IsNullOrWhiteSpace(request.Name) || request.Name.Length < 3 || request.Name.Length > 100)
            throw new ValidationException("El nombre debe tener entre 3 y 100 caracteres", nameof(ErrorCodes.VALIDATION_ERROR));
=======

        if (doctor is null || !doctor.IsActive)
        {
            throw new EntityNotFoundException(nameof(Doctor));
        }

        doctor.Deactivate();

        await _persistence.Update(doctor);
    }

    private async Task ValidateRequest(DoctorModel.Request request,Guid? id = null)
    {
        if (string.IsNullOrWhiteSpace(request.Name) || request.Name.Length < 3 || request.Name.Length > 100)
        {
            throw new ValidationException("El nombre debe tener entre 3 y 100 caracteres.", nameof(ErrorCodes.VALIDATION_ERROR));
        }

        if (string.IsNullOrWhiteSpace(request.LicenseNumber))
        {
            throw new ValidationException("La matrícula es obligatoria.", nameof(ErrorCodes.VALIDATION_ERROR));
        }

        if (request.SpecialityId == Guid.Empty)
        {
            throw new ValidationException( "La especialidad es obligatoria.", nameof(ErrorCodes.VALIDATION_ERROR));
        }

        var existing =await _persistence.First<Doctor>(d => d.LicenseNumber == request.LicenseNumber);
        if (existing is not null && existing.Id != id)
        {
            throw new ConflictException("DOCTOR_ALREADY_EXISTS","Ya existe un médico con esa matrícula.");
        }
    }

    private static DoctorModel.Response MapResponse(Doctor doctor)
    {
        return new DoctorModel.Response(doctor.Id, doctor.Name, doctor.LicenseNumber,new DoctorModel.SpecialityDto(doctor.Speciality?.Id, doctor.Speciality?.Name));
>>>>>>> development
    }
}
