using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nonoCore.Service;
using nonoCore.Entity;
using System.Collections.Generic;

namespace nonoWeb.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private IScoreService _scoreService = new ScoreServiceEF();

        [HttpGet]
        public IEnumerable<Score> GetScores()
        {
            return _scoreService.GetTopScores();
        }

        [HttpPost]
        public void PostScore(Score score)
        {
            _scoreService.AddScore(score);
        }
    }
}
