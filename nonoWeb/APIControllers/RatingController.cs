using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nonoCore.Service;
using nonoCore.Entity;
using System.Collections.Generic;

namespace nonoWeb.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private RatingService _ratingService = new RatingServiceEF();

        [HttpGet]
        public IEnumerable<Rating> GetRatings()
        {
            return _ratingService.GetRatings();
        }

        [HttpPost]
        public void PostRating(Rating rating)
        {
            _ratingService.AddRating(rating);
        }
    }
}
