using nonoCore.Entity;
using System.Collections.Generic;

namespace nonoCore.Service
{
    public interface RatingService
    {
        void AddRating(Rating rating);

        IList<Rating> GetRatings();

        void RemoveAll();
    }
}
