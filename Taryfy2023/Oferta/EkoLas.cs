namespace Taryfy2023.Oferta
{
    internal class EkoLas : IPriceList
    {
        public string Name => nameof(EkoLas);

        public double G11Price => 1.2475;

        public double G12Price_Strefa1 => 1.5425;

        public double G12Price_Strefa2 => 0.7937;

        public double G12wPrice_Strefa1 => 1.6488;

        public double G12wPrice_Strefa2 => 0.7937;

        public double G13Price_Strefa1 => 1.3715;

        public double G13Price_Strefa2 => 2.1345;

        public double G13Price_Strefa3 => 0.9241;

        public double OplataHandlowa => 31.50;

        public double G11_Dystrybucja => 0.3704;

        public double G12_Dystrybucja_Strefa1 => 0.4193;

        public double G12_Dystrybucja_Strefa2 => 0.1311;

        public double G12w_Dystrybucja_Strefa1 => 0.4689;

        public double G12w_Dystrybucja_Strefa2 => 0.1047;

        public double G13_Dystrybucja_Strefa1 => 0.2870;

        public double G13_Dystrybucja_Strefa2 => 0.4803;

        public double G13_Dystrybucja_Strefa3 => 0.0824;
    }
}
