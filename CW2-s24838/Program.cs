// See https://aka.ms/new-console-template for more information

using CW2_s24838.Models;

/*
var smallContainer = new LiquidContainer(100, 50, 50, 500, false);
smallContainer.Load(200);  

var largeContainer = new LiquidContainer(500, 400, 300, 2000, false);
largeContainer.Load(1500);  

var overfillContainer = new LiquidContainer(300, 200, 150, 1000, false);
try
{
    overfillContainer.Load(1200);  
}
catch (Exception ex)
{
    Console.WriteLine($"Exception caught: {ex.Message}");
}

var dangerousContainer = new LiquidContainer(300, 200, 150, 1000, true);
try
{
    dangerousContainer.Load(600);
}
catch (Exception ex)
{
    Console.WriteLine($"Exception caught: {ex.Message}");
}
*/

var gas = new GasContainer(250, 180, 130, 800, 4.5);
gas.Load(600);
Console.WriteLine($"Before unload: {gas}");
gas.Unload();
Console.WriteLine($"After unload: {gas}");