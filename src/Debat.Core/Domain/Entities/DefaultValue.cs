using Debat.Core.Domain.Models.Abstract;

namespace Debat.Core.Domain.Entities;

public class DefaultValue : IEntity
{
    public int Id { get; set; }
    public string? Key { get; set; }
    public string? Value { get; set; }
}