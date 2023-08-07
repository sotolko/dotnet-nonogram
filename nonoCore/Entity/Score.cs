using System;

namespace nonoCore.Entity
{
    [Serializable]
    public class Score
    {
        public int Id { get; set; }

        public string Player { get; set; }

        public DateTime FinishedAt { get; set; }

        public DateTime StartedAt { get; set; }

        public int Seconds { get; set; }
    }
}
