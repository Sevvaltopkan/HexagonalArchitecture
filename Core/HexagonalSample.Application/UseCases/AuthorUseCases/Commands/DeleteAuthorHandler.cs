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
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand, bool>
    {
        private readonly IAuthorRepository _repository;

        public DeleteAuthorHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetByIdAsync(request.Id);
            if (author == null) return false;

            await _repository.DeleteAsync(request.Id);
            return true;
        }
    }
}

