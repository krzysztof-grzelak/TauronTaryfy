using Taryfy2023.Model;
using Taryfy2023.Oferta;

namespace Taryfy2023.Taryfy
{
    internal class G11 : ITariff
    {

        private readonly IPriceList pricelist;

        public G11(IPriceList pricelist, Configuration c)
        {
            this.pricelist = pricelist;
        }

        public string Name => nameof(G11) + " " + pricelist.Name;

        public double Cost(IEnumerable<Pobor> list)
        {
            var cost = list.Sum(a => a.Value) * (pricelist.G11Price + pricelist.G11_Dystrybucja);
            var m = list.DistinctBy(a => a.Date.Month).Count();
            return cost + m*pricelist.OplataHandlowa;
        }
    }
}
