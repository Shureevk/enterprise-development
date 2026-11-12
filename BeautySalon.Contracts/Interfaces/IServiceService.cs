using BeautySalon.Contracts.Services;

namespace BeautySalon.Contracts.Interfaces;

/// <summary>
/// Контракт сервиса ServiceService
/// </summary>
public interface IServiceService
{
    /// <summary>
    /// Получить список объектов
    /// </summary>
    IReadOnlyList<ServiceResponse> GetAll();

    /// <summary>
    /// Получить объект по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    ServiceResponse GetById(int id);

    /// <summary>
    /// Создать объект
    /// </summary>
    /// <param name="request">Данные объекта</param>
    ServiceResponse Create(SaveServiceRequest request);

    /// <summary>
    /// Обновить объект
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    /// <param name="request">Новые данные объекта</param>
    void Update(int id, SaveServiceRequest request);

    /// <summary>
    /// Удалить объект
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    void Delete(int id);
}