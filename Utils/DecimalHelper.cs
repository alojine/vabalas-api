namespace vabalas_api.Utils;

public static class DecimalHelper
{
    private static readonly int precision = 2;
    
    public static decimal RoundToTwoDecimals(decimal amount)
    {
        return Math.Round(amount, precision, MidpointRounding.ToEven);
    }
}