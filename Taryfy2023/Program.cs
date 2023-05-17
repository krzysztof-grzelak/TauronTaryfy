// See https://aka.ms/new-console-template for more information
using System.Reflection;
using Taryfy2023;
using Taryfy2023.Model;
using Taryfy2023.Oferta;

internal class Program
{
    private static void Main(string[] args)
    {
        string directory = @"C:\Users\Krzysztof\Desktop\Prad\Dane";
        List<Pobor> data = LoadData(directory);

        List<ITariff> allTariffCombinations = CreateObjects();

        Dictionary<string, double> results = new Dictionary<string, double>();

        foreach (var item in allTariffCombinations)
        {
            results.Add(item.Name, item.Cost(data));
        }

        foreach (var item in results.OrderBy(v => v.Value))
        {
            Console.WriteLine("{0} {1}", item.Key, item.Value);
        }
    }

    private static List<Pobor> LoadData(string dir)
    {
        List<Pobor> data = new();

        var files = Directory.GetFiles(dir, "*.csv");

        foreach (var file in files)
        {
            IEnumerable<string> lines = File.ReadLines(file);

            foreach (var line in lines.Skip(1))
            {
                data.Add(new Pobor(line));
            }
        }

        return data;
    }

    private static List<ITariff> CreateObjects()
    {
        var config = new Configuration();

        var pList = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(IPriceList).IsAssignableFrom(t) && t.IsClass)
            .ToList();

        List<IPriceList> instances = new List<IPriceList>();
        foreach (Type type in pList)
        {
            IPriceList instance = (IPriceList)Activator.CreateInstance(type);
            instances.Add(instance);
        }

        var tList = Assembly.GetExecutingAssembly()
        .GetTypes()
        .Where(t => typeof(ITariff).IsAssignableFrom(t) && t.IsClass)
        .ToList();


        List<ITariff> tinstances = new List<ITariff>();

        foreach (Type type in tList)
        {
            foreach (var i in instances)
            {
                ITariff tinstance = (ITariff)Activator.CreateInstance(type, i, config);
                tinstances.Add(tinstance);
            }
        }

        return tinstances;
    }
}