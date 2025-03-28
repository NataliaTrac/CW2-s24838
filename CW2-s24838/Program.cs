// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using CW2_s24838.Models;

List<Container> containers = new();
List<ContainerShip> ships = new();

while (true)
{
    Console.WriteLine("\n ~~~ CONTAINER MANAGEMENT SYSTEM ~~~");
    Console.WriteLine("\n1. Add Container Ship");
    Console.WriteLine("\n2. Add Container");
    Console.WriteLine("\n3. Show Container Ships");
    Console.WriteLine("\n4. Show Containers");
    Console.WriteLine("\n5. Exit");
    Console.Write("\n> ");
    
    var input = Console.ReadLine();
    Console.WriteLine();

    switch (input)
    {
        case "1":
            Console.WriteLine("\n1. Add Container Ship");
            Console.WriteLine("Enter ship name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter ship max speed: ");
            double speed = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter max number of containers: ");
            int count = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter max weight: ");
            double weight = double.Parse(Console.ReadLine());
            
            ships.Add(new ContainerShip(name, speed, count, weight));
            Console.WriteLine($"\n{name} is added to containers.");
            break;
        
        case "2":
            Console.WriteLine("Choose container type:");
            Console.WriteLine("\t 1. Liquid\t 2. Refrigerated\t 3.Gas");
            Console.Write("\n> ");
            var typeInput = Console.ReadLine();
            Console.WriteLine("\n1. Enter tare:");
            double tare = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter height: ");
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter depth: ");
            double depth = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter max load: ");            
            double maxLoad = double.Parse(Console.ReadLine());

            switch (typeInput)
            {
             case "1":
                 Console.WriteLine("Is hazardous? (y/n): ");
                 bool hazardous = Console.ReadLine() == "y";
                 var liquid = new LiquidContainer(tare, height, depth, maxLoad, hazardous);
                 containers.Add(liquid);
                 Console.WriteLine($"\n{liquid.SerialNumber} is added to containers.");
                 break;

                case "2":
                    Console.WriteLine("Enter product type: ");
                    var productInput = Console.ReadLine();
                    var product = Enum.Parse<ProductType>(productInput, true);
                    Console.Write("Temperatura (°C): ");
                    double temp = double.Parse(Console.ReadLine());
                    try
                    {
                        var refrigerated = new RefrigeratedContainer(tare, height, depth, maxLoad, product, temp);
                        containers.Add(refrigerated);
                        Console.WriteLine($"Dodano kontener: {refrigerated.SerialNumber}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[BŁĄD]: {ex.Message}");
                    }
                    break;
                case "3":
                    Console.Write("Enter pressure(atm): ");
                    double pressure = double.Parse(Console.ReadLine());
                    var gas = new GasContainer(tare, height, depth, maxLoad, pressure);
                    containers.Add(gas);
                    Console.WriteLine($"\n{gas.SerialNumber} is added to containers.");
                    break;
                default:
                    Console.WriteLine($"\n{input} is not a valid input."); 
                    break;
            }

            break;


        case "3":
            Console.WriteLine("\nList of container ships:");
            if(ships.Count == 0) Console.WriteLine("No ships available.");
            foreach(var s in ships) s.PrintInfo();
            break;
        
        case "4":
            Console.WriteLine("\nList of containers:");
            if (containers.Count == 0) Console.WriteLine("Brak kontenerów.");
            foreach (var c in containers) Console.WriteLine(c);
            break;
        
        case "5":
            Console.WriteLine("Bye...");
            return;
        
        default:
            Console.WriteLine("Invalid input.");
            break;
            

            
    }
}