// See https://aka.ms/new-console-template for more information
using Taryfy2023.Model;

internal interface ITariff
{
     string Name { get; }

    double Cost(IEnumerable<Pobor> list);   
}