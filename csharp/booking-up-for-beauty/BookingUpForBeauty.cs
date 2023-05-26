using System;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        return DateTime.Parse(appointmentDateDescription);
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        return DateTime.Compare(appointmentDate, DateTime.Now) < 0;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        var time = appointmentDate.ToString("HH:mm");
        var hour = Convert.ToInt32(time.Split(":")[0]);
        return hour >= 12 && hour < 18;
    }

    public static string Description(DateTime appointmentDate)
    {
        return $"You have an appointment on {appointmentDate.ToString()}.";
    }

    public static DateTime AnniversaryDate()
    {
        return new DateTime(DateTime.UtcNow.Year, 9, 15, 0, 0, 0);
    }
}
