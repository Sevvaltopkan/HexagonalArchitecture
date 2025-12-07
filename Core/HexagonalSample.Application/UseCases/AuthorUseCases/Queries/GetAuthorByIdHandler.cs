using HexagonalSample.Application.DtoClasses.Authors.Queries;
using HexagonalSample.Application.DtoClasses.Authors.Responses;
using HexagonalSample.Domain.SecondaryPorts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.AuthorUseCases.Queries
{
    public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdQuery, AuthorResponse>
    {
        private readonly IAuthorRepository _repository;

        public GetAuthorByIdHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<AuthorResponse> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetByIdAsync(request.Id);
            if (author == null) return null;

            return new AuthorResponse
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Biography = author.Biography,
                BirthDate = author.BirthDate,
                CreatedDate = author.CreatedDate
            };
        }
    }
}

