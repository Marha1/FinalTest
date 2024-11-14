using FinalTestDomain.ValueObject;

namespace FinalTestDomain.Models;

public class Sensor
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
        
    public GeoLocation GeoLocation { get; set; }
        
    public string PhotoUrl { get; set; }
    public float MinValue { get; set; }
    public float MaxValue { get; set; }
    public float BatteryLevel { get; set; }

    public Guid BuildingId { get; set; }
    public Building Building { get; set; }

    public List<SensorData> Data { get; set; } = new List<SensorData>();
    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Sensor)) return false;
        var other = (Sensor)obj;
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