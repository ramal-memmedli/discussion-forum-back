using CoreLayer.EFRepositoryBase.RepositoryBase;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Implementations
{
    public class CategoryData : RepositoryBase<Category, AppDbContext>, ICategoryData
    {
        public CategoryData(AppDbContext context) : base(context)
        {

        }
    }
}
