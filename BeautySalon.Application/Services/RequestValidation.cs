using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Application.Services;

/// <summary>
/// Проверка данных перед выполнением операции
/// </summary>
internal static class RequestValidation
{
    internal static void Validate(object request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var results = new List<ValidationResult>();
        if (!Validator.TryValidateObject(
            request, new ValidationContext(request), results, true))
        {
            throw new ArgumentException(
                string.Join("; ", results.Select(result => result.ErrorMessage)));
        }
    }

    internal static void ValidateBirthDate(DateOnly date)
    {
        if (date == DateOnly.MinValue ||
            date > DateOnly.FromDateTime(DateTime.Today))
        {
            throw new ArgumentException("Дата рождения указана некорректно");
        }
    }
}