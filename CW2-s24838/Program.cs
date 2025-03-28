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
    Console.WriteLine("\n5. Load container onto ship");
    Console.WriteLine("\n6. Unload container onto ship");
    Console.WriteLine("\n7. Delate container from ship");
    Console.WriteLine("\n8. Replace container on ship");
    Console.WriteLine("\n9. Replace container from ship to ship");
    Console.WriteLine("\n0. Exit");
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
            if (ships.Count == 0) Console.WriteLine("No ships available.");
            foreach (var s in ships) s.PrintInfo();
            break;

        case "4":
            Console.WriteLine("\nList of containers:");
            if (containers.Count == 0) Console.WriteLine("Brak kontenerów.");
            foreach (var c in containers) Console.WriteLine(c);
            break;

        case "5":
            if (containers.Count == 0)
            {
                Console.WriteLine("No containers available.");
                break;
            }

            if (ships.Count == 0)
            {
                Console.WriteLine("No ships available.");
                break;
            }

            Console.WriteLine("Available containers:");
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine($"{i}. {containers[i]}");
            }

            Console.WriteLine("Choose container to load:");
            int contIndex = int.Parse(Console.ReadLine());

            Console.WriteLine($"\n{containers[contIndex].SerialNumber} is selected.");
            Console.WriteLine("Available ships:");
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine($"{i}. {ships[i].Name}");
            }

            Console.WriteLine("Choose ship to load onto:");
            int shipIndex = int.Parse(Console.ReadLine());

            try
            {
                var container = containers[shipIndex];
                var ship = ships[shipIndex];
                ship.LoadContainer(container);
                containers.RemoveAt(contIndex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR]: {ex.Message}");

            }

            break;
        case "6":
            if (ships.Count == 0)
            {
                Console.WriteLine("No ships available.");
                break;
            }

            Console.WriteLine("Available ships:");
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine($"{i}. {ships[i].Name}");
            }

            int shipId = int.Parse(Console.ReadLine());
            var ship6 = ships[shipId];

            Console.WriteLine($"\n{shipId} is selected.");

            Console.WriteLine("Enter container serial number: ");
            string serialToUnload = Console.ReadLine();

            var cont6 = ship6.Containers.FirstOrDefault(c => c.SerialNumber == serialToUnload);
            if (cont6 != null)
            {
                cont6.Unload();
                Console.WriteLine($"\n{cont6.SerialNumber} is unloaded.");
            }
            else Console.WriteLine($"\n{serialToUnload} is not loaded.");

            break;

        case "7":
            Console.WriteLine("Choose container:");
            for (int i = 0; i < ships.Count; i++)
                Console.WriteLine($"{i}. {ships[i].Name}");

            int shipIdx7 = int.Parse(Console.ReadLine());
            var ship7 = ships[shipIdx7];

            Console.Write("Enter container serial number: ");
            string serialToRemove = Console.ReadLine();

            try
            {
                ship7.UnloadContainer(serialToRemove);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[BŁĄD]: {ex.Message}");
            }

            break;
    

    case "8":
            Console.WriteLine("Choose ship:");
            for (int i = 0; i < ships.Count; i++)
                Console.WriteLine($"{i}. {ships[i].Name}");
            int shipIdx8 = int.Parse(Console.ReadLine());
            var ship8 = ships[shipIdx8];

            Console.Write("Enter container serial number: ");
            string oldSerial = Console.ReadLine();

            if (containers.Count == 0)
            {
                Console.WriteLine("No containers available.");
                break;
            }

            Console.WriteLine("Choose new container:");
            for (int i = 0; i < containers.Count; i++)
                Console.WriteLine($"{i}. {containers[i]}");

            int contIdx8 = int.Parse(Console.ReadLine());
            var newContainer = containers[contIdx8];

            try
            {
                ship8.ReplaceContainer(oldSerial, newContainer);
                containers.RemoveAt(contIdx8);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR]: {ex.Message}");
            }
            break;
        
    case "9":
            if (ships.Count < 2)
            {
                Console.WriteLine("Not enough ships available.");
                break;
            }

            Console.WriteLine("Choose ship to move container from:");
            for (int i = 0; i < ships.Count; i++)
                Console.WriteLine($"{i}. {ships[i].Name}");
            int fromIdx = int.Parse(Console.ReadLine());

            Console.Write("Enter container serial number: ");
            string serialToMove = Console.ReadLine();

            Console.WriteLine("Choose ship to move container to:");
            for (int i = 0; i < ships.Count; i++)
            {
                if (i != fromIdx)
                    Console.WriteLine($"{i}. {ships[i].Name}");
            }
            int toIdx = int.Parse(Console.ReadLine());

            try
            {
                ships[fromIdx].MoveContainerTo(ships[toIdx], serialToMove);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR]: {ex.Message}");
            }
            break;


    case "0":
            Console.WriteLine("Bye...");
            return;
        
        default:
            Console.WriteLine("Invalid input.");
            break;
            

            
    }
}