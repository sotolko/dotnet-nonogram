using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nonoCore;
using nonoCore.Entity;

namespace nonoWeb.Models
{
    public class NonoModel
    {
        public Map Field { get; set; }

        public Guess Guess { get; set; }

        public string Content { get; set; }

        public IList<Score> Scores { get; set; }

        public IList<Comment> Comments { get; set; }

        public IList<Rating> Ratings { get; set; }
    }
}
