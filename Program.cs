class Program
{
    public static string typeofvehicle;
    public static int tanksize;
    public static string vehiclefueltype;
    public static int amountofvehicles;
    static void Main(string[] args)
    {
        List<Vehicle> queueing = new List<Vehicle>();
        Random rand = new Random();
        int randomvehicletype;
        do{
        randomvehicletype = rand.Next(1,4);
        if (randomvehicletype == 1)
        {
            typeofvehicle = "Car";
            tanksize = rand.Next(1,26);
            vehiclefueltype = "Petrol";
            Console.WriteLine("Your vehicle is " + typeofvehicle + " using " + vehiclefueltype);
            Console.WriteLine("Amount of fuel in the tank is " + tanksize);
            amountofvehicles++;
        }
        else if (randomvehicletype == 2)
        {
            typeofvehicle = "Van";
            tanksize = rand.Next(1,41);
            vehiclefueltype = "Fuel Oil";
            Console.WriteLine("Your vehicle is " + typeofvehicle + " using " + vehiclefueltype);
            Console.WriteLine("Amount of fuel in the tank is " + tanksize);
            amountofvehicles++;
        }
        else if (randomvehicletype == 3)
        {
            typeofvehicle = "HGV";
            tanksize = rand.Next(1,76);
            vehiclefueltype = "Diesel";
            Console.WriteLine("Your vehicle is " + typeofvehicle + " using " + vehiclefueltype);
            Console.WriteLine("Amount of fuel in the tank is " + tanksize);
            amountofvehicles++;
        }
        Vehicle allvehicles = new Vehicle(typeofvehicle, tanksize, vehiclefueltype);
        queueing.Add(allvehicles);
        } while (amountofvehicles < 10);
        foreach (var item in queueing)
        {
	        Console.WriteLine(item);
        }
        Console.ReadKey();
    }
}