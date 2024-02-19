using Debat.Core.Domain.Models.Abstract;

namespace Debat.Core.Domain.Entities
{
    public class UserImage : IEntity
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
        public string Target { get; set; }
    }
}
