// See https://aka.ms/new-console-template for more information

using APBD1;


try
{
    // Tworzenie kontenerów
    Fluid_Container fluidContainer = new Fluid_Container(10, 200, 500, 300, 1000, false);
    Gas_Container gasContainer = new Gas_Container(20, 200, 500, 300, 1000, 2.5);
    Freezer_Container freezerContainer = new Freezer_Container(30, 200, 500, 300, 1000, Product.Meat, -10);

    Console.WriteLine(fluidContainer);
    Console.WriteLine(gasContainer);
    Console.WriteLine(freezerContainer);

    // Testowanie załadowania ładunku
    fluidContainer.put_into_container(400);
    Console.WriteLine("Po załadowaniu płynu: " + fluidContainer.get_cargo_wieght());

    gasContainer.empty_container();
    Console.WriteLine("Po opróżnieniu gazu: " + gasContainer.get_cargo_wieght());

    // Tworzenie statku i dodawanie kontenerów
    List<Container> containers = new List<Container> { fluidContainer, gasContainer, freezerContainer };
    Container_ship ship = new Container_ship(containers, 25, 100, 50000);
    Console.WriteLine(ship);

    // Przenoszenie kontenera między statkami
    Container_ship newShip = new Container_ship(new List<Container>(), 30, 150, 70000);
    Container_ship.move_container_between_ships(fluidContainer, ship, newShip);
    Console.WriteLine("Po przeniesieniu kontenera na nowy statek:");
    Console.WriteLine(newShip);
}
catch (Exception ex)
{
    Console.WriteLine("Błąd: " + ex.Message);
}


