using CW2_s24838.Interfaces;
using CW2_s24838.Exceptions;

namespace CW2_s24838.Models;

public class LiquidContainer : Container, IHazardNotifer
{
    public bool IsHazardous { get; }

    public LiquidContainer(double tareWeight, double height, double depth, double maxLoadWeight, bool isHazardous)
        : base('L', tareWeight, height, depth, maxLoadWeight)
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double weight)
    {
        double maxAllowed = IsHazardous ? MaxLoadWeight * 0.5 : MaxLoadWeight * 0.9;

        if (weight + CurrentLoadWeight > maxAllowed)
        {
            NotifyHazard($"Overload attempt on {SerialNumber}! Exceeds {(IsHazardous ? "50%" : "90%")} limit.");
            throw new OverfillException($"Cannot load {weight} kg into {SerialNumber}. Limit exceeded.");

        }
        base.Load(weight);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"{SerialNumber}: {message}");
    }
}