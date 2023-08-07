using System;

namespace nonoCore.Entity
{
    [Serializable]
    public class Rating
    {
        public int Id { get; set; }
        public string Author { get; set; }

        public int RatingScore { get; set; }

        public DateTime SubmitTime { get; set; }
    }
}
