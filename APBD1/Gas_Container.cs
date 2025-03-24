namespace APBD1;

public class Gas_Container : Container, IHazardNotifier
{
    private double pressure;

    public Gas_Container(double cargoWieght, double hight, double weight, double depth, double maxWeight,
        double pressure) : base(cargoWieght, hight, weight, depth, maxWeight)
    {
        this.pressure = pressure;
    }

    public void SendHazardAlert(string message)
    {
        Console.WriteLine($"[Alert] Container #{GetSerialNumber()}: " + message);
    }


    public override void empty_container()
    {
        cargo_wieght = cargo_wieght * 0.05;
    }

   
    
    
}