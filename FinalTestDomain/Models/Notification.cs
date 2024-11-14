namespace FinalTestDomain.Models;

public class Notification
{
    public Guid Id { get; set; }
        
    // Связь с User
    public Guid UserId { get; set; }
    public User User { get; set; }
        
    public DateTime Date { get; set; }
    public string Message { get; set; }
    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Notification)) return false;
        var other = (Notification)obj;
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