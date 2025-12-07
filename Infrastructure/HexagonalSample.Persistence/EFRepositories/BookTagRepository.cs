using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using HexagonalSample.Persistence.EFData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Persistence.EFRepositories
{
    public class BookTagRepository : IBookTagRepository
    {
        private readonly MyContext _context;

        public BookTagRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<List<BookTag>> GetByBookIdAsync(int bookId)
        {
            return await _context.BookTags
                .Include(bt => bt.Tag)
                .Where(bt => bt.BookId == bookId)
                .ToListAsync();
        }

        public async Task<List<BookTag>> GetByTagIdAsync(int tagId)
        {
            return await _context.BookTags
                .Include(bt => bt.Book)
                .Where(bt => bt.TagId == tagId)
                .ToListAsync();
        }

        public async Task AddTagToBookAsync(int bookId, int tagId)
        {
            var existingBookTag = await _context.BookTags
                .FirstOrDefaultAsync(bt => bt.BookId == bookId && bt.TagId == tagId);

            if (existingBookTag == null)
            {
                var bookTag = new BookTag
                {
                    BookId = bookId,
                    TagId = tagId,
                    CreatedDate = DateTime.Now
                };
                await _context.BookTags.AddAsync(bookTag);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveTagFromBookAsync(int bookId, int tagId)
        {
            var bookTag = await _context.BookTags
                .FirstOrDefaultAsync(bt => bt.BookId == bookId && bt.TagId == tagId);

            if (bookTag != null)
            {
                _context.BookTags.Remove(bookTag);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAllTagsFromBookAsync(int bookId)
        {
            var bookTags = await _context.BookTags
                .Where(bt => bt.BookId == bookId)
                .ToListAsync();

            _context.BookTags.RemoveRange(bookTags);
            await _context.SaveChangesAsync();
        }
    }
}

