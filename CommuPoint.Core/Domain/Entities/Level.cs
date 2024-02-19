using CommuPoint.Core.Domain.Models.Abstract;

namespace CommuPoint.Core.Domain.Entities
{
    public class Level : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RequiredPoint { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
