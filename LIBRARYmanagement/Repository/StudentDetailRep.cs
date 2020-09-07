using LIBRARYmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIBRARYmanagement.Repository
{
    public class StudentDetailRep : iStudentDetailRep
    {
        LibManContext db;
        public StudentDetailRep(LibManContext _db)
        {
            db = _db;
        }

        public List<StudentDetail> GetDetails()
        {
            return db.StudentDetail.ToList();
        }

        public StudentDetail GetDetail(int id)
        {
            if (db != null)
            {
                return (db.StudentDetail.Where(x => x.StudentId == id)).FirstOrDefault();
            }
            return null;
        }

        public int AddDetail(StudentDetail emp)
        {
            db.StudentDetail.Add(emp);
            db.SaveChanges();

            return emp.StudentId;
        }



        public int UpdateDetail(int id, StudentDetail emp)
        {
            if (db != null)
            {
                var obj = (db.StudentDetail.Where(x => x.StudentId == id)).FirstOrDefault();
                if (obj != null)
                {
                    
                    obj.LastName = emp.LastName;
                    obj.FirstName = emp.FirstName;
                    obj.Age = emp.Age;
                    db.SaveChanges();
                    return 1;
                }
                return 0;
            }
            return 0;
        }

        public int Delete(int id)
        {
            int result = 0;

            if (db != null)
            {

                var post = db.StudentDetail.FirstOrDefault(x => x.StudentId == id);

                if (post != null)
                {

                    db.StudentDetail.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }

            return result;

        }
    }
}
