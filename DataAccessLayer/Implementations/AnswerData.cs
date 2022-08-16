using CoreLayer.EFRepositoryBase.RepositoryBase;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Implementations
{
    public class AnswerData : RepositoryBase<Answer, AppDbContext>, IAnswerData
    {
        public AnswerData(AppDbContext context) : base(context)
        {

        }
    }
}
