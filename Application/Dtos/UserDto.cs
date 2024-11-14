namespace Application.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public List<Guid> BuildingIds { get; set; } = new List<Guid>();
}