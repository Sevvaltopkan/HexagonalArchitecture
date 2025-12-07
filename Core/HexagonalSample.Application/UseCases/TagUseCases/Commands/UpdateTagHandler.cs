using HexagonalSample.Application.DtoClasses.Tags.Commands;
using HexagonalSample.Domain.SecondaryPorts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.UseCases.TagUseCases.Commands
{
    public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, bool>
    {
        private readonly ITagRepository _repository;

        public UpdateTagHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _repository.GetByIdAsync(request.Id);
            if (tag == null) return false;

            tag.Name = request.Name;
            tag.Description = request.Description;
            tag.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(tag);
            return true;
        }
    }
}

