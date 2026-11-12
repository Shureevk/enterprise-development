using BeautySalon.Contracts.Specialists;

namespace BeautySalon.Contracts.Interfaces;

/// <summary>
/// Контракт сервиса SpecialistService
/// </summary>
public interface ISpecialistService
{
    /// <summary>
    /// Получить список объектов
    /// </summary>
    IReadOnlyList<SpecialistResponse> GetAll();

    /// <summary>
    /// Получить объект по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    SpecialistResponse GetById(int id);

    /// <summary>
    /// Создать объект
    /// </summary>
    /// <param name="request">Данные объекта</param>
    SpecialistResponse Create(SaveSpecialistRequest request);

    /// <summary>
    /// Обновить объект
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    /// <param name="request">Новые данные объекта</param>
    void Update(int id, SaveSpecialistRequest request);

    /// <summary>
    /// Удалить объект
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    void Delete(int id);
}