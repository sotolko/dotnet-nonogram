using nonoCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace nonoCore.Service
{
    public class RatingServiceEF : RatingService
    {
        public void AddRating(Rating rating)
        {
            using (var context = new RatingDBContext())
            {
                context.Ratings.Add(rating);
                context.SaveChanges();
            }
        }

        public IList<Rating> GetRatings()
        {
            using (var context = new RatingDBContext())
            {
                return context.Ratings.OrderBy(s => s.SubmitTime).ToList();
            }
        }

        public void RemoveAll()
        {
            using (var context = new RatingDBContext())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM Ratings");
            }
        }
    }
}
