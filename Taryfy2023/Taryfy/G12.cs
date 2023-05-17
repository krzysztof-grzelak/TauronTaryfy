using Taryfy2023.Model;
using Taryfy2023.Oferta;

namespace Taryfy2023.Taryfy
{
    internal class G12 : ITariff
    {
        private IPriceList pricelist;

        public G12(IPriceList pricelist, Configuration cs)
        {
            this.pricelist = pricelist;
        }

        public string Name => nameof(G12) + " Oszczędna noc" + " " + pricelist.Name;

        private Func<Pobor, double> CostPerKwh()
        {
            return (p) =>
            p.Time < new TimeOnly(7, 00) ||
            (p.Time >= new TimeOnly(13, 00) && p.Time < new TimeOnly(16, 00)) ||
            p.Time >= new TimeOnly(22, 00)
         ? pricelist.G12Price_Strefa2 + pricelist.G12_Dystrybucja_Strefa2 : pricelist.G12Price_Strefa1 + pricelist.G12_Dystrybucja_Strefa1;
        }


        public double Cost(IEnumerable<Pobor> list)
        {
            var func = this.CostPerKwh();
            var cost  = list.Sum(a => a.Value * func(a));
            var m = list.DistinctBy(a => a.Date.Month).Count();
            return cost + m * pricelist.OplataHandlowa;
        }
    }
}
