using HexagonalSample.Application.DtoClasses.Authors.Commands;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.AuthorUseCases.Commands
{
    public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly IAuthorRepository _repository;

        public CreateAuthorHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            Author author = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Biography = request.Biography,
                BirthDate = request.BirthDate,
                CreatedDate = DateTime.Now
            };

            await _repository.CreateAsync(author);
            return author.Id;
        }
    }
}

