using nonoCore.Entity;
using System.Collections.Generic;

namespace nonoCore.Service
{
    public interface CommentService
    {
        void AddComment(Comment comment);

        IList<Comment> GetComments();

        void RemoveAll();
    }
}
