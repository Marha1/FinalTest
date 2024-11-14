namespace FinalTestDomain.Models;

public class Building
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public List<User> Users { get; set; } = new List<User>();

    public List<Sensor> Sensors { get; set; } = new List<Sensor>();
    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Building)) return false;
        var other = (Building)obj;
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