namespace Taryfy2023
{
    internal class Configuration
    {
        string[] holidays = new string[] {
            "2022-01-01",
            "2022-01-06",
            "2022-04-15",
            "2022-04-17",
            "2022-05-01",
            "2022-05-03",
            "2022-06-09",
            "2022-06-15",
            "2022-08-15",
            "2022-11-01",
            "2022-11-11",
            "2022-12-25",
            "2022-12-26"
        };

        public DateOnly[] Holidays => holidays.Select(a => DateOnly.Parse(a)).ToArray();

    }
}
