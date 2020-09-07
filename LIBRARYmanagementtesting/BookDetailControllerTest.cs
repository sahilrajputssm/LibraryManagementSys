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
    public class BookDetailControllerTest
    {
        LibManContext db;

        [SetUp]
        public void Setup()
        {
            var emp = new List<BookDetail>
            {
                new BookDetail{StudentId=1,BookName="A",BookId=1},
                new BookDetail{StudentId=2,BookName="B",BookId=2},
                new BookDetail{StudentId=3,BookName="C",BookId=3},

            };

            var salData = emp.AsQueryable();
            var mockSet = new Mock<DbSet<BookDetail>>();
            mockSet.As<IQueryable<BookDetail>>().Setup(m => m.Provider).Returns(salData.Provider);
            mockSet.As<IQueryable<BookDetail>>().Setup(m => m.Expression).Returns(salData.Expression);
            mockSet.As<IQueryable<BookDetail>>().Setup(m => m.ElementType).Returns(salData.ElementType);
            mockSet.As<IQueryable<BookDetail>>().Setup(m => m.GetEnumerator()).Returns(salData.GetEnumerator());

            var mockContext = new Mock<LibManContext>();
            mockContext.Setup(c => c.BookDetail).Returns(mockSet.Object);
            db = mockContext.Object;

        }



        [Test]
        public void GetDetailsTest()
        {
            var res = new Mock<BookDetailRep>(db);
            BookDetailController obj = new BookDetailController(res.Object);
            var data = obj.Get();
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }

        [Test]
        public void Add_Valid_Detail()
        {
            var res = new Mock<BookDetailRep>(db);
            BookDetailController obj = new BookDetailController(res.Object);
            BookDetail emp = new BookDetail { StudentId = 1, BookName = "A", BookId = 4 };

            var data = obj.Post(emp);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }





        [Test]
        public void GetDetailTest()
        {
            BookDetailRep res = new BookDetailRep(db);
            BookDetailController obj = new BookDetailController(res);
            var data = obj.Get(1);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void Update_Valid_Detail()
        {
            BookDetailRep res = new BookDetailRep(db);
            BookDetailController obj = new BookDetailController(res);

            BookDetail emp = new BookDetail { StudentId = 1, BookName = "A", BookId = 5 };
            var data = obj.Put(1, emp);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }
        [Test]
        public void Delete_Valid_Detail()
        {
            BookDetailRep res = new BookDetailRep(db);
            BookDetailController obj = new BookDetailController(res);
            var data = obj.Delete(1);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }

    }
}
