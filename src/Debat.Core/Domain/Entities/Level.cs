using Debat.Core.Domain.Entities.Abstracts;

namespace Debat.Core.Domain.Entities;

public class Level : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int RequiredPoint { get; set; }
    public List<AppUser>? AppUsers { get; set; }
}