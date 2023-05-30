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

    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var date = DateTime.Parse(appointmentDateDescription);
        var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        switch (location)
        {
            case Location.NewYork:
                var zoneIdNY = isWindows ? "Eastern Standard Time" : "America/New_York";
                TimeZoneInfo tzNY = TimeZoneInfo.FindSystemTimeZoneById(zoneIdNY);
                return TimeZoneInfo.ConvertTimeToUtc(date, tzNY);
            case Location.London:
                var zoneIdLdn = isWindows ? "GMT Standard Time" : "Europe/London";
                TimeZoneInfo tzLDN = TimeZoneInfo.FindSystemTimeZoneById(zoneIdLdn);
                return TimeZoneInfo.ConvertTimeToUtc(date, tzLDN);
            case Location.Paris:
                var zoneIdPar = isWindows ? "W. Europe Standard Time" : "Europe/Paris";
                TimeZoneInfo tzPAR = TimeZoneInfo.FindSystemTimeZoneById(zoneIdPar);
                return TimeZoneInfo.ConvertTimeToUtc(date, tzPAR);
            default:
                return date;
        }
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        var timeToAppointment = new TimeSpan();
        switch (alertLevel)
        {
            case AlertLevel.Early:
                timeToAppointment = new TimeSpan(1, 0, 0, 0);
                break;
            case AlertLevel.Standard:
                timeToAppointment = new TimeSpan(1, 45, 0);
                break;
            case AlertLevel.Late:
                timeToAppointment = new TimeSpan(0, 30, 0);
                break;
        }
        return appointment - timeToAppointment;
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var dtPast = dt.AddDays(-7);
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Europe/London");
        switch (location)
        {
            case Location.NewYork:
                var zoneIdNY = isWindows ? "Eastern Standard Time" : "America/New_York";
                tz = TimeZoneInfo.FindSystemTimeZoneById(zoneIdNY);
                break;
            case Location.London:
                var zoneIdLdn = isWindows ? "GMT Standard Time" : "Europe/London";
                tz = TimeZoneInfo.FindSystemTimeZoneById(zoneIdLdn);
                break;
            case Location.Paris:
                var zoneIdPar = isWindows ? "W. Europe Standard Time" : "Europe/Paris";
                tz = TimeZoneInfo.FindSystemTimeZoneById(zoneIdPar);
                break;
        }
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
}
