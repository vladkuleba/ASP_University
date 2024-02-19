public class TimeOfDayService : ITimeOfDayService
{
    public string GetTimeOfDay()
    {
        var currentTime = DateTime.Now;
        var hour = currentTime.Hour;

        return hour switch
        {
            >= 6 and < 12 => "morning",
            >= 12 and < 18 => "afternoon",
            >= 18 and < 24 => "evening",
            _ => "night",
        };
    }
}