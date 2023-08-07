using nonoCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace nonoCore.Service
{
    public class ScoreServiceEF : IScoreService
    {
        public void AddScore(Score score)
        {
            using (var context = new ScoreDBContext())
            {
                context.Scores.Add(score);
                context.SaveChanges();
            }
        }

        public IList<Score> GetTopScores()
        {
            using (var context = new ScoreDBContext())
            {
                return context.Scores.OrderBy(s => s.Seconds).Take(10).ToList();
            }
        }

        public void ResetScore()
        {
            using (var context = new ScoreDBContext())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM Scores");
            }
        }
    }
}
