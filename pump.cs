public class Pump
{
    static public int fuelledvehicles = 0;
    static public int vehicelinqueue = 0;
    static public double petrolLitresSold, dieselLitresSold, LPGLitresSold, totalpetrolsold, totaldieselsold, totalLPGsold, money = 0;
    public static StreamWriter datafile = new StreamWriter("fuelstationData.txt");
    public string Available = "avail";
    public Vehicle pumpvehicle { get; set; }
    public void addvehicle(Vehicle passvehicle)
    {
        pumpvehicle = passvehicle;
        Thread pumps = new Thread(() => processvehicle(pumpvehicle));
        pumps.Start();
    }
    private void processvehicle(Vehicle pumpvehicle)
    {
        Available = "busy";
        double fuellingtime;
        if (pumpvehicle.vehicletype == "Car")
        {
            Console.WriteLine(pumpvehicle.vehicletype + " " + pumpvehicle.tankcapacity + " " + pumpvehicle.petroltype);
            fuellingtime = (50 - pumpvehicle.tankcapacity) / 1.5;
            totalpetrolsold += 50 - pumpvehicle.tankcapacity;
            petrolLitresSold = 50 - pumpvehicle.tankcapacity;
            money += 1.75 * petrolLitresSold;
            busyvehicles();
            intrface();
            Thread.Sleep(Convert.ToInt32(fuellingtime * 100));
            Console.Clear();
            fuelledvehicles++;
            Program.queueing.Remove(pumpvehicle);
            Available = "avail";
            availvehicles();
            intrface();
            Thread.Sleep(1000);
            Console.Clear();
        }
        else if (pumpvehicle.vehicletype == "Van")
        {
            Console.WriteLine(pumpvehicle.vehicletype + " " + pumpvehicle.tankcapacity + " " + pumpvehicle.petroltype);
            fuellingtime = (80 - pumpvehicle.tankcapacity) / 1.5;
            totaldieselsold += 80 - pumpvehicle.tankcapacity;
            dieselLitresSold = 80 - pumpvehicle.tankcapacity;
            money += 1.85 * dieselLitresSold;
            busyvehicles();
            intrface();
            Thread.Sleep(Convert.ToInt32(fuellingtime * 100));
            Console.Clear();
            fuelledvehicles++;
            Program.queueing.Remove(pumpvehicle);
            Available = "avail";
            availvehicles();
            intrface();
            Thread.Sleep(1000);
            Console.Clear();
        }
        else if (pumpvehicle.vehicletype == "HGV")
        {
            Console.WriteLine(pumpvehicle.vehicletype + " " + pumpvehicle.tankcapacity + " " + pumpvehicle.petroltype);
            fuellingtime = (150 - pumpvehicle.tankcapacity) / 1.5;
            totalLPGsold += 150 - pumpvehicle.tankcapacity;
            LPGLitresSold = 150 - pumpvehicle.tankcapacity;
            money += 0.82 * LPGLitresSold;
            busyvehicles();
            intrface();
            Thread.Sleep(Convert.ToInt32(fuellingtime * 100));
            Console.Clear();
            fuelledvehicles++;
            Program.queueing.Remove(pumpvehicle);
            Available = "avail";
            availvehicles();
            intrface();
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
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
    public void busyvehicles()
    {
        if (Program.neededpump == 8)
        {
            Program.pump9status = "busy";
        }
        else if (Program.neededpump == 7)
        {
            Program.pump8status = "busy";
        }
        else if (Program.neededpump == 6)
        {
            Program.pump7status = "busy";
        }
        else if (Program.neededpump == 5)
        {
            Program.pump6status = "busy";
        }
        else if (Program.neededpump == 4)
        {
            Program.pump5status = "busy";
        }
        else if (Program.neededpump == 3)
        {
            Program.pump4status = "busy";
        }
        else if (Program.neededpump == 2)
        {
            Program.pump3status = "busy";
        }
        else if (Program.neededpump == 1)
        {
            Program.pump2status = "busy";
        }
        else if (Program.neededpump == 0)
        {
            Program.pump1status = "busy";
        }
    }
    public void availvehicles()
    {
        if (Program.neededpump == 8)
        {
            Program.pump9status = "avail";
        }
        else if (Program.neededpump == 7)
        {
            Program.pump8status = "avail";
        }
        else if (Program.neededpump == 6)
        {
            Program.pump7status = "avail";
        }
        else if (Program.neededpump == 5)
        {
            Program.pump6status = "avail";
        }
        else if (Program.neededpump == 4)
        {
            Program.pump5status = "avail";
        }
        else if (Program.neededpump == 3)
        {
            Program.pump4status = "avail";
        }
        else if (Program.neededpump == 2)
        {
            Program.pump3status = "avail";
        }
        else if (Program.neededpump == 1)
        {
            Program.pump2status = "avail";
        }
        else if (Program.neededpump == 0)
        {
            Program.pump1status = "avail";
        }
    }
}