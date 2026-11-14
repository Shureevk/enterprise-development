using BeautySalon.Domain.Entities;
using BeautySalon.Domain.Repositories;

namespace BeautySalon.Infrastructure.InMemory.Repositories;

/// <summary>
/// Репозиторий сущностей Appointment
/// </summary>
/// <param name="storage">Общее хранилище салона</param>
public sealed class AppointmentRepository(SalonStorage storage)
    : InMemoryRepository<Appointment>(storage, storage.Appointments, EntityCopies.Copy), IAppointmentRepository
{
    /// <inheritdoc />
    protected override void PrepareForSave(Appointment saved, Appointment? current)
    {
        saved.Customer = Storage.Customers.FirstOrDefault(item => item.Id == saved.Customer.Id)
            ?? throw new ArgumentException("Посетитель не найден");
        saved.Specialist = Storage.Specialists.FirstOrDefault(item => item.Id == saved.Specialist.Id)
            ?? throw new ArgumentException("Специалист не найден");
        saved.Service = Storage.Services.FirstOrDefault(item => item.Id == saved.Service.Id)
            ?? throw new ArgumentException("Услуга не найдена");
        ValidateSchedule(saved, current?.Id);
    }

    /// <inheritdoc />
    protected override void ApplyChanges(Appointment current, Appointment saved)
    {
        current.Customer = saved.Customer;
        current.Specialist = saved.Specialist;
        current.Service = saved.Service;
        current.AppointmentDateTime = saved.AppointmentDateTime;
        current.IsRegularCustomer = saved.IsRegularCustomer;
    }

    private void ValidateSchedule(Appointment appointment, int? excludedId)
    {
        var start = appointment.AppointmentDateTime;
        var duration = appointment.Service.DurationMinutes;

        if (start == DateTime.MinValue || duration <= 0 ||
            start > DateTime.MaxValue.AddMinutes(-duration))
        {
            throw new ArgumentException("Дата или длительность услуги указана некорректно");
        }

        var end = start.AddMinutes(duration);

        var hasConflict = Storage.Appointments.Any(existing =>
            existing.Id != excludedId &&
            (existing.Specialist.Id == appointment.Specialist.Id ||
             existing.Customer.Id == appointment.Customer.Id) &&
            start < existing.AppointmentDateTime.AddMinutes(existing.Service.DurationMinutes) &&
            existing.AppointmentDateTime < end);

        if (hasConflict)
        {
            throw new InvalidOperationException("Посетитель или специалист занят в выбранное время");
        }
    }
}
