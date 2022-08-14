using CoreLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
