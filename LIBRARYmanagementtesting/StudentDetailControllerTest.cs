using LIBRARYmanagement.Controllers;
using LIBRARYmanagement.Models;
using LIBRARYmanagement.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LIBRARYmanagementtesting
{
    public class StudentDetailControllerTest
    {
        LibManContext db;

        [SetUp]
        public void Setup()
        {
            var emp = new List<StudentDetail>
            {
                new StudentDetail{StudentId=1,LastName="Dummy 1",FirstName="DD",Age=30},
                new StudentDetail{StudentId=2,LastName="Dummy 2",FirstName="DD",Age=31},
                new StudentDetail{StudentId=3,LastName="Dummy 3",FirstName="DD",Age=32}

            };

            var empdata = emp.AsQueryable();
            var mockSet = new Mock<DbSet<StudentDetail>>();
            mockSet.As<IQueryable<StudentDetail>>().Setup(m => m.Provider).Returns(empdata.Provider);
            mockSet.As<IQueryable<StudentDetail>>().Setup(m => m.Expression).Returns(empdata.Expression);
            mockSet.As<IQueryable<StudentDetail>>().Setup(m => m.ElementType).Returns(empdata.ElementType);
            mockSet.As<IQueryable<StudentDetail>>().Setup(m => m.GetEnumerator()).Returns(empdata.GetEnumerator());

            var mockContext = new Mock<LibManContext>();
            mockContext.Setup(c => c.StudentDetail).Returns(mockSet.Object);
            db = mockContext.Object;

        }



        [Test]
        public void GetDetailsTest()
        {
            var res = new Mock<StudentDetailRep>(db);
            StudentDetailController obj = new StudentDetailController(res.Object);
            var data = obj.Get();
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }

        [Test]
        public void Add_Valid_Detail()
        {
            var res = new Mock<StudentDetailRep>(db);
            StudentDetailController obj = new StudentDetailController(res.Object);
            StudentDetail emp = new StudentDetail { StudentId = 4, LastName = "Dummy 1", FirstName = "DD", Age = 34 };

            var data = obj.Post(emp);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }





        [Test]
        public void GetDetailTest()
        {
            StudentDetailRep res = new StudentDetailRep(db);
            StudentDetailController obj = new StudentDetailController(res);
            var data = obj.Get1(1);
            var okResult = data as ObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }



        [Test]
        public void Update_Valid_Detail()
        {

            StudentDetail emp = new StudentDetail { LastName = "Dummy 1", FirstName = "DD", Age = 30 };
            StudentDetailRep res = new StudentDetailRep(db);
            StudentDetailController obj = new StudentDetailController(res);
            var data = obj.Put(1, emp);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }
        [Test]
        public void Delete_Valid_Detail()
        {
            StudentDetailRep loandata = new StudentDetailRep(db);
            StudentDetailController obj = new StudentDetailController(loandata);
            var data = obj.Delete(1);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }

    }
}
