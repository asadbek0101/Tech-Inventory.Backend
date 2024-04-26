namespace Tech_Inventory.Application.Common.Helpers;

public class PaginationResponse
{
    public int TotalPageCount { get; set; }
    public int TotalRowCount { get; set; }
    public Object? Data { get; set; }
}
