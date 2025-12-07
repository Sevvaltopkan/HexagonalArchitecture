using HexagonalSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Domain.SecondaryPorts
{
    public interface IBookTagRepository
    {
        Task<List<BookTag>> GetByBookIdAsync(int bookId);
        Task<List<BookTag>> GetByTagIdAsync(int tagId);
        Task AddTagToBookAsync(int bookId, int tagId);
        Task RemoveTagFromBookAsync(int bookId, int tagId);
        Task RemoveAllTagsFromBookAsync(int bookId);
    }
}

