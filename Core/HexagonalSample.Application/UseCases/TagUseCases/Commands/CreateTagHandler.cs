using HexagonalSample.Application.DtoClasses.Tags.Commands;
using HexagonalSample.Domain.Entities;
using HexagonalSample.Domain.SecondaryPorts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.TagUseCases.Commands
{
    public class CreateTagHandler : IRequestHandler<CreateTagCommand, int>
    {
        private readonly ITagRepository _repository;

        public CreateTagHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            Tag tag = new()
            {
                Name = request.Name,
                Description = request.Description,
                CreatedDate = DateTime.Now
            };

            await _repository.CreateAsync(tag);
            return tag.Id;
        }
    }
}

