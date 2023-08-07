using nonoCore.Entity;
using System.Collections.Generic;

namespace nonoCore.Service
{
    public interface IScoreService
    {
        void AddScore(Score score);

        IList<Score> GetTopScores();

        void ResetScore();
    }
}
