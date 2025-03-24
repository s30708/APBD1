namespace APBD1;

public class Fluid_Container : Container, IHazardNotifier
{
    private readonly bool dangerous;

    public Fluid_Container(double cargoWieght, double hight, double weight, double depth, double maxWeight,
        bool dangerous) : base(cargoWieght, hight, weight, depth, maxWeight)
    {
        this.dangerous = dangerous;


        if (cargoWieght > 0.9 * maxWeight)
        {
            throw new ArgumentException("Cargo weight cannot be greater than max weight");
        }

        if (this.dangerous && cargoWieght > 0.5 * maxWeight)
        {
            throw new ArgumentException("Container's cargo wight cannot be greater than 0.5 * maxWeight for dangerous cargo.");
        }
        
    }

    public void SendHazardAlert(string message)
    {
        Console.WriteLine($"[Alert] Container #{GetSerialNumber()}: " + message);
    }

    public override void put_into_container(double value)
    {
        var maxFill = dangerous ? 0.5 : 0.9;
        var maxAllowedWeight = max_weight * maxFill;

        if (cargo_wieght + value <= maxAllowedWeight)
            base.put_into_container(value);
        else
            throw new OverflowException("Dangerous operation");
    }
}