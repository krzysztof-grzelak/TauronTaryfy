using Taryfy2023.Model;
using Taryfy2023.Oferta;

namespace Taryfy2023.Taryfy
{
    internal class G13 :  ITariff
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
        private int[] winterHours = new[] { 13, 14, 15, 21, 22, 23, 0, 1, 2, 3, 4, 5, 6 };

        private int[] summerHours = new[] { 13, 14, 15, 16, 17, 18, 21, 22, 23, 0, 1, 2, 3, 4, 5, 6 };

        public Func<Pobor, double> CostPerKwh()
        {

            // TODO: fix this function!!!
           return (p) =>
            (winterMonths.Contains(p.Date.Month) && winterHours.Contains(p.Time.Hour)) || summerHours.Contains(p.Time.Hour)
            || p.Date.DayOfWeek == DayOfWeek.Saturday || p.Date.DayOfWeek == DayOfWeek.Sunday
         ? pricelist.G13Price_Strefa2 + pricelist.G13_Dystrybucja_Strefa2 : pricelist.G13Price_Strefa1 + pricelist.G13_Dystrybucja_Strefa1;
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
