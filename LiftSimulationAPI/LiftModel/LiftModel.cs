namespace LiftSimulationAPI.LiftModel
{
    public class LiftModel
    {
        public int LiftId { get; set; }
        public int CurrentFloor { get; set; }
        public string Direction { get; set; } = "Idle"; // "Up", "Down", "Idle"
        public int Occupancy { get; set; }
        public int MaxCapacity { get; set; }
    }
}