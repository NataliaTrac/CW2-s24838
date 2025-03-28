namespace CW2_s24838.Models;

using CW2_s24838.Exceptions;
using CW2_s24838.Interfaces;

public class RefrigeratedContainer : Container, IHazardNotifer
{
    public ProductType Product{ get; }
    public double Temperature { get; }

    private static readonly Dictionary<ProductType, double> RequiredTemperatures = new()
    {
        { ProductType.Bananas, 13.3},
        { ProductType.Chocolate, 18 },
        { ProductType.Fish, 2 },
        { ProductType.Meat, -15 },
        { ProductType.IceCream, -18 },
        { ProductType.FrozenPizza, -30 },
        { ProductType.Cheese, 7.2 },
        { ProductType.Sausages, 5 },
        { ProductType.Butter, 20.5 },
        { ProductType.Eggs, 19 }
    };

    public RefrigeratedContainer(double tareWeight, double height, double depth, double maxLoadWeight,
        ProductType product, double temperature)
        : base('C', tareWeight, height, depth, maxLoadWeight)
    {
        Product = product;
        Temperature = temperature;

        if (temperature > RequiredTemperatures[product])
        {
            NotifyHazard($"Temperature too high for {Product} in {SerialNumber} (required: ≤ {RequiredTemperatures[product]}°C).");
            throw new Exception($"Unsafe temperature for {Product} in container {SerialNumber}.");
        }
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[TEMP ALERT] {message}");
    }
}