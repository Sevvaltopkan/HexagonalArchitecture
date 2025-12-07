using HexagonalSample.Application.DtoClasses.Tags.Queries;
using HexagonalSample.Application.DtoClasses.Tags.Responses;
using HexagonalSample.Domain.SecondaryPorts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.TagUseCases.Queries
{
    public class GetTagByIdHandler : IRequestHandler<GetTagByIdQuery, TagResponse>
    {
        private readonly ITagRepository _repository;

        public GetTagByIdHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<TagResponse> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var tag = await _repository.GetByIdAsync(request.Id);
            if (tag == null) return null;

            return new TagResponse
            {
                Id = tag.Id,
                Name = tag.Name,
                Description = tag.Description,
                CreatedDate = tag.CreatedDate
            };
        }
    }
}

