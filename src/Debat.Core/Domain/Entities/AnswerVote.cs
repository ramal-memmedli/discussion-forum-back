using Debat.Core.Domain.Entities.Abstracts;

namespace Debat.Core.Domain.Entities;

public class AnswerVote : IEntity
{
    public int Id { get; set; }
    public int AnswerId { get; set; }
    public Answer? Answer { get; set; }
    public string? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    public bool IsUpVote { get; set; }
}