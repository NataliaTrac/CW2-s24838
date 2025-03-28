using CW2_s24838.Exceptions;

namespace CW2_s24838.Models;

public class Container
{
    private static int _counter = 1;
    public string SerialNumber { get; }
    public double TareWeight { get; }
    public double Height { get; }
    public double Depth { get; }
    public double MaxLoadWeight { get; }
    public double CurrentLoadWeight { get; protected set; }

    protected Container(char typeCode, double tareWeight, double height, double depth, double maxLoadWeight)
    {
        SerialNumber =  $"KON-{typeCode}-{_counter++}";
        TareWeight = tareWeight;
        Height = height;
        Depth = depth;
        MaxLoadWeight = maxLoadWeight;
        CurrentLoadWeight = 0;
    }
    
    public virtual void Load(double weight)
    {
        if (CurrentLoadWeight + weight > MaxLoadWeight)
        {
            throw new OverfillException($"Container {SerialNumber} is overfilled. Cannot load {weight} kg.");
        }
        CurrentLoadWeight += weight;
    }

    public virtual void Unload()
    {
        CurrentLoadWeight = 0;
    }

    public override string ToString()
    {
        return $"{SerialNumber}: {CurrentLoadWeight}/{MaxLoadWeight} kg";

    }
}