using CommuPoint.Core.Domain.Models.Abstract;

namespace CommuPoint.Core.Domain.Entities
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserImage> UserImages { get; set; }
    }
}
