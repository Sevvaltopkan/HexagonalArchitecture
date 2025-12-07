using HexagonalSample.Application.DtoClasses.Books.Queries;
using HexagonalSample.Application.DtoClasses.Books.Responses;
using HexagonalSample.Domain.SecondaryPorts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.BookUseCases.Queries
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookResponse>
    {
        private readonly IBookRepository _repository;

        public GetBookByIdHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetByIdAsync(request.Id);
            if (book == null) return null;

            return new BookResponse
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                PageCount = book.PageCount,
                Price = book.Price,
                PublishedDate = book.PublishedDate,
                AuthorId = book.AuthorId,
                AuthorName = book.Author != null ? $"{book.Author.FirstName} {book.Author.LastName}" : null,
                CategoryId = book.CategoryId,
                CategoryName = book.Category?.CategoryName,
                CreatedDate = book.CreatedDate,
                Tags = book.BookTags?.Select(bt => bt.Tag?.Name).Where(n => n != null).ToList() ?? new List<string>()
            };
        }
    }
}

