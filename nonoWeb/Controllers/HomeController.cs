using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nonoWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using nonoCore.Service;
using nonoCore.Entity;

namespace nonoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private RatingService _ratingService = new RatingServiceEF();
        private CommentService _commentService = new CommentServiceEF();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Comment()
        {
            return View("Comment", CreateModel());
        }

        [HttpPost]
        public IActionResult CommentAdd(string content)
        {
            _commentService.AddComment(new Comment { Author = Environment.UserName, Content = content, SubmitTime = DateTime.Now });
            return View("Comment", CreateModel());
        }
        public IActionResult Rate()
        {
            return View("Rate", CreateModel());
        }
        public IActionResult RateAdd(int stars)
        {
            _ratingService.AddRating(new Rating { Id = 1,Author = Environment.UserName, RatingScore = stars, SubmitTime = DateTime.Now });
            return View("Rate", CreateModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private NonoModel CreateModel()
        {
            var comments = _commentService.GetComments();
            var ratings = _ratingService.GetRatings();

            return new NonoModel { Comments = comments, Ratings = ratings};
        }
    }
}
