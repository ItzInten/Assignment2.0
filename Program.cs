class Program
{
    public static List<Vehicle> queueing = new List<Vehicle>();
    public static string typeofvehicle;
    public static int tanksize;
    public static string vehiclefueltype;
    public static int amountofvehicles;
    public static int amountofcars;
    public static int amountofvans;
    public static int amountofhgvs;
    public static string fueltype;
    static void Main(string[] args)
    {
        Program mainprog = new Program();
        Random rand = new Random();
        Thread pump1 = new Thread(GasStation.queueingSystem);
        Thread pump2 = new Thread(GasStation.queueingSystem);
        Thread pump3 = new Thread(GasStation.queueingSystem);
        Thread pump4 = new Thread(GasStation.queueingSystem);
        Thread pump5 = new Thread(GasStation.queueingSystem);
        Thread pump6 = new Thread(GasStation.queueingSystem);
        Thread pump7 = new Thread(GasStation.queueingSystem);
        Thread pump8 = new Thread(GasStation.queueingSystem);
        Thread pump9 = new Thread(GasStation.queueingSystem);
        pump1.Start();
        //pump4.Start();
        //pump7.Start();
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
            //Console.WriteLine("Your vehicle is " + typeofvehicle + " using " + vehiclefueltype);
            //Console.WriteLine("Amount of fuel in the tank is " + tanksize);
            amountofcars++;
            amountofvehicles++;
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
        }
        time = rand.Next(1500, 2200);
        Thread.Sleep(time);
        Vehicle allvehicles = new Vehicle(typeofvehicle, tanksize, vehiclefueltype);
        queueing.Add(allvehicles);
        } while (amountofvehicles < 10);
        foreach (Vehicle allvehicles in queueing)
        {
	        Console.WriteLine(allvehicles.vehicletype +" "+ allvehicles.tankcapacity +" "+ allvehicles.petroltype);
        }
        Console.ReadKey();
    }
}