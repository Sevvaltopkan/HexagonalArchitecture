using HexagonalSample.Application.DtoClasses.Books.Commands;
using HexagonalSample.Domain.SecondaryPorts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.BookUseCases.Commands
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly IBookRepository _repository;

        public UpdateBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetByIdAsync(request.Id);
            if (book == null) return false;

            book.Title = request.Title;
            book.ISBN = request.ISBN;
            book.PageCount = request.PageCount;
            book.Price = request.Price;
            book.PublishedDate = request.PublishedDate;
            book.AuthorId = request.AuthorId;
            book.CategoryId = request.CategoryId;
            book.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(book);
            return true;
        }
    }
}

