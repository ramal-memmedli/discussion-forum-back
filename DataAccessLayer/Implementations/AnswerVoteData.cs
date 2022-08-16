using CoreLayer.EFRepositoryBase.RepositoryBase;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Implementations
{
    public class AnswerVoteData : RepositoryBase<AnswerVote, AppDbContext>, IAnswerVoteData
    {
        public AnswerVoteData(AppDbContext context) : base(context)
        {

        }
    }
}
