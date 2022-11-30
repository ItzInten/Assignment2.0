using System.IO;
class Program
{
    public static List<Vehicle> queueing = new List<Vehicle>();
    public static Vehicle allvehicles = new Vehicle(typeofvehicle, tanksize, vehiclefueltype);
    public static string typeofvehicle;
    public static int tanksize;
    public static string vehiclefueltype;
    public static int amountofvehicles;
    public static int amountofcars;
    public static int amountofvans;
    public static int amountofhgvs;
    public static string fueltype;
    public static string pump1status = "avail";
    public static string pump2status = "avail";
    public static string pump3status = "avail";
    public static string pump4status = "avail";
    public static string pump5status = "avail";
    public static string pump6status = "avail";
    public static string pump7status = "avail";
    public static string pump8status = "avail";
    public static string pump9status = "avail";
    public static string username;
    public static string password;
    static void Main(string[] args)
    {
        Program mainprog = new Program();
        Random rand = new Random();
        Console.Write("Please enter your username: ");
        username = Console.ReadLine();
        GasStation.datafile.WriteLine("    " + "Login: " + username);
        Console.Write("Please enter your password: ");
        password = Console.ReadLine();
        GasStation.datafile.WriteLine("    " + "Password: " + password);
        Console.Clear();
        int randomvehicletype;
        int time;
        int randomfuel;
        do{
        randomvehicletype = rand.Next(1,4);
        if (randomvehicletype == 1)
        {
            typeofvehicle = "Car";
            tanksize = rand.Next(1,26);
            randomfuel = rand.Next(1,4);
            if (randomfuel == 1)
            {
                vehiclefueltype = "Petrol";
            }
            else if (randomfuel == 2)
            {
                vehiclefueltype = "Diesel";
            }
            else if (randomfuel == 3)
            {
                vehiclefueltype = "LPG";
            }
            amountofvehicles++;
            GasStation.vehicelinqueue++;
        }
        else if (randomvehicletype == 2)
        {
            typeofvehicle = "Van";
            tanksize = rand.Next(1,41);
            randomfuel = rand.Next(1,3);
            if (randomfuel == 1)
            {
                vehiclefueltype = "Diesel";
            }
            else if (randomfuel == 2)
            {
                vehiclefueltype = "LPG";
            }
            //Console.WriteLine("Your vehicle is " + typeofvehicle + " using " + vehiclefueltype);
            //Console.WriteLine("Amount of fuel in the tank is " + tanksize);
            amountofvans++;
            amountofvehicles++;
            GasStation.vehicelinqueue++;
        }
        else if (randomvehicletype == 3)
        {
            typeofvehicle = "HGV";
            tanksize = rand.Next(1,76);
            vehiclefueltype = "Diesel";
            //Console.WriteLine("Your vehicle is " + typeofvehicle + " using " + vehiclefueltype);
            //Console.WriteLine("Amount of fuel in the tank is " + tanksize);
            amountofhgvs++;
            amountofvehicles++;
            GasStation.vehicelinqueue++;
        }
        time = rand.Next(1500, 2200);
        Thread.Sleep(time);
        Vehicle allvehicles = new Vehicle(typeofvehicle, tanksize, vehiclefueltype);
        Thread pumps = new Thread(() => GasStation.queueingSystem(allvehicles));
        if (GasStation.vehicelinqueue == 1)
        {
            pumps.Start();
            pump9status = "busy";
        }
        queueing.Add(allvehicles);
        } while (amountofvehicles < 10);
        foreach (Vehicle allvehicles in queueing)
        {
	        Console.WriteLine(allvehicles.vehicletype +" "+ allvehicles.tankcapacity +" "+ allvehicles.petroltype);
        }
        Console.ReadKey();
    }
}