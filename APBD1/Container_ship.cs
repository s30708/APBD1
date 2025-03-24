namespace APBD1;

public class Container_ship
{
    private List<Container> containers{get;set;}
    private double max_speed;
    private int max_num_containers;
    private double max_weight_containers;

    public Container_ship(List<Container> containers, double maxSpeed, int maxNumContainers, double maxWeightContainers)
    {
        max_speed = maxSpeed;
        max_num_containers = maxNumContainers;
        max_weight_containers = maxWeightContainers;

        double sum = 0;
        
        foreach (var container in containers)
        {
            sum += container.get_weight() + container.get_cargo_wieght();
        }
        
        
        if (containers.Count <= max_num_containers )
        {
            if (sum >= max_weight_containers)
            {
                throw new ArgumentException("Containers weight is more than ship's capacity.");
            }
            
            this.containers = containers;
        }
        else
        {
            throw new ArgumentException("Containers count is more than max number of containers.");
        }
    }
    
    


    public double get_current_weight()
    {
        double sum = 0;
        foreach (var container in containers)
        {
            sum += container.get_weight();
        }
        return sum;
    }
    

    public void add_container(Container container)
    {
        containers.Add(container);
    }

    public void add_containers(List<Container> containers)
    {
        containers.AddRange(containers);
    }

    public void remove_container(Container container)
    {
        containers.Remove(container);
    }
    
    public bool ContainsContainer(Container container)
    {
        return containers.Contains(container);
    }

    public bool CanAddContainer(Container container)
    {
        return get_current_weight() + container.get_weight() <= max_weight_containers; 
    }

    public void remove_container(string serial_number)
    {
        bool found = false;

        for (int i = containers.Count - 1; i >= 0; i--)
        {
            if (containers[i].GetSerialNumber() == serial_number)
            {
                containers.RemoveAt(i);
                found = true;
            }
        }

        if (!found)
        {
            throw new ArgumentException($"Container with serial number {serial_number} not found.");
        }
    }


    public void replace_container(Container container_put, String serial_number_out)
    {
        bool found = false;

        for (int i = containers.Count - 1; i >= 0; i--)
        {
            if (containers[i].GetSerialNumber() == serial_number_out)
            {
                containers[i] = container_put;
                found = true;
            }
        }

        if (!found)
        {
            throw new ArgumentException($"Container with serial number {serial_number_out} not found.");
        }
    }

    public static void move_container_between_ships(Container container, Container_ship old_ship, Container_ship new_ship)
    {
        if (container == null)
        {
            throw new ArgumentNullException(nameof(container), "Container cannot be null.");
        }
        if (old_ship == null)
        {
            throw new ArgumentNullException(nameof(old_ship), "Old ship cannot be null.");
        }
        if (new_ship == null)
        {
            throw new ArgumentNullException(nameof(new_ship), "New ship cannot be null.");
        }

        // Sprawdzenie, czy stary statek zawiera kontener
        if (!old_ship.ContainsContainer(container))
        {
            throw new ArgumentException($"The old ship does not have the container {container.GetSerialNumber()}.");
        }

        // Sprawdzenie, czy nowy statek ma wystarczająco dużo miejsca
        if (!new_ship.CanAddContainer(container))
        {
            throw new InvalidOperationException($"The new ship cannot accommodate the container {container.GetSerialNumber()} due to capacity limits.");
        }

        // Usunięcie kontenera ze starego statku
        old_ship.remove_container(container);

        // Dodanie kontenera do nowego statku
        new_ship.add_container(container);
    }
    
    public override string ToString()
    {
        string containersInfo = containers.Count > 0 
            ? string.Join("\n  ", containers.Select(c => $"- {c.GetSerialNumber()}, Weight: {c.get_weight()} kg, Cargo: {c.get_cargo_wieght()} kg"))
            : "No containers on board.";

        return $"Ship Information:\n" +
               $"  - Max Speed: {max_speed} knots\n" +
               $"  - Max Containers: {max_num_containers}\n" +
               $"  - Max Cargo Weight: {max_weight_containers} kg\n" +
               $"  - Current Cargo Weight: {get_current_weight()} kg\n" +
               $"  - Number of Containers: {containers.Count}\n" +
               $"  - Containers:\n  {containersInfo}";
    }

    
}