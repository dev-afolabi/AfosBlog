using System;
using System.Collections.Generic;

namespace Blog.Entities
{
    public class Comment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime DateCreated { get; set; }
        public int Likes { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}