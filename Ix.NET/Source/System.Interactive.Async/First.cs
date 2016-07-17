using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class AsyncEnumerable
    {

        public static Task<TSource> First<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return First_(source, cancellationToken);
        }

        private static async Task<TSource> First_<TSource>(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            using (var e = source.GetEnumerator())
            {
                if (await e.MoveNext(cancellationToken).ConfigureAwait(false))
                {
                    return e.Current;
                }
            }
            throw new InvalidOperationException(Strings.NO_ELEMENTS);
        }

        public static Task<TSource> First<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return source.Where(predicate).First(cancellationToken);
        }

        public static Task<TSource> FirstOrDefault<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return FirstOrDefault_(source, cancellationToken);
        }

        private static async Task<TSource> FirstOrDefault_<TSource>(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            using (var e = source.GetEnumerator())
            {
                if (await e.MoveNext(cancellationToken).ConfigureAwait(false))
                {
                    return e.Current;
                }
            }
            return default(TSource);
        }

        public static Task<TSource> FirstOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return source.Where(predicate).FirstOrDefault(cancellationToken);
        }
    }
}
