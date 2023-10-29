namespace vabalas_api.Utils;

public static class PercentageHelper
{
    public static decimal GetPercentage(int unit, int divisor)
    {
        if (divisor == 0)
        {
            throw new ArgumentException($"Divisor {divisor} cannot be zero.");
        }
        return Math.Round(((decimal)unit / divisor) * 100, 2);
    }
}