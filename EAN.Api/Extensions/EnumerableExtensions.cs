namespace EAN.Api.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int groups)
        {
            return source.Select((x, i) => new { Index = i, Value = x }).GroupBy(x => x.Index / groups).Select(x => x.Select(v => v.Value).ToList()).ToList();
        }
    }
}
