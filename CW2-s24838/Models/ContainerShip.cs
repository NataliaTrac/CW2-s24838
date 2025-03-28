using CW2_s24838.Exceptions;
using CW2_s24838.Models;

namespace CW2_s24838.Models;


public class ContainerShip
{
    public string Name { get; }
    public double MaxSpeed { get; }
    public int MaxContainerCount { get; }
    public double MaxTotalWeight { get; }
    public List<Container> Containers { get; }

    public ContainerShip(string name, double maxSpeed, int maxContainerCount, double maxTotalWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxTotalWeight = maxTotalWeight;
        Containers = new List<Container>();
    }
    
    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainerCount)
        {
            throw new OverfillException($"Cannot load container {container.SerialNumber}. Ship is full.");
        }
        
        double totalWeight = Containers.Sum(c => c.TareWeight + c.CurrentLoadWeight);
        double newTotal = totalWeight + container.TareWeight + container.CurrentLoadWeight;

        if (newTotal > MaxTotalWeight * 1000)
            throw new Exception($"Cannot load: weight limit exceeded on {Name}.");

        Containers.Add(container);
        Console.WriteLine($"Loaded {container.SerialNumber} onto {Name}");

    }

    public void UnloadContainer(string serialNumber)
    {
        var found = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (found == null) throw new Exception($"Container {serialNumber} not found on {Name}.");
        Containers.Remove(found);
        Console.WriteLine($"Unloaded {serialNumber} from {Name}");
    }
    
    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        var index = Containers.FindIndex(c => c.SerialNumber == serialNumber);
        if (index == -1) throw new Exception($"Container {serialNumber} not found on {Name}.");
        Containers[index] = newContainer;
        Console.WriteLine($"Replaced {serialNumber} with {newContainer.SerialNumber} on {Name}");
    }

    public void MoveContainerTo(ContainerShip targetShip, string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null) throw new Exception($"Container {serialNumber} not found on {Name}.");

        targetShip.LoadContainer(container);
        Containers.Remove(container);
        Console.WriteLine($"Moved {serialNumber} from {Name} to {targetShip.Name}");
    }

    public void PrintInfo()
    {
        Console.WriteLine($"\n=== {Name} ===");
        Console.WriteLine($"Speed: {MaxSpeed} knots");
        Console.WriteLine($"Max Containers: {MaxContainerCount}");
        Console.WriteLine($"Max Weight: {MaxTotalWeight} tons");
        Console.WriteLine($"Current Containers: {Containers.Count}");

        foreach (var container in Containers)
        {
            Console.WriteLine($"- {container}");
        }

        Console.WriteLine("=====================\n");
    }
    
}