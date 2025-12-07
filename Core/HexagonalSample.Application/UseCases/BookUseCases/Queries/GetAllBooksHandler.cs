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
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<BookResponse>>
    {
        private readonly IBookRepository _repository;

        public GetAllBooksHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BookResponse>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAllAsync();
            return books.Select(b => new BookResponse
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                PageCount = b.PageCount,
                Price = b.Price,
                PublishedDate = b.PublishedDate,
                AuthorId = b.AuthorId,
                AuthorName = b.Author != null ? $"{b.Author.FirstName} {b.Author.LastName}" : null,
                CategoryId = b.CategoryId,
                CategoryName = b.Category?.CategoryName,
                CreatedDate = b.CreatedDate,
                Tags = b.BookTags?.Select(bt => bt.Tag?.Name).Where(n => n != null).ToList() ?? new List<string>()
            }).ToList();
        }
    }
}

