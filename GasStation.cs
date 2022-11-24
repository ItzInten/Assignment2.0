class GasStation
{
    static public string waitingstatus = "avail";
    static public string pumpstatus = "busy";
    static public int fuelledvehicles = 0;
    static public void intrface()
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Queue: Cars: " + Program.amountofcars +  " Vans: " + Program.amountofvans +  " HGVs: " + Program.amountofhgvs);
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Today we've fuelled " + fuelledvehicles + " Vehicles");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Line 1:   Pump 1:  " + waitingstatus + "  Pump 2:  " + waitingstatus + "  Pump 3:  " + waitingstatus);
        Console.WriteLine("Line 2:   Pump 4:  " + waitingstatus + "  Pump 5:  " + waitingstatus + "  Pump 6:  " + waitingstatus);
        Console.WriteLine("Line 3:   Pump 7:  " + waitingstatus + "  Pump 8:  " + waitingstatus + "  Pump 9:  " + waitingstatus);
    }
    public static void queueingSystem()
    {
        do
        {
            foreach (Vehicle allvehicles in Program.queueing.ToList())
            {
                int fuellingtime;
                if (allvehicles.vehicletype == "Car")
                {
                    Console.WriteLine(allvehicles.vehicletype + " " + allvehicles.tankcapacity + " " + allvehicles.petroltype);
                    fuellingtime = 50 - allvehicles.tankcapacity;
                    Console.WriteLine("Vehicle is fuelling, please wait");
                    waitingstatus = "busy";
                    GasStation.intrface();
                    Thread.Sleep(fuellingtime * 100);
                    Console.Clear();
                    Console.WriteLine("Pump is free now");
                    waitingstatus = "avail";
                    GasStation.intrface();
                    Program.queueing.Remove(allvehicles);
                    Program.amountofcars--;
                    Program.amountofvehicles--;
                    fuelledvehicles++;
                    Console.Clear();
                }
                else if (allvehicles.vehicletype == "Van")
                {
                    Console.WriteLine(allvehicles.vehicletype + " " + allvehicles.tankcapacity + " " + allvehicles.petroltype);
                    fuellingtime = 80 - allvehicles.tankcapacity;
                    Console.WriteLine("Vehicle is fuelling, please wait");
                    waitingstatus = "busy";
                    GasStation.intrface();
                    Thread.Sleep(fuellingtime * 100);
                    Console.Clear();
                    Console.WriteLine("Pump is free now");
                    waitingstatus = "avail";
                    GasStation.intrface();
                    Program.queueing.Remove(allvehicles);
                    Program.amountofvans--;
                    Program.amountofvehicles--;
                    fuelledvehicles++;
                    Console.Clear();
                }
                else if (allvehicles.vehicletype == "HGV")
                {
                    Console.WriteLine(allvehicles.vehicletype + " " + allvehicles.tankcapacity + " " + allvehicles.petroltype);
                    fuellingtime = 150 - allvehicles.tankcapacity;
                    Console.WriteLine("Vehicle is fuelling, please wait");
                    waitingstatus = "busy";
                    GasStation.intrface();
                    Thread.Sleep(fuellingtime * 100);
                    Console.Clear();
                    Console.WriteLine("Pump is free now");
                    waitingstatus = "avail";
                    GasStation.intrface();
                    Program.queueing.Remove(allvehicles);
                    Program.amountofhgvs--;
                    Program.amountofvehicles--;
                    fuelledvehicles++;
                    Console.Clear();
                }
            }
        } while (Program.queueing != null && Program.amountofvehicles != 0);
        Console.WriteLine("There is no vehicles in the queue! ");
        Console.ReadKey();
    }
}