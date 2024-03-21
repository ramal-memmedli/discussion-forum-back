using Debat.Core.Domain.Models.Abstract;

namespace Debat.Core.Domain.Entities;

public class UserFollower : IEntity
{
    public int Id { get; set; }
    public string? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    public string? FollowerAppUserId { get; set; }
    public AppUser? FollowerAppUser { get; set; }
}