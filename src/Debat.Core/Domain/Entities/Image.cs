using Debat.Core.Domain.Entities.Abstracts;

namespace Debat.Core.Domain.Entities;

public class Image : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<UserImage>? UserImages { get; set; }
}