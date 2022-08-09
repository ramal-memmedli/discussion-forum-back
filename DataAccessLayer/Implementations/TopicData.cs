using CoreLayer.EFRepositoryBase.RepositoryBase;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Implementations
{
    public class TopicData : RepositoryBase<Topic, AppDbContext>, ITopicData
    {
        public TopicData(AppDbContext context) : base(context)
        {

        }
    }
}
