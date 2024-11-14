namespace FinalTestDomain.Models;

public class SensorData
{
    public Guid Id { get; set; }
    public Guid SensorId { get; set; }
    public Sensor Sensor { get; set; }
    public DateTime Timestamp { get; set; }
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    public float BatteryLevel { get; set; }
    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is SensorData)) return false;
        var other = (SensorData)obj;
        return Id == other.Id;
    }

    /// <summary>
    ///     Вычисляет хеш-код для пользовательского объекта.
    /// </summary>
    /// <returns>Хеш-код объекта.</returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
