namespace APBD1;

public abstract class Container
{
    private static int counter;
    protected double cargo_wieght;
    private double depth;
    private double hight;
    protected double max_weight;
    private readonly string serial_number;
    private double weight;

    protected Container(double cargoWieght, double hight, double weight, double depth, double maxWeight)
    {
        if (cargoWieght > maxWeight) throw new ArgumentException("Weight cannot be greater than max weight");


        cargo_wieght = cargoWieght;
        this.hight = hight;
        this.weight = weight;
        this.depth = depth;
        max_weight = maxWeight;

        counter++;

        var type = GetType().Name;

        switch (type)
        {
            case "Fluid_Container":
                serial_number = "KON-" + "L-" + counter;
                break;
            case "Gas_Container":
                serial_number = "KON-" + "G-" + counter;
                break;
            case "Freezer_Container":
                serial_number = "KON-" + "C-" + counter;
                break;
        }
    }

    public string GetSerialNumber()
    {
        return serial_number;
    }

    public virtual void empty_container()
    {
        cargo_wieght = 0;
    }

    public virtual void put_into_container(double value)
    {
        if (cargo_wieght + value <= max_weight)
            cargo_wieght += value;
        else
            throw new OverflowException();
    }
    
    public virtual void put_into_container(double value, Product product)
    {
        if (cargo_wieght + value <= max_weight)
            cargo_wieght += value;
        else
            throw new OverflowException();
    }
    
    

    public double get_cargo_wieght()
    {
        return cargo_wieght;
    }

    public double get_weight()
    {
        return weight;
    }

    public override string ToString()
    {
        return $"Container {serial_number}:\n" +
               $"  - Weight: {weight} kg\n" +
               $"  - Height: {hight} m\n" +
               $"  - Depth: {depth} m\n" +
               $"  - Max Weight: {max_weight} kg\n" +
               $"  - Cargo Weight: {cargo_wieght} kg\n";
    }

}