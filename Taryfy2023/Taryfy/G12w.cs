using Taryfy2023.Model;
using Taryfy2023.Oferta;

namespace Taryfy2023.Taryfy
{
    internal class G12w : ITariff
    {
        private readonly IPriceList pricelist;
        private readonly Configuration c;

        public G12w(IPriceList pricelist, Configuration c)
        {
            this.pricelist = pricelist;
            this.c = c;
        }

        public string Name => nameof(G12w) + " Oszczędny weekend" + " " + pricelist.Name;

        public Func<Pobor, double> CostPerKwh()
        {
            return (p) =>
             p.Time < new TimeOnly(6, 00) ||
             (p.Time >= new TimeOnly(13, 00) && p.Time < new TimeOnly(15, 00)) ||
             p.Time >= new TimeOnly(22, 00) || p.Date.DayOfWeek == DayOfWeek.Sunday || p.Date.DayOfWeek == DayOfWeek.Saturday || c.Holidays.Contains(p.Date)
          ? pricelist.G12wPrice_Strefa2 + pricelist.G12w_Dystrybucja_Strefa2 : pricelist.G12wPrice_Strefa1 + pricelist.G12w_Dystrybucja_Strefa1;
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
