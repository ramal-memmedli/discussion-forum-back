using CommuPoint.Core.Domain.Models.Abstract;

namespace CommuPoint.Core.Domain.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
