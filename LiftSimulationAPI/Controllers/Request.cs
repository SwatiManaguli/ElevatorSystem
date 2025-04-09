public class Request
{
    public int SourceFloor { get; set; }
    public int DestinationFloor { get; set; }
    public Direction Direction { get; set; }

    public Request(int sourceFloor, int destinationFloor)
    {
        SourceFloor = sourceFloor;
        DestinationFloor = destinationFloor;
        Direction = sourceFloor < destinationFloor ? Direction.Up : Direction.Down;
    }
}
