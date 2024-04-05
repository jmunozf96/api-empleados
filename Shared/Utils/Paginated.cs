﻿namespace Shared.Utils
{
    public class Paginated<T>(List<T> items, int pageIndex, int totalPages)
    {
        public List<T> Items { get; } = items;
        public int PageIndex { get; } = pageIndex;
        public int TotalPages { get; } = totalPages;
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
    }
}
