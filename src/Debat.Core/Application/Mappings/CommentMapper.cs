using Debat.Core.Application.ViewModels;
using Debat.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debat.Core.Application.Mappings
{
    public static class CommentMapper
    {
        public static GetCommentVM MapToVM(this Comment comment,
                                           string? authorImage,
                                           bool areYouUser)
        {
            GetCommentVM vm = new GetCommentVM();

            vm.Id = comment.Id;
            vm.Content = comment.Content;
            vm.CreateDate = comment.CreateDate;
            vm.UpdateDate = comment.UpdateDate;
            vm.AuthorUsername = comment.AppUser.UserName;
            vm.AuthorFullname = comment.AppUser.Name + " " + comment.AppUser.Surname;
            vm.AuthorImage = authorImage;
            vm.AreYouAuthor = areYouUser;
            return vm;
        }
    }
}
