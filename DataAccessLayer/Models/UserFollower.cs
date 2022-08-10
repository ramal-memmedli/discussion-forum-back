﻿using CoreLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class UserFollower : IEntity
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string FollowerAppUserId { get; set; }
        public AppUser FollowerAppUser { get; set; }
    }
}
