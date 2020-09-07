using LIBRARYmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIBRARYmanagement.Repository
{
    public interface iBookDetailRep
    {
        public List<BookDetail> GetDetails();
        public BookDetail GetDetail(int id);
        public int AddDetail(BookDetail obj);
        public int UpdateDetail(int id, BookDetail obj);
        public int Delete(int id);
    }
}
