using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Paging
{
    public class PaginatedList<T>
    {
        public IEnumerable<T> Items { get; set; } = [];
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } 
        public int TotalCount { get; set; } 
        public decimal PageCount => Math.Ceiling((int)TotalCount / (decimal)PageSize);
    }
}
