using System;

namespace nonoCore.Entity
{
    [Serializable]
    public class Comment
    {
        public int Id { get; set; }
        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime SubmitTime { get; set; }
    }
}
