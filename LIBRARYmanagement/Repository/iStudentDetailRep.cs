using LIBRARYmanagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIBRARYmanagement.Repository
{
    public interface iStudentDetailRep
    {
        public List<StudentDetail> GetDetails();
        public StudentDetail GetDetail(int id);
        public int AddDetail(StudentDetail emp);
        public int UpdateDetail(int id, StudentDetail emp);
        public int Delete(int id);
    }
}
