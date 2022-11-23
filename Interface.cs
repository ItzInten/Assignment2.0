class Interface
{
    public void intrface()
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Queue: Cars: " + vehicle.cars + " Vans: " + vehicle.vans + " HGVs: " + vehicle.hgvs);
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Line 1:   Pump 1:  " + vehicle.cars +  "  Pump 2:  " + vehicle.cars +  "  Pump 3:  " + vehicle.cars);
        Console.WriteLine("Line 2:   Pump 4:  " + vehicle.vans +  "  Pump 5:  " + vehicle.vans +  "  Pump 6:  " + vehicle.vans);
        Console.WriteLine("Line 3:   Pump 7:  " + vehicle.hgvs +  "  Pump 8:  " + vehicle.hgvs +  "  Pump 9:  " + vehicle.hgvs);
    }
}