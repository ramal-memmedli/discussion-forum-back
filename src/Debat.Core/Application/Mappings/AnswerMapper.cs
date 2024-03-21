using Debat.Core.Application.ViewModels;
using Debat.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Debat.Core.Application.Mappings
{
    public static class AnswerMapper
    {
        public static GetAnswerVM MapToVM(this Answer answer,
                                          string? authorImage,
                                          string? authorLevel,
                                          bool areYouAuthor,
                                          bool isVotedByYou,
                                          string yourVote,
                                          int voteCount,
                                          List<GetCommentVM> commentsVM)
        {
            GetAnswerVM vm = new GetAnswerVM();

            vm.Id = answer.Id;
            vm.Content = answer.Content;
            vm.CreateDate = answer.CreateDate;
            vm.AuthorUsername = answer.AppUser.UserName;
            vm.AuthorImage = authorImage;
            vm.AuthorLevel = authorLevel;
            vm.AuthorFullname = answer.AppUser.Name + " " + answer.AppUser.Surname;
            vm.AreYouAuthor = areYouAuthor;
            vm.IsVotedByYou = isVotedByYou;
            vm.YourVote = yourVote;
            vm.VoteCount = voteCount;
            vm.CommentCount = commentsVM.Count;
            vm.Comments = commentsVM;

            return vm;
        }
    }
}
