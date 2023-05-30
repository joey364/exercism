using System;
using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    private static bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    private static string GetZoneId(Location location)
    {
        var zoneId = string.Empty;
        switch (location)
        {
            case Location.NewYork:
                zoneId = isWindows ? "Eastern Standard Time" : "America/New_York";
                break;
            case Location.London:
                zoneId = isWindows ? "GMT Standard Time" : "Europe/London";
                break;
            case Location.Paris:
                zoneId = isWindows ? "W. Europe Standard Time" : "Europe/Paris";
                break;
        }
        return zoneId;
    }

    private static CultureInfo LocationToCulture(Location location)
    {
        string cultureId = string.Empty;
        switch (location)
        {
            case Location.NewYork:
                cultureId = "en-US";
                break;
            case Location.London:
                cultureId = "en-GB";
                break;
            case Location.Paris:
                cultureId = "fr-FR";
                break;
        }
        return new CultureInfo(cultureId);
    }

    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var date = DateTime.Parse(appointmentDateDescription);
        var TZ = TimeZoneInfo.FindSystemTimeZoneById(GetZoneId(location));
        return TimeZoneInfo.ConvertTimeToUtc(date, TZ);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        var timeToAppointment = new TimeSpan();
        switch (alertLevel)
        {
            case AlertLevel.Early:
                timeToAppointment = TimeSpan.FromDays(1);
                break;
            case AlertLevel.Standard:
                timeToAppointment = new TimeSpan(1, 45, 0);
                break;
            case AlertLevel.Late:
                timeToAppointment = TimeSpan.FromMinutes(30);
                break;
        }
        return appointment - timeToAppointment;
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var dtPast = dt.AddDays(-7);
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(GetZoneId(location));
        return tz.IsDaylightSavingTime(dtPast) != tz.IsDaylightSavingTime(dt);
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        try
        {
            return DateTime.Parse(dtStr, LocationToCulture(location));
        }
        catch (Exception)
        {
            return DateTime.MinValue;
        }
    }
}
