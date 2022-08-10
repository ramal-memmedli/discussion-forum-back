using CoreLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class CommunityMember : IEntity
    {
        public int Id { get; set; }
        public int CommunityId { get; set; }
        public Community Community { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string position { get; set; }
    }
}
