using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LIBRARYmanagement.Models;

namespace LIBRARYmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetailsController : ControllerBase
    {
        public readonly LibManContext _context;
        readonly log4net.ILog _log4net;

        public BookDetailsController(LibManContext context)
        {
            _context = context;
            _log4net = log4net.LogManager.GetLogger(typeof(BookDetailsController));
        }

        // GET: api/BookDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDetail>>> GetBookDetail()
        {
            return await _context.BookDetail.ToListAsync();
        }

        // GET: api/BookDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetail>> GetBookDetail(int id)
        {
            var bookDetail = await _context.BookDetail.FindAsync(id);

            if (bookDetail == null)
            {
                return NotFound();
            }

            return bookDetail;
        }

        // PUT: api/BookDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookDetail(int id, BookDetail bookDetail)
        {
            if (id != bookDetail.BookId)
            {
                return BadRequest();
            }

            _context.Entry(bookDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookDetail>> PostBookDetail(BookDetail bookDetail)
        {
            _context.BookDetail.Add(bookDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookDetailExists(bookDetail.BookId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookDetail", new { id = bookDetail.BookId }, bookDetail);
        }

        // DELETE: api/BookDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookDetail>> DeleteBookDetail(int id)
        {
            var bookDetail = await _context.BookDetail.FindAsync(id);
            if (bookDetail == null)
            {
                return NotFound();
            }

            _context.BookDetail.Remove(bookDetail);
            await _context.SaveChangesAsync();

            return bookDetail;
        }

        private bool BookDetailExists(int id)
        {
            return _context.BookDetail.Any(e => e.BookId == id);
        }
    }
}
