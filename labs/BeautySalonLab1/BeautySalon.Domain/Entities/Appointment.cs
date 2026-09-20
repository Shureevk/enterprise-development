namespace BeautySalon.Domain.Entities;

/// <summary>
/// Запись клиента на услугу к мастеру
/// </summary>
public class Appointment
{
    /// <summary>
    /// Уникальный идентификатор записи
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Клиент.
    /// </summary>
    public required Client Client { get; set; }

    /// <summary>
    /// Мастер
    /// </summary>
    public required Master Master { get; set; }

    /// <summary>
    /// Услуга
    /// </summary>
    public required Service Service { get; set; }

    /// <summary>
    /// Дата и время начала услуги
    /// </summary>
    public required DateTime AppointmentDateTime { get; set; }

    /// <summary>
    /// Признак постоянного клиента
    /// </summary>
    public required bool IsRegularClient { get; set; }
}
