using BeautySalon.Contracts.Appointments;

namespace BeautySalon.Contracts.Interfaces;

/// <summary>
/// Контракт сервиса AppointmentService
/// </summary>
public interface IAppointmentService
{
    /// <summary>
    /// Получить все записи
    /// </summary>
    IReadOnlyList<AppointmentResponse> GetAll();

    /// <summary>
    /// Получить запись по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор записи</param>
    AppointmentResponse GetById(int id);

    /// <summary>
    /// Создать запись
    /// </summary>
    /// <param name="request">Данные записи</param>
    AppointmentResponse Create(SaveAppointmentRequest request);

    /// <summary>
    /// Изменить запись
    /// </summary>
    /// <param name="id">Идентификатор записи</param>
    /// <param name="request">Новые данные записи</param>
    void Update(int id, SaveAppointmentRequest request);

    /// <summary>
    /// Удалить запись
    /// </summary>
    /// <param name="id">Идентификатор записи</param>
    void Delete(int id);

    /// <summary>
    /// Получить записи посетителя
    /// </summary>
    /// <param name="id">Идентификатор посетителя</param>
    IReadOnlyList<AppointmentResponse> GetByCustomer(int id);

    /// <summary>
    /// Получить записи специалиста
    /// </summary>
    /// <param name="id">Идентификатор специалиста</param>
    IReadOnlyList<AppointmentResponse> GetBySpecialist(int id);

    /// <summary>
    /// Получить записи на услугу
    /// </summary>
    /// <param name="id">Идентификатор услуги</param>
    IReadOnlyList<AppointmentResponse> GetByService(int id);
}