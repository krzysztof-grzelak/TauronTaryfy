namespace Taryfy2023.Oferta
{
    internal class Sprzedawcy : IPriceList
    {
        public string Name => nameof(Sprzedawcy);

        public double G11Price => 1.3861;

        public double G12Price_Strefa1 => 1.7140;

        public double G12Price_Strefa2 => 0.8819;

        public double G12wPrice_Strefa1 => 1.8321;

        public double G12wPrice_Strefa2 => 0.8819;

        public double G13Price_Strefa1 => 1.5238;

        public double G13Price_Strefa2 => 2.3728;

        public double G13Price_Strefa3 => 1.0268;

        public double OplataHandlowa => 0;

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
