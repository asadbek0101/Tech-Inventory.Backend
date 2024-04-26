using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Common.Helpers;

public class Paginator : IPaginator
{
    public int Offset(int pageNumber, int pageSize)
    {
        return (pageNumber - 1) * pageSize;
    }

    public int GetTotalPageCount(int pageSize, int totalRowCount)
    {
        var totalPageCount = totalRowCount % pageSize == 0 ? totalRowCount / pageSize : totalRowCount / pageSize + 1;
        return totalPageCount;
    }
}
