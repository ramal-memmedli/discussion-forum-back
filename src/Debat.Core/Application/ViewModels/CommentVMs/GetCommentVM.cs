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
    }
}
