namespace Taryfy2023.Model
{
    internal class Pobor
    {

        public Pobor(string line)
        {
            var values  = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            if(values.Length == 3)
            {
                Date = DateOnly.Parse(values[0].Substring(0,10));
                Time = TimeOnly.Parse(values[0].Substring(11).Replace("24:00", "00:00"));
                Value = double.Parse(values[1].Replace(",", "."));
            }
        }

        public DateOnly Date { get; set; }

        public TimeOnly Time { get; set; }

        public double Value { get; set; }
    }
}
