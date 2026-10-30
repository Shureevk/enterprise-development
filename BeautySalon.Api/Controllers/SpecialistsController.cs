using BeautySalon.Application.Services;
using BeautySalon.Contracts.Specialists;
using BeautySalon.Contracts.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.Api.Controllers;

/// <summary>
/// HTTP операции для ресурса specialists
/// </summary>
/// <param name="service">Сервис приложения</param>
/// <param name="appointments">Сервис записей</param>
[ApiController]
[Route("api/specialists")]
[Produces("application/json")]
public sealed class SpecialistsController(
    SpecialistService service, AppointmentService appointments) : ControllerBase
{
    /// <summary>
    /// Получить список объектов
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<SpecialistResponse>), StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyList<SpecialistResponse>> GetAll()
    {
        return Ok(service.GetAll());
    }

    /// <summary>
    /// Получить объект по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(SpecialistResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public ActionResult<SpecialistResponse> GetById(int id)
    {
        return Ok(service.GetById(id));
    }

    /// <summary>
    /// Создать объект
    /// </summary>
    /// <param name="request">Данные объекта</param>
    [HttpPost]
    [ProducesResponseType(typeof(SpecialistResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    public ActionResult<SpecialistResponse> Create(SaveSpecialistRequest request)
    {
        var result = service.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary>
    /// Полностью обновить объект
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    /// <param name="request">Новые данные объекта</param>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    public IActionResult Update(int id, SaveSpecialistRequest request)
    {
        service.Update(id, request);
        return NoContent();
    }

    /// <summary>
    /// Удалить объект
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    public IActionResult Delete(int id)
    {
        service.Delete(id);
        return NoContent();
    }

    /// <summary>
    /// Получить связанные записи
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    [HttpGet("{id:int}/appointments")]
    [ProducesResponseType(typeof(IReadOnlyList<AppointmentResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public ActionResult<IReadOnlyList<AppointmentResponse>> GetAppointments(int id)
    {
        return Ok(appointments.GetBySpecialist(id));
    }
}