public class Pump
{
    static public int fuelledvehicles = 0;
    static public int vehicelinqueue = 0;
    static public double petrolLitresSold, dieselLitresSold, LPGLitresSold, totalpetrolsold, totaldieselsold, totalLPGsold, money = 0;
    public static StreamWriter datafile = new StreamWriter("fuelstationData.txt");
    public string Available = "avail";
    public Vehicle pumpvehicle { get; set; }
    public void addvehicle(Vehicle passvehicle)//this method is for passing vehicle from the queue
    {
        pumpvehicle = passvehicle;
        Thread pumps = new Thread(() => processvehicle(pumpvehicle));//creating a new thread for each new vehicle
        pumps.Start();
    }
    private void processvehicle(Vehicle pumpvehicle) //this method is for processing vehicles
    {
        Available = "busy"; //changing pump status, because now it's going to be busy
        double fuellingtime;
        if (pumpvehicle.vehicletype == "Car") //this if statement is for checking whether the vehicle a car or other type of vehicles
        {
            Console.WriteLine(pumpvehicle.vehicletype + " " + pumpvehicle.tankcapacity + " " + pumpvehicle.petroltype);
            fuellingtime = (50 - pumpvehicle.tankcapacity) / 1.5; //we have a criteria which says that pump can dispense 1.5 litres/second
            totalpetrolsold += 50 - pumpvehicle.tankcapacity;//total diesel sold
            petrolLitresSold = 50 - pumpvehicle.tankcapacity;//how much litres of petrol have been sold for this vehicle
            money += 1.75 * petrolLitresSold; // total earned money for cars
            busyvehicles();//this method is for interface which can show to us different condition of vehicles but this method is for busy condition
            Thread.Sleep(Convert.ToInt32(fuellingtime * 100)); //thread is sleeping which shows that car is fuelling
            fuelledvehicles++;
            Program.queueing.Remove(pumpvehicle); // removing car from the list
            Available = "avail"; //pump is getting available
            Program.amountofcars--;
            availvehicles(); //this method is for interface which can show to us different condition of vehicles
        }
        else if (pumpvehicle.vehicletype == "Van")
        {
            Console.WriteLine(pumpvehicle.vehicletype + " " + pumpvehicle.tankcapacity + " " + pumpvehicle.petroltype);
            fuellingtime = (80 - pumpvehicle.tankcapacity) / 1.5;//we have a criteria which says that pump can dispense 1.5 litres/second
            totaldieselsold += 80 - pumpvehicle.tankcapacity;//total diesel sold
            dieselLitresSold = 80 - pumpvehicle.tankcapacity;//how much litres of diesel have been sold for this vehicle
            money += 1.85 * dieselLitresSold;// total earned money for vans
            busyvehicles();//this method is for interface which can show to us different condition of vehicles but this method is for busy condition
            Thread.Sleep(Convert.ToInt32(fuellingtime * 100));//thread is sleeping which shows that van is fuelling
            fuelledvehicles++;
            Program.queueing.Remove(pumpvehicle);// removing van from the list
            Available = "avail";//pump is getting available
            Program.amountofvans--;
            availvehicles();//this method is for interface which can show to us different condition of vehicles
        }
        else if (pumpvehicle.vehicletype == "HGV")
        {
            Console.WriteLine(pumpvehicle.vehicletype + " " + pumpvehicle.tankcapacity + " " + pumpvehicle.petroltype);
            fuellingtime = (150 - pumpvehicle.tankcapacity) / 1.5;//we have a criteria which says that pump can dispense 1.5 litres/second
            totalLPGsold += 150 - pumpvehicle.tankcapacity;//total diesel sold
            LPGLitresSold = 150 - pumpvehicle.tankcapacity;//how much litres of diesel have been sold for this vehicle
            money += 0.82 * LPGLitresSold;// total earned money for HGVs
            busyvehicles();//this method is for interface which can show to us different condition of vehicles but this method is for busy condition
            Thread.Sleep(Convert.ToInt32(fuellingtime * 100));//thread is sleeping which shows that van is fuelling
            fuelledvehicles++;
            Program.queueing.Remove(pumpvehicle);// removing HGV from the list
            Available = "avail";//pump is getting available
            Program.amountofhgvs--;
            availvehicles();//this method is for interface which can show to us different condition of vehicles
        }
    }
    static public void intrface() //interface method
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
    public static void data() //method for storing data inside of the file
    {
        datafile.WriteLine("    " + "Petrol: " + totalpetrolsold);
        datafile.WriteLine("    " + "Diesel: " + totaldieselsold);
        datafile.WriteLine("    " + "LPG: " + totalLPGsold);
        datafile.WriteLine("Cost: " + money + " GBP");
        datafile.WriteLine("1%:   " + money / 100 + " GBP");
        datafile.WriteLine("Vehicles serviced: " + fuelledvehicles);
        datafile.WriteLine("Vehicles gone before: " + (10 - fuelledvehicles));
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
    public void busyvehicles() //method for changing condition of the pump to busy
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
    public void availvehicles()//method for changing condition of the pump to available
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