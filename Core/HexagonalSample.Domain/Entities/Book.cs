using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }

        //Relational Properties
        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<BookTag> BookTags { get; set; }
    }
}

