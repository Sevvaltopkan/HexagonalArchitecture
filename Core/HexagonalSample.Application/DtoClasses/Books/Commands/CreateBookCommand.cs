using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Books.Commands
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }
    }
}

