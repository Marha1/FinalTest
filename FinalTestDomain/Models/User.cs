namespace FinalTestDomain.Models;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }

    public List<Building> Buildings { get; set; } = new();

    public List<Notification> Notifications { get; set; } = new();
    
    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is User)) return false;
        var other = (User)obj;
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