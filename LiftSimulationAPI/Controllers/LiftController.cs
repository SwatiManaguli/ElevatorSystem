using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class LiftController : ControllerBase
{
    private static ElevatorSystem _elevatorSystem;

    [HttpPost("initialize")]
    public IActionResult InitializeLifts(int maxFloors, int numberOfLifts, int maxCapacity)
    {
        if (numberOfLifts <= 0 || maxCapacity <= 0 || maxFloors <= 0)
        {
            return BadRequest(new { error = "Values must be greater than zero." });
        }

        _elevatorSystem = new ElevatorSystem(maxFloors, numberOfLifts, maxCapacity);
        return Ok(new { message = $"{numberOfLifts} lifts initialized with max {maxFloors} floors." });
    }

    [HttpPost("request")]
    public async Task<IActionResult> RequestLift(int sourceFloor, int destinationFloor, int occupants)
    {
        try
        {
            var elevator = _elevatorSystem.RequestElevator(sourceFloor, destinationFloor, occupants);
            return Ok(elevator);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("status")]
    public IActionResult GetLiftsStatus()
    {
        return Ok(_elevatorSystem.Elevators);
    }
}
