using BeautySalon.Contracts.Interfaces;
using BeautySalon.Application.Services;
using BeautySalon.Contracts.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.Api.Controllers;

/// <summary>
/// HTTP операции для ресурса appointments
/// </summary>
/// <param name="service">Сервис приложения</param>

[ApiController]
[Route("api/appointments")]
[Produces("application/json")]
public sealed class AppointmentsController(
    IAppointmentService service) : ControllerBase
{
    /// <summary>
    /// Получить список объектов
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<AppointmentResponse>), StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyList<AppointmentResponse>> GetAll()
    {
        return Ok(service.GetAll());
    }

    /// <summary>
    /// Получить объект по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(AppointmentResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public ActionResult<AppointmentResponse> GetById(int id)
    {
        return Ok(service.GetById(id));
    }

    /// <summary>
    /// Создать объект
    /// </summary>
    /// <param name="request">Данные объекта</param>
    [HttpPost]
    [ProducesResponseType(typeof(AppointmentResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    public ActionResult<AppointmentResponse> Create(SaveAppointmentRequest request)
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
    public IActionResult Update(int id, SaveAppointmentRequest request)
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

}
