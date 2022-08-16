using CoreLayer.EFRepositoryBase.RepositoryBase;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Implementations
{
    public class CommentData : RepositoryBase<Comment, AppDbContext>, ICommentData
    {
        public CommentData(AppDbContext context) : base(context)
        {

        }
    }
}
