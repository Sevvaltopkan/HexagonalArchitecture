using HexagonalSample.Application.DtoClasses.Books.Commands;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.BookUseCases.Commands
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _repository;

        public CreateBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Book book = new()
            {
                Title = request.Title,
                ISBN = request.ISBN,
                PageCount = request.PageCount,
                Price = request.Price,
                PublishedDate = request.PublishedDate,
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId,
                CreatedDate = DateTime.Now
            };

            await _repository.CreateAsync(book);
            return book.Id;
        }
    }
}

