using Taryfy2023.Model;
using Taryfy2023.Oferta;

namespace Taryfy2023.Taryfy
{
    internal class G13 : ITariff
    {
        private readonly IPriceList pricelist;
        private readonly Configuration c;

        public G13(IPriceList pricelist, Configuration c)
        {
            this.pricelist = pricelist;
            this.c = c;
        }

        public string Name => nameof(G13) + " " + pricelist.Name;

        private int[] winterMonths = new[] { 10, 11, 12, 1, 2, 3 };

        private int[] morningPickHours = new[] { 7, 8, 9, 10, 11, 12 };
        private int[] afternoonPickHoursWinter = new[] { 16, 17, 18, 19, 20 };
        private int[] afternoonPickHoursSummer = new[] { 19, 20, 21 };

        public Func<Pobor, double> CostPerKwh()
        {
            return (p) =>
            {
                if (morningPickHours.Contains(p.Time.Hour))
                {
                    return pricelist.G13Price_Strefa1 + pricelist.G13_Dystrybucja_Strefa1;
                }
                else if ((winterMonths.Contains(p.Date.Month) && afternoonPickHoursWinter.Contains(p.Time.Hour)) || afternoonPickHoursSummer.Contains(p.Time.Hour))
                {
                    return pricelist.G13Price_Strefa2 + pricelist.G13_Dystrybucja_Strefa2;
                }
                else
                {
                    return pricelist.G13Price_Strefa3 + pricelist.G13_Dystrybucja_Strefa3;
                }
            };
        }

        public double Cost(IEnumerable<Pobor> list)
        {
            var func = CostPerKwh();
            var cost = list.Sum(a => a.Value * func(a));

            var m = list.DistinctBy(a => a.Date.Month).Count();

            return cost + m * pricelist.OplataHandlowa;
        }
    }
}
