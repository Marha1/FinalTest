namespace Application.Dtos;

public class SensorDataDto
{
    public Guid Id { get; set; }
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    public DateTime Timestamp { get; set; }
}