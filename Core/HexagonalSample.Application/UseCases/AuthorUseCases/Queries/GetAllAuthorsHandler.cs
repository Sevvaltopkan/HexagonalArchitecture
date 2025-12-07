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
    public class GetAllAuthorsHandler : IRequestHandler<GetAllAuthorsQuery, List<AuthorResponse>>
    {
        private readonly IAuthorRepository _repository;

        public GetAllAuthorsHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AuthorResponse>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _repository.GetAllAsync();
            return authors.Select(a => new AuthorResponse
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Biography = a.Biography,
                BirthDate = a.BirthDate,
                CreatedDate = a.CreatedDate
            }).ToList();
        }
    }
}

