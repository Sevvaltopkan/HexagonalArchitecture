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
    public class GetAllTagsHandler : IRequestHandler<GetAllTagsQuery, List<TagResponse>>
    {
        private readonly ITagRepository _repository;

        public GetAllTagsHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TagResponse>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _repository.GetAllAsync();
            return tags.Select(t => new TagResponse
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                CreatedDate = t.CreatedDate
            }).ToList();
        }
    }
}

