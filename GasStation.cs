class GasStation
{
    static public int fuelledvehicles = 0;
    static public int vehicelinqueue = 0;
    static public double petrolLitresSold, dieselLitresSold, LPGLitresSold, totalpetrolsold, totaldieselsold, totalLPGsold, money = 0;
    public static StreamWriter datafile = new StreamWriter("fuelstationData.txt");
    static public void intrface()
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Queue: Cars: " + Program.amountofcars + " Vans: " + Program.amountofvans + " HGVs: " + Program.amountofhgvs);
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Today we've fuelled " + fuelledvehicles + " Vehicles");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Line 1:   Pump 1:  " + Program.pump1status + "  Pump 2:  " + Program.pump2status + "  Pump 3:  " + Program.pump3status);
        Console.WriteLine("Line 2:   Pump 4:  " + Program.pump4status + "  Pump 5:  " + Program.pump5status + "  Pump 6:  " + Program.pump6status);
        Console.WriteLine("Line 3:   Pump 7:  " + Program.pump7status + "  Pump 8:  " + Program.pump8status + "  Pump 9:  " + Program.pump9status);
    }
    public static void queueingSystem(Vehicle allvehicles)
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
            GasStation.intrface();
            Thread.Sleep(Convert.ToInt32(fuellingtime * 100));
            Console.Clear();
            Console.WriteLine("Pump is free now");
            fuelledvehicles++;
            Program.pump9status = "avail";
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
            Program.pump9status = "busy";
            GasStation.intrface();
            Thread.Sleep(Convert.ToInt32(fuellingtime * 100));
            Console.Clear();
            Console.WriteLine("Pump is free now");
            fuelledvehicles++;
            Program.pump9status = "avail";
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
            Program.pump9status = "busy";
            GasStation.intrface();
            Thread.Sleep(Convert.ToInt32(fuellingtime * 100));
            Console.Clear();
            Console.WriteLine("Pump is free now");
            fuelledvehicles++;
            Program.pump9status = "avail";
            GasStation.intrface();
            Thread.Sleep(1000);
            Program.queueing.Remove(allvehicles);
            Program.amountofhgvs--;
            Console.Clear();
        }
        Program.pump9status = "avail";
        Console.WriteLine("There is no vehicles in the queue!");
        Console.ReadKey();
    }
    public static void data()
    {
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
    }
}