using System.ComponentModel.DataAnnotations;

namespace MiniStore.IdentityServer.Contracts.Pagination;

public class RequestPagination
{
    public int Page { get; set; }

    public int PageSize { get; set; } = 50;

    [EnumDataType(typeof(SortableField))]
    public SortableField SortBy { get; set; }

    [EnumDataType(typeof(SortOrder))]
    public SortOrder SortOrder { get; set; }
}