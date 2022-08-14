using CoreLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Level : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RequiredPoint { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
