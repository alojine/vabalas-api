namespace vabalas_api.Utils;

public static class PercentageHelper
{
    public static decimal GetPercentage(int total, int by)
    {
        if (total == 0)
        {
            throw new ArgumentException($"Divisor {total} cannot be zero.");
        }
        var percentage = ((decimal)by / total) * 100;
        return Math.Round(percentage, 2);
    }
}