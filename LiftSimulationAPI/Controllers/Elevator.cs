using System.Collections.Generic;
using System.Threading.Tasks;

public class Elevator
{
    public int ElevatorId { get; set; }
    public int CurrentFloor { get; set; }
    public Direction Direction { get; set; }
    public int Occupancy { get; set; }
    public int MaxCapacity { get; set; }
    public List<Request> Requests { get; set; }

    public Elevator(int elevatorId, int maxCapacity)
    {
        ElevatorId = elevatorId;
        CurrentFloor = 0;
        Direction = Direction.Idle;
        Occupancy = 0;
        MaxCapacity = maxCapacity;
        Requests = new List<Request>();
    }

    public void AddRequest(Request request, int occupants)
    {
        Requests.Add(request);
        Occupancy += occupants;
        ProcessRequests();
    }

    private async void ProcessRequests()
    {
        foreach (var request in Requests)
        {
            if (CurrentFloor < request.SourceFloor)
            {
                Direction = Direction.Up;
            }
            else if (CurrentFloor > request.SourceFloor)
            {
                Direction = Direction.Down;
            }
            else
            {
                Direction = Direction.Idle;
            }

            while (CurrentFloor != request.SourceFloor)
            {
                await Task.Delay(1000);
                if (Direction == Direction.Up)
                    CurrentFloor++;
                else if (Direction == Direction.Down)
                    CurrentFloor--;
            }

            Direction = Direction.Idle;
        }
    }
}
