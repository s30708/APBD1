namespace APBD1;

public class Freezer_Container : Container
{
    private Product product { get;  set; }

    private readonly Dictionary<Product, double> productTemperatures = new()
    {
        { Product.Bananas, 13.3 },
        { Product.Chocolate, 18.0 },
        { Product.Fish, 2.0 },
        { Product.Meat, -15.0 },
        { Product.IceCream, -18.0 },
        { Product.FrozenPizza, -30.0 },
        { Product.Cheese, 7.2 },
        { Product.Sausages, 5.0 },
        { Product.Butter, 20.5 },
        { Product.Eggs, 19.0 }
    };

    private double temperature;


    public Freezer_Container(double cargoWieght, double hight, double weight, double depth, double maxWeight,
        Product product, double temp) : base(cargoWieght, hight, weight, depth, maxWeight)
    {
        if (temp < productTemperatures[product])
            throw new ArgumentException($"declared temperature is too low to store #{product.ToString()}");

        this.product = product;
        temperature = temp;
    }

    public override void put_into_container(double value, Product product)
    {
        base.put_into_container(value);
        this.product = product;
    }
}