namespace Taryfy2023.Oferta
{
    internal class EkoOdTaurona : IPriceList
    {
        public string Name => nameof(EkoOdTaurona);

        public double G11Price => 1.3167;

        public double G12Price_Strefa1 => 1.6283;

        public double G12Price_Strefa2 => 0.8378;

        public double G12wPrice_Strefa1 => 1.7405;

        public double G12wPrice_Strefa2 => 0.8378;

        public double G13Price_Strefa1 => 1.4476;

        public double G13Price_Strefa2 => 2.2541;

        public double G13Price_Strefa3 => 0.9754;

        public double OplataHandlowa => 20.50;

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
