using Debat.Core.Domain.Entities;

namespace Debat.Core.Application.ViewModels
{
    public class GetCommentVM
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string AuthorUsername { get; set; }
        public string AuthorFullname { get; set; }
        public string AuthorImage { get; set; }
        public bool AreYouAuthor { get; set; }

        public void Map(Comment comment, string authorImage, bool areYouUser)
        {
            Id = comment.Id;
            Content = comment.Content;
            CreateDate = comment.CreateDate;
            UpdateDate = comment.UpdateDate;
            AuthorUsername = comment.AppUser.UserName;
            AuthorFullname = comment.AppUser.Name + " " + comment.AppUser.Surname;
            AuthorImage = authorImage;
            AreYouAuthor = areYouUser;
    }
    }
}
