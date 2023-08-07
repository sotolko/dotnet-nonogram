using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nonoCore;
using nonoWeb.Models;
using nonoCore.Service;
using nonoCore.Entity;
using System;

namespace nonoWeb.Controllers
{
    public class NonoController : Controller
    {
        private const string GuessSessionKey = "guess";
        private const string FieldSessionKey = "field";

        private IScoreService _scoreService = new ScoreServiceEF();
        private DateTime startedAt;

        public IActionResult Index()
        {
            var field = new Map(5, 5,0);
            var guess = new Guess(5, 5, field);
            startedAt = DateTime.Now;

            HttpContext.Session.SetObject(GuessSessionKey, guess);
            HttpContext.Session.SetObject(FieldSessionKey, field);

            return View("Index",CreateModel());
        }

        public IActionResult Move(int x,int y)
        {
            var guess = (Guess) HttpContext.Session.GetObject(GuessSessionKey);
            guess.playerGuess(x, y);

            if (guess.isSolved())
            {
                DateTime finishedAt = DateTime.Now;

                _scoreService.AddScore(new Score { Player = Environment.UserName, FinishedAt = finishedAt, StartedAt = startedAt, Seconds = finishedAt.Second - startedAt.Second });
            }

            HttpContext.Session.SetObject(GuessSessionKey,guess);
            return View("Index",CreateModel());
        }

        private NonoModel CreateModel()
        {
            var map = (Map)HttpContext.Session.GetObject(FieldSessionKey);
            var guess = (Guess)HttpContext.Session.GetObject(GuessSessionKey);
            var scores = _scoreService.GetTopScores();

            return new NonoModel { Field = map, Guess = guess ,Scores = scores};
        }


    }
}
