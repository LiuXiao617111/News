using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsExercise.Models
{
    public class Achieve
    {
        private static DataClassesNewsDataContext dbNews = new DataClassesNewsDataContext();
        
        public List<NewsTypes> GetAllNewsType()
        {
            var q = from c in dbNews.NewsTypes
                select c;
            return q.ToList();
        }

        public IEnumerable<News> GetNewsTpyesNews(string newsType)
        {
            //IEnumerable<System.Data.Linq.EntitySet<News>>
            var q = from c in dbNews.NewsTypes
                where c.NewsType == newsType
                select c.News[0];
            return q;
        }

        public News GetNewsDetails(int newsID)
        {
            var q = from c in dbNews.News
                    where c.ID == newsID
                    select c;
            return q.First();
        }

        public IEnumerable<News> GetAllNews()
        {
            var q = from c in dbNews.News
                select c;
            return q;
        }

        public News GetNews(int id)
        {
            var q = from c in dbNews.News
                    where c.ID == id
                    select c;
            return q.First();
        }

        public IEnumerable<Comment> GetNewsComment(int id)
        {
            var q = from c in dbNews.Comment
                    where c.NewsID == id
                    select c;
            return q;
        }

        public bool SaveComment(Comment com)
        {
            try
            {
                dbNews.Comment.InsertOnSubmit(com);
                dbNews.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}