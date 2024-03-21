using Debat.Core.Domain.Models.Abstract;

namespace Debat.Core.Domain.Entities;

public class CommunityMember : IEntity
{
    public int Id { get; set; }
    public int CommunityId { get; set; }
    public Community? Community { get; set; }
    public string? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    public string? position { get; set; }
}