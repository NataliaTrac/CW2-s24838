namespace CW2_s24838.Models;
using CW2_s24838.Exceptions;
using CW2_s24838.Interfaces;

public class GasContainer : Container, IHazardNotifer
{
    public double Pressure { get; }
    
    public GasContainer(double tareWeight, double height, double depth, double maxLoadWeight, double pressure)
    : base ('G', tareWeight, height, depth, maxLoadWeight)
    {
        Pressure = pressure;
    }

    public override void Unload()
    {
        double retained = MaxLoadWeight * 0.05;
        CurrentLoadWeight = retained;
        Console.WriteLine($"{SerialNumber} unloaded. 5% ({retained} kg) of the load remains due to gas safety regulations.");
    }
    
    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[GAS HAZARD] {SerialNumber}: {message}");
    }
}