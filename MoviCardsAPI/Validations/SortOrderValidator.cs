namespace MovieCardsAPI.Validations
{
    public static class SortOrderValidator
    {
        public static bool IsValidSortOrder(string? sortOrder)
        {
            return string.IsNullOrWhiteSpace(sortOrder) ||
                   sortOrder.Equals("asc", StringComparison.OrdinalIgnoreCase) ||
                   sortOrder.Equals("desc", StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsValidSortBy(string? sortBy)
        {
            if (string.IsNullOrWhiteSpace(sortBy))
                return true;

            var validSortFields = new[] { "title", "rating", "releasedate" };
            var fields = sortBy.Split(',', StringSplitOptions.RemoveEmptyEntries);
            return fields.All(f => validSortFields.Contains(f.Trim().ToLower()));
        }
    }
}
