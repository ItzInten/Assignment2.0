class GasStation
{
    public void intrface()
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Queue: Cars: " + " Vans: " + " HGVs: ");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Line 1:   Pump 1:  " + "  Pump 2:  " + "  Pump 3:  ");
        Console.WriteLine("Line 2:   Pump 4:  " + "  Pump 5:  " + "  Pump 6:  ");
        Console.WriteLine("Line 3:   Pump 7:  " + "  Pump 8:  " + "  Pump 9:  ");
    }
    public static void queueingSystem()
    {
        do
        {
            foreach (Vehicle allvehicles in Program.queueing)
            {
                int fuellingtime;
                if (allvehicles.vehicletype == "Car")
                {
                    fuellingtime = 50 - allvehicles.tankcapacity;
                    Console.WriteLine("Vehicle is fuelling, please wait");
                    Thread.Sleep(fuellingtime * 100);
                    Console.WriteLine("Pump is free now");
                    Program.queueing.Remove(allvehicles);
                }
                else if (allvehicles.vehicletype == "Van")
                {
                    fuellingtime = 80 - allvehicles.tankcapacity;
                    Console.WriteLine("Vehicle is fuelling, please wait");
                    Thread.Sleep(fuellingtime * 100);
                    Console.WriteLine("Pump is free now");
                    Program.queueing.Remove(allvehicles);
                }
                else if (allvehicles.vehicletype == "HGV")
                {
                    fuellingtime = 150 - allvehicles.tankcapacity;
                    Console.WriteLine("Vehicle is fuelling, please wait");
                    Thread.Sleep(fuellingtime * 100);
                    Console.WriteLine("Pump is free now");
                    Program.queueing.Remove(allvehicles);
                }
                Console.WriteLine(allvehicles.vehicletype + " " + allvehicles.tankcapacity + " " + allvehicles.petroltype);
            }
        } while (Program.queueing != null);
    }
}