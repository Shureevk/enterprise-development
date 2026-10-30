using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Contracts.Services;

/// <summary>
/// Данные услуги для создания или обновления
/// </summary>
public sealed class SaveServiceRequest
{
    /// <summary>
    /// Название услуги
    /// </summary>
    [Required]
    [StringLength(150)]
    public string? Name { get; init; }

    /// <summary>
    /// Категория услуги
    /// </summary>
    [Required]
    [StringLength(100)]
    public string? Category { get; init; }

    /// <summary>
    /// Стоимость в рублях
    /// </summary>
    [Required]
    [Range(typeof(decimal), "0", "1000000")]
    public decimal? Price { get; init; }

    /// <summary>
    /// Продолжительность в минутах
    /// </summary>
    [Required]
    [Range(1, 1440)]
    public int? DurationMinutes { get; init; }
}