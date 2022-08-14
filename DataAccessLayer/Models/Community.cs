using CoreLayer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Community : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public int Point { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<CommunityMember> CommunityMembers { get; set; }
        public List<CommunityImage> CommunityImages { get; set; }
    }
}
