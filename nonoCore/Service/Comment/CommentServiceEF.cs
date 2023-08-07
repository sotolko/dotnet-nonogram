using nonoCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace nonoCore.Service
{
    public class CommentServiceEF : CommentService
    {
        public void AddComment(Comment comment)
        {
            using (var context = new CommentDBContext())
            {
                context.Comments.Add(comment);
                context.SaveChanges();
            }
        }

        public IList<Comment> GetComments()
        {
            using (var context = new CommentDBContext())
            {
                return context.Comments.OrderByDescending(s => s.SubmitTime).ToList();
            }
        }

        public void RemoveAll()
        {
            using (var context = new CommentDBContext())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM Comments");
            }
        }

        public void RemoveThis(int id)
        {
            using (var context = new CommentDBContext())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM Comments WHERE Id={0}",id);
            }
        }
    }
}
