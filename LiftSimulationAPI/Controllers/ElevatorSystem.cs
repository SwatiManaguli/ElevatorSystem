using System.Collections.Generic;
using System.Linq;

public class ElevatorSystem
{
    public List<Elevator> Elevators { get; set; }
    public int MaxFloors { get; set; }

    public ElevatorSystem(int maxFloors, int numberOfElevators, int maxCapacity)
    {
        MaxFloors = maxFloors;
        Elevators = new List<Elevator>();

        for (int i = 1; i <= numberOfElevators; i++)
        {
            Elevators.Add(new Elevator(i, maxCapacity));
        }
    }

    public Elevator RequestElevator(int sourceFloor, int destinationFloor, int occupants)
    {
        if (sourceFloor < 0 || sourceFloor > MaxFloors || destinationFloor < 0 || destinationFloor > MaxFloors)
        {
            throw new ArgumentException($"Invalid floor. Allowed range: 0 to {MaxFloors}.");
        }

        var nearestElevator = Elevators
            .Where(e => e.Occupancy + occupants <= e.MaxCapacity)
            .OrderBy(e => Math.Abs(e.CurrentFloor - sourceFloor))
            .FirstOrDefault();

        if (nearestElevator == null)
        {
            throw new InvalidOperationException("No available elevators with enough capacity.");
        }

        var request = new Request(sourceFloor, destinationFloor);
        nearestElevator.AddRequest(request, occupants);

        return nearestElevator;
    }
}
