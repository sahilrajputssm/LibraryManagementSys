using LIBRARYmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIBRARYmanagement.Repository
{
    public class BookDetailRep : iBookDetailRep
    {

        private readonly LibManContext db;
        public BookDetailRep(LibManContext _db)
        {
            db = _db;
        }
        public int AddDetail(BookDetail obj)
        {
            db.BookDetail.Add(obj);
            db.SaveChanges();

            return (int)obj.StudentId;
        }

        public int Delete(int id)
        {
            int result = 0;

            if (db != null)
            {

                var post = db.BookDetail.FirstOrDefault(x => x.BookId == id);

                if (post != null)
                {

                    db.BookDetail.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }

            return result;
        }

        public BookDetail GetDetail(int id)
        {
            if (db != null)
            {
                return (db.BookDetail.Where(x => x.BookId == id)).FirstOrDefault();
            }
            return null;
        }

        public List<BookDetail> GetDetails()
        {
            return db.BookDetail.ToList();
        }

        public int UpdateDetail(int id, BookDetail obj)
        {
            if (db != null)
            {
                var obj1 = db.BookDetail.Where(x => x.BookId == id).FirstOrDefault();
                if (obj1 != null)
                {

                    obj1.StudentId = obj.StudentId;
                    obj1.BookName = obj.BookName;
                   

                    db.SaveChanges();
                    return 1;
                }
                return 0;

            }

            return 0;
        }
    }
}
