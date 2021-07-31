using System;
using System.Collections.Generic;

namespace Blog.Entities
{
    public class Post
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public int ReadTime { get; set; }
    }
}
