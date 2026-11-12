using BeautySalon.Contracts.Customers;

namespace BeautySalon.Contracts.Interfaces;

/// <summary>
/// Контракт сервиса CustomerService
/// </summary>
public interface ICustomerService
{
    /// <summary>
    /// Получить список объектов
    /// </summary>
    IReadOnlyList<CustomerResponse> GetAll();

    /// <summary>
    /// Получить объект по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    CustomerResponse GetById(int id);

    /// <summary>
    /// Создать объект
    /// </summary>
    /// <param name="request">Данные объекта</param>
    CustomerResponse Create(SaveCustomerRequest request);

    /// <summary>
    /// Обновить объект
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    /// <param name="request">Новые данные объекта</param>
    void Update(int id, SaveCustomerRequest request);

    /// <summary>
    /// Удалить объект
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    void Delete(int id);
}