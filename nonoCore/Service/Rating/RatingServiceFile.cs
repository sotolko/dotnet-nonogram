using nonoCore.Entity;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace nonoCore.Service
{
    public class RatingServiceFile : RatingService
    {
        private const string FileName = "ratings.bin";

        private IList<Rating> _ratings = new List<Rating>();

        void RatingService.AddRating(Rating rating)
        {
            _ratings.Add(rating);
            SaveRatings();
        }

        IList<Rating> RatingService.GetRatings()
        {
            LoadRatings();
            return _ratings.OrderByDescending(s => s.SubmitTime).Take(3).ToList();
        }

        void RatingService.RemoveAll()
        {
            _ratings.Clear();
            File.Delete(FileName);
        }

        private void SaveRatings()
        {
            using (var fs = File.OpenWrite(FileName))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, _ratings);
            }
        }

        private void LoadRatings()
        {
            if (File.Exists(FileName))
            {
                using (var fs = File.OpenRead(FileName))
                {
                    var bf = new BinaryFormatter();
                    _ratings = (List<Rating>)bf.Deserialize(fs);
                }
            }
        }
    }
}
