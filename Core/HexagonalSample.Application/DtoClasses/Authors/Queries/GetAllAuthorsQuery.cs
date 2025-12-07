using HexagonalSample.Application.DtoClasses.Authors.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Authors.Queries
{
    public class GetAllAuthorsQuery : IRequest<List<AuthorResponse>>
    {
    }
}

