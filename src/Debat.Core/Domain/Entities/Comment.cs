using Debat.Core.Domain.Entities.Abstracts;

namespace Debat.Core.Domain.Entities;

public class Comment : IEntity
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public int AnswerId { get; set; }
    public Answer? Answer { get; set; }
    public string? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
}