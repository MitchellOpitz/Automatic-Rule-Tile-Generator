using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System;

public static class NaturalSortingExtension
{
    public static IOrderedEnumerable<T> OrderByNatural<T>(this IEnumerable<T> source, Func<T, string> selector)
    {
        int maxLen = source.Select(selector).Select(s => s.Length).Max();
        return source.OrderBy(s => NaturalSortingExtension.NaturalString(selector(s), maxLen));
    }

    private static string NaturalString(string str, int maxLen)
    {
        return string.Join("\0", Regex.Split(str, "([0-9]+)").Select(s => s.PadLeft(maxLen, '0')));
    }
}