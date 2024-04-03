namespace RetroSpec.Application.Models;

public class PaginatedCollection<TItem>(int pageSize, int pageIndex, int totalRecordCount, TItem[] items)
{
    private readonly int totalRecordCount = totalRecordCount;
    private readonly TItem[] items = items;
    public IReadOnlyCollection<TItem> Items => items.AsReadOnly();
    public int PageSize { get; init; } = pageSize;
    public int PageIndex { get; init; } = pageIndex;
    public bool HasPreviousPage => PageIndex > 0;
    public bool HasNextPage => PageIndex < TotalPages;
    public int TotalPages => totalRecordCount / PageSize;
}
