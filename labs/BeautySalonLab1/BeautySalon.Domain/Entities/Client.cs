namespace BeautySalon.Domain.Entities;

/// <summary>
/// Клиент салона красоты
/// </summary>
public class Client : Person
{
    /// <summary>
    /// Номер телефона клиента
    /// </summary>
    public required string PhoneNumber { get; set; }
}
