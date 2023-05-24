using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string displayId = id == null ? "" : $"[{id}] - ";
        string displayName = $"{name} - ";
        string dept = department == null ? "OWNER" : $"{department.ToUpper()}";
        return $"{displayId}{displayName}{dept}";
    }
}
