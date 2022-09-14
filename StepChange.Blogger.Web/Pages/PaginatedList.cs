using System;
using System.Collections.Generic;
using System.Linq;

namespace StepChange.Blogger.Web.Pages
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; }
        public int TotalPages { get; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public static PaginatedList<T> Create(
            IEnumerable<T> source,
            int pageIndex,
            int pageSize)
        {
            var list = source.ToList();
            var count = list.Count;
            var items = list.Skip(
                    (pageIndex - 1) * pageSize)
                .Take(pageSize).ToList();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
