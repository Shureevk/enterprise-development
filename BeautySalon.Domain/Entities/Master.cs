namespace BeautySalon.Domain.Entities;

/// <summary>
/// Мастер салона красоты
/// </summary>
public class Master : Person
{
    /// <summary>
    /// Номер паспорта
    /// </summary>
    public required string PassportNumber { get; set; }

    /// <summary>
    /// Специализация мастера
    /// </summary>
    public required string Specialization { get; set; }

    /// <summary>
    /// Стаж работы в годах
    /// </summary>
    public required int WorkExperience { get; set; }
}
