using Debat.Core.Domain.Models.Abstract;

namespace Debat.Core.Domain.Entities;

public class UserBookmark : IEntity
{
    public int Id { get; set; }
    public string? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    public int TopicId { get; set; }
    public Topic? Topic { get; set; }
}