using System.Globalization;

public class Program
{
    public static void Main()
    {
        // Get the current date and time
        DateTime now = DateTime.Now;
        Console.WriteLine($"Current date and time: {now}");

        // Add 7 days to the current date
        DateTime futureDate = now.AddDays(7);
        Console.WriteLine($"Date and time after 7 days: {futureDate}");

        // Subtract 7 days from the current date
        DateTime pastDate = now.AddDays(-7);
        Console.WriteLine($"Date and time 7 days ago: {pastDate}");

        // Create a specific date
        //utc means that the date and time are in Coordinated Universal Time (UTC) rather than local time.
        //This is important for applications that need to work across different time zones, as it provides a standard reference point for time.
        DateTime specificDate = new DateTime(2026, 02, 26, 0, 0, 0, DateTimeKind.Utc);
        Console.WriteLine($"Specific date: {specificDate}");

        // Create a specific date and time
        // year, month, day, hour, minute, second
        DateTime eventDate = new DateTime(2026, 02, 26, 14, 30, 0);

        // Get the current date (without time)
        DateTime today = DateTime.Today;
        Console.WriteLine($"Today's date: {today}");

        //Get parts of the date
        Console.WriteLine(now.Year);
        Console.WriteLine(now.Month);
        Console.WriteLine(now.Day);
        Console.WriteLine(now.Hour);
        Console.WriteLine(now.Minute);
        Console.WriteLine(now.Second);

        //Difference between two dates
        DateTime startDate = new DateTime(2026, 02, 01);
        DateTime endDate = new DateTime(2026, 02, 26);

        TimeSpan difference = endDate - startDate;

        Console.WriteLine($"Days: {difference.Days}");
        Console.WriteLine($"Hours: {difference.Hours}"); // 0 hours because the difference is exactly 25 days, so there are no additional hours beyond the full days.
        Console.WriteLine($"Total hours: {difference.TotalHours}"); // 25 days x 24 hours = 600 hours

        //Compare two dates
        DateTime deadLine = new DateTime(2026, 02, 28);

        Console.WriteLine(now < deadLine ? "Deadline has not passed yet." : "Deadline has passed.");

        // -1 if now is earlier than deadLine
        // 0 if they are the same
        // 1 if now is later than deadLine
        Console.WriteLine(now.CompareTo(deadLine) < 0 ? "Deadline has not passed yet." : "Deadline has passed.");

        //Format the date
        Console.WriteLine(now.ToString("dd/MM/yyyy"));
        Console.WriteLine(now.ToString("HH:mm"));
        Console.WriteLine(now.ToString("dd * MMMM * yyyy"));


        //Convert string to date
        string dateUS = "2026-02-26";
        string dateTime = "2026-02-26 14:30:00";

        //For general format
        DateTime parseDate = DateTime.Parse(dateUS, CultureInfo.InvariantCulture);
        Console.WriteLine(parseDate);

        parseDate = DateTime.Parse(dateTime, CultureInfo.InvariantCulture);
        Console.WriteLine(parseDate);

        //For exact format
        DateTime parseDataTimeExact = DateTime.ParseExact(dateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture); //Not culture specific, it will work the same in any culture
        Console.WriteLine(parseDataTimeExact);

        DateTime parseDateExact = DateTime.ParseExact(dateUS, "yyyy-MM-dd", new CultureInfo("en-US"));
        Console.WriteLine(parseDateExact);

        string dateES = "26-02-2026";
        parseDateExact = DateTime.ParseExact(dateES, "dd-MM-yyyy", new CultureInfo("es-ES"));

        Console.WriteLine(parseDateExact);

        dateUS = "2029-02-11";

        if (DateTime.TryParse(dateUS, CultureInfo.InvariantCulture, out DateTime tryParseDate))
        {
            Console.WriteLine(tryParseDate);
        }
        else
        {
            Console.WriteLine("Incorrect format");
        }

        //TimeSpan represents a time interval, it can be used to represent the difference between two dates or a specific duration of time.

        //Parts: days, hours, minutes, seconds, milliseconds
        TimeSpan timeSpan = new TimeSpan(1, 30, 0); // 1 hour and 30 minutes

        Console.WriteLine($"TimeSpan Days: {timeSpan.Days}");
        Console.WriteLine($"TimeSpan Hours: {timeSpan.Hours}");

        //Simulate a cooldown for an ability in a game
        DateTime lastUseAbility = DateTime.UtcNow.AddSeconds(-22); // Simulate that the ability was last used 22 seconds ago

        //TimeSpan cooldown = TimeSpan.FromMinutes(2); // Cooldown of 2 minutes
        TimeSpan cooldown = TimeSpan.FromSeconds(90); // Cooldown of 1 minute and 30 seconds

        TimeSpan timeSinceLastUse = DateTime.UtcNow - lastUseAbility; // Calculate the time since the last use of the ability

        if (timeSinceLastUse >= cooldown)
        {
            Console.WriteLine("Your ability is ready");
        }
        else
        {
            TimeSpan timeLeft = cooldown - timeSinceLastUse;
            Console.WriteLine($"You must wait {timeLeft.Minutes} minutes and {timeLeft.Seconds} seconds.");
        }

        //DateTimeOffset is a structure that represents a point in time, typically expressed as a date and time of day, with an offset from Coordinated Universal Time (UTC).
        //It is used to represent dates and times in a way that is independent of time zones.

        /* DateTime vs DateTimeOffset:
         * DateTime -> Barcelona 18:00 / New York 12:00 (both times are the same moment, but they are represented differently because they are in different time zones)
         * DateTimeOffset -> Barcelona 18:00 +01:00 / New York 12:00 -05:00 (both times are the same moment, but they are represented with their respective offsets from UTC, so we can know the exact time in both locations)
         * Barcelona 18:00 - 1 hour (offset) = 17:00 UTC
         * New York 12:00 + 5 hours (offset) = 17:00 UTC
         * Now we can know the exact time in both locations, even if they are in different time zones, 
         * because DateTimeOffset includes the offset from UTC, while DateTime does not.
         */

        DateTimeOffset nowUTC = DateTimeOffset.Now;

        Console.WriteLine(nowUTC); // This will print the current date and time with the offset from UTC

        // Create a DateTimeOffset for a specific date and time with a specific offset (Barcelona)
        DateTimeOffset specificDateTimeOffsetBarcelona = new DateTimeOffset(2026, 02, 26, 14, 30, 0, TimeSpan.FromHours(1)); // This represents 26th February 2026 at 14:30 with an offset of +1 hour from UTC

        // Create a DateTimeOffset for a specific date and time with a specific offset (New York)
        DateTimeOffset specificDateTimeOffsetNewYork = new DateTimeOffset(2026, 02, 26, 14, 30, 0, TimeSpan.FromHours(-5)); // This represents 26th February 2026 at 14:30 with an offset of -5 hours from UTC

        Console.WriteLine($"Barcelona: {specificDateTimeOffsetBarcelona}");
        Console.WriteLine($"New York: {specificDateTimeOffsetNewYork}");

    }
}
