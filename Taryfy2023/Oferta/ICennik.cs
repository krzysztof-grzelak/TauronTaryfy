namespace Taryfy2023.Oferta
{
    internal interface IPriceList
    {
        string Name { get; }

        double G11Price { get; }
        double G12Price_Strefa1 { get; }
        double G12Price_Strefa2 { get; }
        double G12wPrice_Strefa1 { get; }
        double G12wPrice_Strefa2 { get; }
        double G13Price_Strefa1 { get; }
        double G13Price_Strefa2 { get; }
        double G13Price_Strefa3 { get; }
        double OplataHandlowa { get; }



        double G11_Dystrybucja { get; }
        double G12_Dystrybucja_Strefa1 { get; }
        double G12_Dystrybucja_Strefa2 { get; }
        double G12w_Dystrybucja_Strefa1 { get; }
        double G12w_Dystrybucja_Strefa2 { get; }
        double G13_Dystrybucja_Strefa1 { get; }
        double G13_Dystrybucja_Strefa2 { get; }
        double G13_Dystrybucja_Strefa3 { get; }
    }
}