using System;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case 1:
                return "goalie";
            case 2:
                return "left back";
            case 3 or 4:
                return "center back";
            case 5:
                return "right back";
            case 6 or 7 or 8:
                return "midfielder";
            case 9:
                return "left wing";
            case 10:
                return "striker";
            case 11:
                return "right wing";
            default:
                throw new ArgumentOutOfRangeException("Value does not fall within the expected range.");
        }
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case int supporters:
                return $"There are {supporters} supporters at the match.";
            case string annoucements:
                return annoucements;
            case Foul foul:
                return "The referee deemed a foul.";
            case Injury injury:
                return $"Oh no! {injury.GetDescription()} Medics are on the field.";
            case Incident incident:
                return incident.GetDescription();
            case Manager manager:
                var displayClub = manager.Club == null ? "" : $" ({manager.Club})";
                return $"{manager.Name}{displayClub}";
            default:
                throw new ArgumentException();
        }
    }
}
