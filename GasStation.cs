class GasStation
{
    static public string waitingstatus = "avail";
    static public string pumpstatus = "busy";
    static public int fuelledvehicles = 0;
    static public double petrolLitresSold, dieselLitresSold, LPGLitresSold, totalpetrolsold, totaldieselsold, totalLPGsold, money = 0;
    public static StreamWriter datafile = new StreamWriter("fuelstationData.txt");
    static public void intrface()
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Queue: Cars: " + Program.amountofcars + " Vans: " + Program.amountofvans + " HGVs: " + Program.amountofhgvs);
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Today we've fuelled " + fuelledvehicles + " Vehicles");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Line 1:   Pump 1:  " + waitingstatus + "  Pump 2:  " +  "  Pump 3:  ");
        Console.WriteLine("Line 2:   Pump 4:       " + "  Pump 5:  " +  "  Pump 6:  ");
        Console.WriteLine("Line 3:   Pump 7:       " + "  Pump 8:  " +  "  Pump 9:  ");
    }
    public static void queueingSystem()
    {
        Console.Write("Please enter your username: ");
        Program.username = Console.ReadLine();
        datafile.WriteLine("    " + "Login: " + Program.username);
        Console.Write("Please enter your password: ");
        Program.password = Console.ReadLine();
        datafile.WriteLine("    " + "Password: " + Program.password);
        Console.Clear();
        do
        {
            foreach (Vehicle allvehicles in Program.queueing.ToList())
            {
                double fuellingtime;
                if (allvehicles.vehicletype == "Car")
                {
                    Console.WriteLine(allvehicles.vehicletype + " " + allvehicles.tankcapacity + " " + allvehicles.petroltype);
                    fuellingtime = (50 - allvehicles.tankcapacity) / 1.5;
                    totalpetrolsold += 50 - allvehicles.tankcapacity;
                    petrolLitresSold = 50 - allvehicles.tankcapacity;
                    money += 1.75 * petrolLitresSold;
                    Console.WriteLine("Vehicle is fuelling, please wait");
                    waitingstatus = "busy";
                    GasStation.intrface();
                    Thread.Sleep(Convert.ToInt32(fuellingtime * 100));
                    Console.Clear();
                    Console.WriteLine("Pump is free now");
                    waitingstatus = "avail";
                    GasStation.intrface();
                    Thread.Sleep(1000);
                    Program.queueing.Remove(allvehicles);
                    Program.amountofcars--;
                    fuelledvehicles++;
                    Console.Clear();
                }
                else if (allvehicles.vehicletype == "Van")
                {
                    Console.WriteLine(allvehicles.vehicletype + " " + allvehicles.tankcapacity + " " + allvehicles.petroltype);
                    fuellingtime = (80 - allvehicles.tankcapacity) / 1.5;
                    totaldieselsold += 80 - allvehicles.tankcapacity;
                    dieselLitresSold = 80 - allvehicles.tankcapacity;
                    money += 1.85 * dieselLitresSold;
                    Console.WriteLine("Vehicle is fuelling, please wait");
                    waitingstatus = "busy";
                    GasStation.intrface();
                    Thread.Sleep(Convert.ToInt32(fuellingtime * 100));
                    Console.Clear();
                    Console.WriteLine("Pump is free now");
                    waitingstatus = "avail";
                    GasStation.intrface();
                    Thread.Sleep(1000);
                    Program.queueing.Remove(allvehicles);
                    Program.amountofvans--;
                    fuelledvehicles++;
                    Console.Clear();
                }
                else if (allvehicles.vehicletype == "HGV")
                {
                    Console.WriteLine(allvehicles.vehicletype + " " + allvehicles.tankcapacity + " " + allvehicles.petroltype);
                    fuellingtime = (150 - allvehicles.tankcapacity) / 1.5;
                    totalLPGsold += 150 - allvehicles.tankcapacity;
                    LPGLitresSold = 150 - allvehicles.tankcapacity;
                    money += 0.82 * LPGLitresSold;
                    Console.WriteLine("Vehicle is fuelling, please wait");
                    waitingstatus = "busy";
                    GasStation.intrface();
                    Thread.Sleep(Convert.ToInt32(fuellingtime * 100));
                    Console.Clear();
                    Console.WriteLine("Pump is free now");
                    waitingstatus = "avail";
                    GasStation.intrface();
                    Thread.Sleep(1000);
                    Program.queueing.Remove(allvehicles);
                    Program.amountofhgvs--;
                    fuelledvehicles++;
                    Console.Clear();
                }
            }
        } while (fuelledvehicles != 10);
        foreach (Vehicle allvehicles in Program.queueing)
        {
            Console.WriteLine(allvehicles.vehicletype + " " + allvehicles.tankcapacity + " " + allvehicles.petroltype);
        };
        datafile.WriteLine("    " + "Petrol: " + totalpetrolsold);
        datafile.WriteLine("    " + "Diesel: " + totaldieselsold);
        datafile.WriteLine("    " + "LPG: " + totalLPGsold);
        datafile.WriteLine("Cost: " + money + " GBP");
        datafile.WriteLine("1%:   " + money / 100 + " GBP");
        datafile.WriteLine("Vehicles serviced: " + fuelledvehicles);
        datafile.Close();
        try
        {
            using (StreamReader datefile = new StreamReader("fuelstationData.txt"))
            {
                String line = datefile.ReadToEnd();
                Console.WriteLine(line);
                datefile.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        datafile.Close();
        Console.WriteLine("There is no vehicles in the queue! ");
        Console.ReadKey();
    }
}