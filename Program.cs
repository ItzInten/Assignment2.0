using System.IO;
class Program
{
    public static List<Vehicle> queueing = new List<Vehicle>(); //list of vehicles
    public static List<Pump> fuelpumps = new List<Pump>(9); //list of pumps
    public static string typeofvehicle;
    public static int tanksize;
    public static int neededpump = 0;
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
        username = Console.ReadLine();//entering login
        while (username != "Borys") //login check 
        {
            Console.Write("Please enter your username one more time: ");
            username = Console.ReadLine();
        }
        Pump.datafile.WriteLine("    " + "Login: " + username);//writing login in the file
        Console.Write("Please enter your password: ");
        password = Console.ReadLine();//entering login
        while (password != "Prydatko")//password check 
        {
            Console.Write("Please enter your password one more time: ");
            password = Console.ReadLine();
        }
        Pump.datafile.WriteLine("    " + "Password: " + password);//writing password in the file
        Console.Clear();
        int randomvehicletype;
        int time;
        int randomfuel;
        int counter = 0;
        for (int i = 0; i < 9; i++)
        {
            Pump newpump = new Pump();
            fuelpumps.Add(newpump);
        }
        do
        {
            Pump.intrface(); //program shows the interface and updates every 1.5 seckond
            Thread.Sleep(1500);
            Console.Clear();
            randomvehicletype = rand.Next(1, 4); //randomly creating vehicle
            if (randomvehicletype == 1)
            {
                typeofvehicle = "Car";
                tanksize = rand.Next(1, 26); //randomly creating fuel in the tank which cannot be greather that half of tank capacity
                randomfuel = rand.Next(1, 4);//randomly choosing type of fuel
                if (randomfuel == 1) //these if and else if statements is here becasue cars can use any type of fuel
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
                amountofcars++;
                amountofvehicles++;
                Pump.vehicelinqueue++;
            }
            else if (randomvehicletype == 2)//randomly creating fuel in the tank which cannot be greather that half of tank capacity
            {
                typeofvehicle = "Van";
                tanksize = rand.Next(1, 41);//randomly creating fuel in the tank which cannot be greather that half of tank capacity
                randomfuel = rand.Next(1, 3);//randomly choosing type of fuel
                if (randomfuel == 1)//this if and else if statement below is here because vans can use Diesel or LPG
                {
                    vehiclefueltype = "Diesel";
                }
                else if (randomfuel == 2)
                {
                    vehiclefueltype = "LPG";
                }
                amountofvans++;
                amountofvehicles++;
                Pump.vehicelinqueue++;
            }
            else if (randomvehicletype == 3)//randomly creating fuel in the tank which cannot be greather that half of tank capacity
            {
                typeofvehicle = "HGV";
                tanksize = rand.Next(1, 76);//randomly creating fuel in the tank which cannot be greather that half of tank capacity
                vehiclefueltype = "Diesel";
                amountofhgvs++;
                amountofvehicles++;
                Pump.vehicelinqueue++;
            }
            if (amountofcars + amountofhgvs + amountofvans == 5) // if the queue is 5 vehicles will be created randomly between 1000 and 2000 milliseconds
            {
                time = rand.Next(1000, 2000);
            }
            else //but normally vehicles will be created randomly between 1500 and 2200 milliseconds
            {
                time = rand.Next(1500, 2200);
            }
            Thread.Sleep(time);
            Vehicle allvehicles = new Vehicle(typeofvehicle, tanksize, vehiclefueltype);//creating the object for this vehicle
            for (int i = 0; i <= 8; i++) // this for loop is for choosing right pump which is not busy
            {
                counter++;
                if (fuelpumps[i].Available == "avail")
                {
                    neededpump = i;
                }
            }
            counter = 0;
            queueing.Add(allvehicles); //adding vehicle to a list
            fuelpumps[neededpump].addvehicle(allvehicles);//passing vehicle to a pump
            Pump.intrface();
            Thread.Sleep(1500);
            Console.Clear();
        } while (amountofvehicles < 10); //program is going to create 10 vehicles because it is perfect amount of vehicles for showing program performance
        Pump.data();//showing data file
        Console.ReadKey();
    }
}