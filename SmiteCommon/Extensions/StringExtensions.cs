
namespace SmiteCommon.Extensions;

public static class StringExtensions
{
    public static string Join(this string[] strings, string separator) => string.Join(separator, strings);
    public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);
}
