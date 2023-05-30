using System;

enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42,
}
static class LogLine
{
    // private static string extractLevel(string logLine)
    // {
    //     int bracketStart = logLine.IndexOf("["), bracketEnd = logLine.IndexOf("]");
    //     return logLine.Substring(bracketStart + 1, bracketEnd - bracketStart);
    // }

    public static LogLevel ParseLogLevel(string logLine)
    {
        var level = logLine.Substring(1, 3);
        switch (level)
        {
            case "INF":
                return LogLevel.Info;
            case "TRC":
                return LogLevel.Trace;
            case "DBG":
                return LogLevel.Debug;
            case "WRN":
                return LogLevel.Warning;
            case "ERR":
                return LogLevel.Error;
            case "FTL":
                return LogLevel.Fatal;
            default:
                return LogLevel.Unknown;
        }
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        return $"{(int)logLevel}:{message}";
    }
}
