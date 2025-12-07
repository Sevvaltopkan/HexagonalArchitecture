using HexagonalSample.Application.DtoClasses.Authors.Commands;
using HexagonalSample.Domain.SecondaryPorts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.AuthorUseCases.Commands
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, bool>
    {
        private readonly IAuthorRepository _repository;

        public UpdateAuthorHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetByIdAsync(request.Id);
            if (author == null) return false;

            author.FirstName = request.FirstName;
            author.LastName = request.LastName;
            author.Biography = request.Biography;
            author.BirthDate = request.BirthDate;
            author.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(author);
            return true;
        }
    }
}

