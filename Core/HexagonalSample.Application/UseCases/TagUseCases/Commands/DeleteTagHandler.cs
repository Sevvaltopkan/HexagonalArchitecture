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
    public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, bool>
    {
        private readonly ITagRepository _repository;

        public DeleteTagHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _repository.GetByIdAsync(request.Id);
            if (tag == null) return false;

            await _repository.DeleteAsync(request.Id);
            return true;
        }
    }
}

