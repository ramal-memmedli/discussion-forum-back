using Debat.Core.Domain.Entities.Abstracts;

namespace Debat.Core.Domain.Entities;

public class DefaultValue : IEntity
{
    public int Id { get; set; }
    public string? Key { get; set; }
    public string? Value { get; set; }
}