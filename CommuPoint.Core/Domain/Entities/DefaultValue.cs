using CommuPoint.Core.Domain.Models.Abstract;

namespace CommuPoint.Core.Domain.Entities
{
    public class DefaultValue : IEntity
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
