using BeautySalon.Domain.Entities;
using BeautySalon.Domain.Shared.Enums;

namespace BeautySalon.Domain.Data;

/// <summary>
/// Тестовые данные предметной области салона красоты
/// </summary>
public static class BeautySalonData
{
    private static readonly DateTime Today = DateTime.Today;

    /// <summary>
    /// Клиенты салона
    /// </summary>
    public static List<Client> Clients { get; } =
    [
        new() { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Сергеевич", Gender = Gender.Male, DateOfBirth = new DateOnly(1998, 2, 14), PhoneNumber = "+79000000001" },
        new() { Id = 2, LastName = "Петрова", FirstName = "Анна", Patronymic = "Игоревна", Gender = Gender.Female, DateOfBirth = new DateOnly(1995, 6, 21), PhoneNumber = "+79000000002" },
        new() { Id = 3, LastName = "Соколова", FirstName = "Мария", Patronymic = "Андреевна", Gender = Gender.Female, DateOfBirth = new DateOnly(2001, 1, 9), PhoneNumber = "+79000000003" },
        new() { Id = 4, LastName = "Кузнецов", FirstName = "Дмитрий", Patronymic = "Олегович", Gender = Gender.Male, DateOfBirth = new DateOnly(1992, 11, 3), PhoneNumber = "+79000000004" },
        new() { Id = 5, LastName = "Морозова", FirstName = "Ольга", Patronymic = "Викторовна", Gender = Gender.Female, DateOfBirth = new DateOnly(1989, 8, 17), PhoneNumber = "+79000000005" },
        new() { Id = 6, LastName = "Волков", FirstName = "Максим", Patronymic = "Алексеевич", Gender = Gender.Male, DateOfBirth = new DateOnly(1997, 4, 28), PhoneNumber = "+79000000006" },
        new() { Id = 7, LastName = "Орлова", FirstName = "Елена", Patronymic = "Дмитриевна", Gender = Gender.Female, DateOfBirth = new DateOnly(2000, 9, 12), PhoneNumber = "+79000000007" },
        new() { Id = 8, LastName = "Смирнов", FirstName = "Алексей", Patronymic = "Романович", Gender = Gender.Male, DateOfBirth = new DateOnly(1994, 12, 1), PhoneNumber = "+79000000008" },
        new() { Id = 9, LastName = "Федорова", FirstName = "Наталья", Patronymic = "Сергеевна", Gender = Gender.Female, DateOfBirth = new DateOnly(1987, 3, 25), PhoneNumber = "+79000000009" },
        new() { Id = 10, LastName = "Никитин", FirstName = "Артем", Patronymic = null, Gender = Gender.Male, DateOfBirth = new DateOnly(2002, 7, 30), PhoneNumber = "+79000000010" }
    ];

    /// <summary>
    /// Мастера салона
    /// </summary>
    public static List<Master> Masters { get; } =
    [
        new() { Id = 1, LastName = "Крылова", FirstName = "Алина", Patronymic = "Павловна", Gender = Gender.Female, DateOfBirth = new DateOnly(1990, 2, 11), PassportNumber = "4501000001", Specialization = "Парикмахер", WorkExperience = 3 },
        new() { Id = 2, LastName = "Семенова", FirstName = "Ирина", Patronymic = "Владимировна", Gender = Gender.Female, DateOfBirth = new DateOnly(1988, 5, 19), PassportNumber = "4501000002", Specialization = "Колорист", WorkExperience = 5 },
        new() { Id = 3, LastName = "Михайлов", FirstName = "Роман", Patronymic = "Ильич", Gender = Gender.Male, DateOfBirth = new DateOnly(1987, 9, 4), PassportNumber = "4501000003", Specialization = "Барбер", WorkExperience = 7 },
        new() { Id = 4, LastName = "Белова", FirstName = "Екатерина", Patronymic = "Олеговна", Gender = Gender.Female, DateOfBirth = new DateOnly(1992, 1, 27), PassportNumber = "4501000004", Specialization = "Мастер маникюра", WorkExperience = 9 },
        new() { Id = 5, LastName = "Зайцев", FirstName = "Денис", Patronymic = "Андреевич", Gender = Gender.Male, DateOfBirth = new DateOnly(1985, 6, 8), PassportNumber = "4501000005", Specialization = "Массажист", WorkExperience = 12 },
        new() { Id = 6, LastName = "Орлова", FirstName = "Марина", Patronymic = "Игоревна", Gender = Gender.Female, DateOfBirth = new DateOnly(1991, 10, 15), PassportNumber = "4501000006", Specialization = "Бровист", WorkExperience = 4 },
        new() { Id = 7, LastName = "Громов", FirstName = "Николай", Patronymic = "Сергеевич", Gender = Gender.Male, DateOfBirth = new DateOnly(1986, 12, 22), PassportNumber = "4501000007", Specialization = "Парикмахер", WorkExperience = 6 },
        new() { Id = 8, LastName = "Власова", FirstName = "Светлана", Patronymic = "Алексеевна", Gender = Gender.Female, DateOfBirth = new DateOnly(1993, 4, 16), PassportNumber = "4501000008", Specialization = "Визажист", WorkExperience = 8 },
        new() { Id = 9, LastName = "Фролов", FirstName = "Евгений", Patronymic = "Максимович", Gender = Gender.Male, DateOfBirth = new DateOnly(1989, 7, 7), PassportNumber = "4501000009", Specialization = "Массажист", WorkExperience = 10 },
        new() { Id = 10, LastName = "Романова", FirstName = "Дарья", Patronymic = "Артемовна", Gender = Gender.Female, DateOfBirth = new DateOnly(1996, 3, 13), PassportNumber = "4501000010", Specialization = "Мастер маникюра", WorkExperience = 2 }
    ];

    /// <summary>
    /// Справочник услуг
    /// </summary>
    public static List<Service> Services { get; } =
    [
        new() { Id = 1, Name = "Женская стрижка", Category = "Волосы", Price = 2500m, DurationMinutes = 90 },
        new() { Id = 2, Name = "Мужская стрижка", Category = "Волосы", Price = 1800m, DurationMinutes = 60 },
        new() { Id = 3, Name = "Окрашивание волос", Category = "Волосы", Price = 5500m, DurationMinutes = 180 },
        new() { Id = 4, Name = "Маникюр", Category = "Ногтевой сервис", Price = 2200m, DurationMinutes = 90 },
        new() { Id = 5, Name = "Педикюр", Category = "Ногтевой сервис", Price = 2800m, DurationMinutes = 100 },
        new() { Id = 6, Name = "Макияж", Category = "Макияж", Price = 3500m, DurationMinutes = 90 },
        new() { Id = 7, Name = "Коррекция бровей", Category = "Брови", Price = 1200m, DurationMinutes = 40 },
        new() { Id = 8, Name = "Массаж лица", Category = "Уход", Price = 2000m, DurationMinutes = 60 },
        new() { Id = 9, Name = "Расслабляющий массаж", Category = "Массаж", Price = 4000m, DurationMinutes = 90 },
        new() { Id = 10, Name = "Укладка", Category = "Волосы", Price = 2000m, DurationMinutes = 60 }
    ];

    /// <summary>
    /// Записи клиентов на услуги
    /// </summary>
    public static List<Appointment> Appointments { get; } =
    [
        // Мастер 2: четыре записи в текущем месяце с двумя свободными промежутками
        new() { Id = 1, Client = Clients[0], Master = Masters[1], Service = Services[0], AppointmentDateTime = Day(2, 9, 0), IsRegularClient = true },
        new() { Id = 2, Client = Clients[1], Master = Masters[1], Service = Services[3], AppointmentDateTime = Day(2, 11, 0), IsRegularClient = true },
        new() { Id = 3, Client = Clients[2], Master = Masters[1], Service = Services[2], AppointmentDateTime = Day(2, 15, 0), IsRegularClient = false },
        new() { Id = 4, Client = Clients[3], Master = Masters[1], Service = Services[0], AppointmentDateTime = Day(2, 17, 30), IsRegularClient = false },

        // Популярность услуг: услуга 1 - 8 записей, услуга 4 - 6, услуга 2 - 5, услуга 6 - 4, услуга 7 - 3
        new() { Id = 5, Client = Clients[0], Master = Masters[0], Service = Services[0], AppointmentDateTime = Day(-40, 10, 0), IsRegularClient = true },
        new() { Id = 6, Client = Clients[4], Master = Masters[2], Service = Services[0], AppointmentDateTime = Day(-35, 11, 0), IsRegularClient = true },
        new() { Id = 7, Client = Clients[5], Master = Masters[3], Service = Services[0], AppointmentDateTime = Day(-30, 12, 0), IsRegularClient = false },
        new() { Id = 8, Client = Clients[6], Master = Masters[6], Service = Services[0], AppointmentDateTime = Day(-25, 13, 0), IsRegularClient = true },
        new() { Id = 9, Client = Clients[7], Master = Masters[7], Service = Services[0], AppointmentDateTime = Day(-20, 14, 0), IsRegularClient = false },
        new() { Id = 10, Client = Clients[8], Master = Masters[8], Service = Services[0], AppointmentDateTime = Day(-15, 15, 0), IsRegularClient = true },
        new() { Id = 11, Client = Clients[9], Master = Masters[0], Service = Services[0], AppointmentDateTime = Day(-10, 16, 0), IsRegularClient = false },

        new() { Id = 12, Client = Clients[1], Master = Masters[3], Service = Services[3], AppointmentDateTime = Day(-32, 10, 0), IsRegularClient = true },
        new() { Id = 13, Client = Clients[2], Master = Masters[3], Service = Services[3], AppointmentDateTime = Day(-28, 11, 0), IsRegularClient = true },
        new() { Id = 14, Client = Clients[3], Master = Masters[9], Service = Services[3], AppointmentDateTime = Day(-24, 12, 0), IsRegularClient = false },
        new() { Id = 15, Client = Clients[4], Master = Masters[3], Service = Services[3], AppointmentDateTime = Day(-18, 13, 0), IsRegularClient = true },
        new() { Id = 16, Client = Clients[5], Master = Masters[9], Service = Services[3], AppointmentDateTime = Day(-12, 14, 0), IsRegularClient = false },

        new() { Id = 17, Client = Clients[6], Master = Masters[0], Service = Services[1], AppointmentDateTime = Day(-27, 10, 0), IsRegularClient = true },
        new() { Id = 18, Client = Clients[7], Master = Masters[2], Service = Services[1], AppointmentDateTime = Day(-21, 11, 0), IsRegularClient = true },
        new() { Id = 19, Client = Clients[8], Master = Masters[6], Service = Services[1], AppointmentDateTime = Day(-16, 12, 0), IsRegularClient = false },
        new() { Id = 20, Client = Clients[9], Master = Masters[2], Service = Services[1], AppointmentDateTime = Day(-11, 13, 0), IsRegularClient = false },
        new() { Id = 21, Client = Clients[0], Master = Masters[6], Service = Services[1], AppointmentDateTime = Day(-5, 14, 0), IsRegularClient = true },

        new() { Id = 22, Client = Clients[2], Master = Masters[7], Service = Services[5], AppointmentDateTime = Day(-29, 15, 0), IsRegularClient = true },
        new() { Id = 23, Client = Clients[3], Master = Masters[7], Service = Services[5], AppointmentDateTime = Day(-22, 16, 0), IsRegularClient = false },
        new() { Id = 24, Client = Clients[4], Master = Masters[7], Service = Services[5], AppointmentDateTime = Day(-14, 17, 0), IsRegularClient = true },
        new() { Id = 25, Client = Clients[5], Master = Masters[7], Service = Services[5], AppointmentDateTime = Day(-7, 18, 0), IsRegularClient = false },

        new() { Id = 26, Client = Clients[6], Master = Masters[5], Service = Services[6], AppointmentDateTime = Day(-26, 10, 0), IsRegularClient = true },
        new() { Id = 27, Client = Clients[7], Master = Masters[5], Service = Services[6], AppointmentDateTime = Day(-13, 11, 0), IsRegularClient = true },
        new() { Id = 28, Client = Clients[8], Master = Masters[5], Service = Services[6], AppointmentDateTime = Day(-3, 12, 0), IsRegularClient = true },

        // Повторные записи за последний месяц.
        new() { Id = 29, Client = Clients[0], Master = Masters[1], Service = Services[0], AppointmentDateTime = Day(-20, 9, 0), IsRegularClient = true },
        new() { Id = 30, Client = Clients[0], Master = Masters[2], Service = Services[1], AppointmentDateTime = Day(-8, 10, 0), IsRegularClient = true },
        new() { Id = 31, Client = Clients[1], Master = Masters[3], Service = Services[3], AppointmentDateTime = Day(-19, 12, 0), IsRegularClient = true },
        new() { Id = 32, Client = Clients[1], Master = Masters[9], Service = Services[3], AppointmentDateTime = Day(-4, 15, 0), IsRegularClient = true },
        new() { Id = 33, Client = Clients[2], Master = Masters[1], Service = Services[2], AppointmentDateTime = Day(-17, 16, 0), IsRegularClient = true },
        new() { Id = 34, Client = Clients[2], Master = Masters[7], Service = Services[5], AppointmentDateTime = Day(-2, 17, 0), IsRegularClient = true },

        // Клиенты, записанные к нескольким мастерам
        new() { Id = 35, Client = Clients[3], Master = Masters[0], Service = Services[0], AppointmentDateTime = Day(-45, 10, 0), IsRegularClient = false },
        new() { Id = 36, Client = Clients[3], Master = Masters[4], Service = Services[8], AppointmentDateTime = Day(-6, 11, 0), IsRegularClient = true },
        new() { Id = 37, Client = Clients[4], Master = Masters[2], Service = Services[1], AppointmentDateTime = Day(-44, 12, 0), IsRegularClient = false },
        new() { Id = 38, Client = Clients[4], Master = Masters[8], Service = Services[8], AppointmentDateTime = Day(-9, 13, 0), IsRegularClient = true }
    ];

    private static DateTime Day(int daysFromToday, int hour, int minute)
    {
        return Today.AddDays(daysFromToday).Date.AddHours(hour).AddMinutes(minute);
    }
}
