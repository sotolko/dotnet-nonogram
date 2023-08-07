using nonoCore.Entity;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System;

namespace nonoCore.Service
{
    public class CommentServiceFile : CommentService
    {
        private const string FileName = "comments.bin";

        private IList<Comment> _comments = new List<Comment>();

        void CommentService.AddComment(Comment comment)
        {
            _comments.Add(comment);
            SaveComments();
        }

        IList<Comment> CommentService.GetComments()
        {
            LoadComments();
            return _comments.OrderByDescending(s => DateTime.Now.Subtract(s.SubmitTime)).Take(3).ToList();
        }

        void CommentService.RemoveAll()
        {
            _comments.Clear();
            File.Delete(FileName);
        }

        private void SaveComments()
        {
            using (var fs = File.OpenWrite(FileName))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, _comments);
            }
        }

        private void LoadComments()
        {
            if (File.Exists(FileName))
            {
                using (var fs = File.OpenRead(FileName))
                {
                    var bf = new BinaryFormatter();
                    _comments = (List<Comment>)bf.Deserialize(fs);
                }
            }
        }
    }
}
