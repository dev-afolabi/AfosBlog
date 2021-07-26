using System;

namespace Blog.Entities
{
    public class Tag
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Description { get; set; }
    }
}