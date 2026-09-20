using BeautySalon.Domain.Data;

namespace BeautySalon.Tests;

/// <summary>
/// Unit-тесты запросов к данным салона красоты
/// </summary>
public class QueriesTests
{
    /// <summary>
    /// 1 Вывести информацию о всех мастерах, стаж работы которых не менее 5 лет
    /// </summary>
    [Fact]
    public void GetMastersWithFiveOrMoreYearsOfExperience()
    {
        var result = BeautySalonData.Masters
            .Where(master => master.WorkExperience >= 5)
            .ToList();

        Assert.Equal(7, result.Count);
        Assert.All(result, master => Assert.True(master.WorkExperience >= 5));
    }

    /// <summary>
    /// 2 Вывести информацию обо всех окошках выбранного мастера
    /// Окошком считается промежуток между двумя последовательными записями.
    /// </summary>
    [Fact]
    public void GetFreeWindowsForSelectedMaster()
    {
        var selectedMasterId = 2;

        var selectedDate = DateTime.Today.AddDays(2).Date;

        var appointments = BeautySalonData.Appointments
            .Where(appointment => appointment.Master.Id == selectedMasterId &&
                                  appointment.AppointmentDateTime.Date == selectedDate)
            .OrderBy(appointment => appointment.AppointmentDateTime)
            .ToList();

        var windows = appointments
            .Zip(appointments.Skip(1), (first, second) =>
                new
                {
                    Start = first.AppointmentDateTime,
                    End = second.AppointmentDateTime,
                    Duration = second.AppointmentDateTime - first.AppointmentDateTime
                })
            .Where(window => window.Duration > TimeSpan.Zero)
            .ToList();

        Assert.Equal(3, windows.Count);
        Assert.Equal(TimeSpan.FromHours(2), windows[0].Duration);
        Assert.Equal(TimeSpan.FromHours(4), windows[1].Duration);
        Assert.Equal(TimeSpan.FromHours(2.5), windows[2].Duration);
    }

    /// <summary>
    /// 3 Вывести топ 5 наиболее популярных услуг
    /// </summary>
    [Fact]
    public void GetTopFivePopularServices()
    {
        var result = BeautySalonData.Appointments
            .GroupBy(appointment => appointment.Service.Id)
            .OrderByDescending(group => group.Count())
            .ThenBy(group => group.Key)
            .Take(5)
            .Select(group => group.Key)
            .ToList();

        Assert.Equal(new[] { 1, 4, 2, 6, 7 }, result);
    }

    /// <summary>
    /// 4 Вывести информацию о количестве повторных записей клиентов за последний месяц
    /// </summary>
    [Fact]
    public void GetNumberOfClientsWithRepeatedAppointmentsDuringLastMonth()
    {
        var startDate = DateTime.Today.AddMonths(-1);

        var result = BeautySalonData.Appointments
            .Where(appointment => appointment.AppointmentDateTime >= startDate &&
                                  appointment.AppointmentDateTime <= DateTime.Now)
            .GroupBy(appointment => appointment.Client.Id)
            .Where(group => group.Count() > 1)
            .ToList();

        Assert.Equal(10, result.Count);
    }

    /// <summary>
    /// 5 Вывести информацию о клиентах, записанных к нескольким мастерам,
    /// упорядочить по дате рождения
    /// </summary>
    [Fact]
    public void GetClientsAssignedToSeveralMastersOrderedByBirthDate()
    {
        var result = BeautySalonData.Appointments
            .GroupBy(appointment => appointment.Client.Id)
            .Where(group => group.Select(appointment => appointment.Master.Id).Distinct().Count() > 1)
            .Select(group => group.First().Client)
            .OrderBy(client => client.DateOfBirth)
            .ToList();

        Assert.Equal(10, result.Count);
        Assert.Equal(
            new[] { 9, 5, 4, 8, 2, 6, 1, 7, 3, 10 },
            result.Select(client => client.Id));
    }
}
