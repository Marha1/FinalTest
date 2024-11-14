namespace Application.Dtos;

public class SensorDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float MinValue { get; set; }
    public float MaxValue { get; set; }
    public float BatteryLevel { get; set; }
    public GeoLocationDto GeoLocation { get; set; }
    public string PhotoUrl { get; set; }
}