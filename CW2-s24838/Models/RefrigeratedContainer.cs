namespace CW2_s24838.Models;

using CW2_s24838.Exceptions;
using CW2_s24838.Interfaces;

public class RefrigeratedContainer : Container, IHazardNotifer
{
    public ProductType Product{ get; }
    public double Temperature { get; }

    private static readonly Dictionary<ProductType, double> RequiredTemperatures = new()
    {
        { ProductType.Banana, 13 },
        { ProductType.Milk, 4 },
        { ProductType.Hellium, -269 }
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