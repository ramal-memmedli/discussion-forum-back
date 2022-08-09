using CoreLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserImage> UserImages { get; set; }
    }
}
