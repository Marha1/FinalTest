using FinalTestDomain.Models;

namespace Application.Dtos;

public class BuildingDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Guid> SensorIds { get; set; } = new List<Guid>();
    public List<Guid> UserIds { get; set; } = new List<Guid>();
}
