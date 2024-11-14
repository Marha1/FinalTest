namespace Application.Dtos;

public class SensorThresholdDto
{
    public Guid SensorId { get; set; }
    public float MinValue { get; set; }
    public float MaxValue { get; set; }
}