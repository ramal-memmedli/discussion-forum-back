using CommuPoint.Core.Domain.Models.Abstract;

namespace CommuPoint.Core.Domain.Entities
{
    public class CommunityImage : IEntity
    {
        public int Id { get; set; }
        public int CommunityId { get; set; }
        public Community Community { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
        public string Target { get; set; }
    }
}
