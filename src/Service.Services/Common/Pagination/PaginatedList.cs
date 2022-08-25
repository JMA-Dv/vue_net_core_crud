using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services.Common.Pagination
{
    public class PaginatedList<T> where T: class
    {
        public IEnumerable<T> Items { get; set; }
        public bool HasItems
        {
            get
            {
                return Items != null && Items.Any();
            }
        }

        public int Total { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
    }
}
