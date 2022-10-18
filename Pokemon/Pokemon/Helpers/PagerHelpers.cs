namespace Pokemon.Helpers;


public static class PagerHelpers
{
    public static int GetCurrentPage(string currentPage)
    {
        const int defaultPage = 1;

        if (string.IsNullOrEmpty(currentPage))
        {
            return defaultPage;
        }

        if (int.TryParse(currentPage, out int page))
        {
            if (page <= 0)
            {
                return defaultPage;
            }
            return page;
        }

        return defaultPage;
    }

    public static int GetTotalPages(int count, int pageSize)
    {
        double totalPages = Math.Ceiling((double)count / pageSize);

        return (int)totalPages;
    }

    public static int GetMinPage(int currentPage, int maxPages)
    {
        if ((currentPage % maxPages) == 0) { return currentPage - (maxPages - 1); }

        int minPage = currentPage % maxPages;
        return currentPage - minPage + 1;
    }

    public static int GetMaxPage(int currentPage, int maxPages, int totalPages)
    {
        if ((currentPage % maxPages) == 0) { return currentPage; }

        int maxPage = currentPage + (maxPages - (currentPage % maxPages));

        if (maxPage > totalPages)
        {
            return totalPages;
        }
        return maxPage;
    }
}
