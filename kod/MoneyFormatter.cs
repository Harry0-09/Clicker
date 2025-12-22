using System.Globalization;

public static class MoneyFormatter
{
    public static string Format(double value)
    {
        if (value >= 1_000_000_000_000)
            return FormatValue(value / 1_000_000_000_000) + "B";
        if (value >= 1_000_000_000)
            return FormatValue(value / 1_000_000_000) + "mld";
        if (value >= 1_000_000)
            return FormatValue(value / 1_000_000) + "M";
        if (value >= 1_000)
            return FormatValue(value / 1_000) + "k";

        return ((long)value).ToString();
    }

    private static string FormatValue(double value)
    {
        value = System.Math.Round(value, 1);

        if (value % 1 == 0)
            return value.ToString("0", CultureInfo.InvariantCulture);

        return value.ToString("0.0", CultureInfo.InvariantCulture);
    }
}
