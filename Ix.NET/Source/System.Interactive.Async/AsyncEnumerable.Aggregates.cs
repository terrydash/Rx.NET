// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace System.Linq
{
    public static partial class AsyncEnumerable
    {




        public static Task<TSource> Single<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return Single_(source, cancellationToken);
        }

        private static async Task<TSource> Single_<TSource>(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            using (var e = source.GetEnumerator())
            {
                if (!await e.MoveNext(cancellationToken).ConfigureAwait(false))
                {
                    throw new InvalidOperationException(Strings.NO_ELEMENTS);
                }
                var result = e.Current;
                if (await e.MoveNext(cancellationToken).ConfigureAwait(false))
                {
                    throw new InvalidOperationException(Strings.MORE_THAN_ONE_ELEMENT);
                }
                return result;
            }
        }

        public static Task<TSource> Single<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return source.Where(predicate).Single(cancellationToken);
        }

        public static Task<TSource> SingleOrDefault<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return SingleOrDefault_(source, cancellationToken);
        }

        private static async Task<TSource> SingleOrDefault_<TSource>(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            using (var e = source.GetEnumerator())
            {
                if (!await e.MoveNext(cancellationToken).ConfigureAwait(false))
                {
                    return default(TSource);
                }

                var result = e.Current;
                if (!await e.MoveNext(cancellationToken).ConfigureAwait(false))
                {
                    return result;
                }
            }
            throw new InvalidOperationException(Strings.MORE_THAN_ONE_ELEMENT);
        }

        public static Task<TSource> SingleOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return source.Where(predicate).SingleOrDefault(cancellationToken);
        }

        public static Task<TSource[]> ToArray<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Aggregate(new List<TSource>(), (list, x) => { list.Add(x); return list; }, list => list.ToArray(), cancellationToken);
        }

        public static Task<List<TSource>> ToList<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Aggregate(new List<TSource>(), (list, x) => { list.Add(x); return list; }, cancellationToken);
        }

        public static Task<Dictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null)
                throw new ArgumentNullException(nameof(elementSelector));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            return source.Aggregate(new Dictionary<TKey, TElement>(comparer), (d, x) => { d.Add(keySelector(x), elementSelector(x)); return d; }, cancellationToken);
        }

        public static Task<Dictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null)
                throw new ArgumentNullException(nameof(elementSelector));

            return source.ToDictionary(keySelector, elementSelector, EqualityComparer<TKey>.Default, cancellationToken);
        }

        public static Task<Dictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            return source.ToDictionary(keySelector, x => x, comparer, cancellationToken);
        }

        public static Task<Dictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));

            return source.ToDictionary(keySelector, x => x, EqualityComparer<TKey>.Default, cancellationToken);
        }

        public static async Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null)
                throw new ArgumentNullException(nameof(elementSelector));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            var lookup = await Internal.Lookup<TKey, TElement>.CreateAsync(source, keySelector, elementSelector, comparer, cancellationToken).ConfigureAwait(false);

            return lookup;
        }

        public static Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null)
                throw new ArgumentNullException(nameof(elementSelector));

            return source.ToLookup(keySelector, elementSelector, EqualityComparer<TKey>.Default, cancellationToken);
        }

        public static Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            return source.ToLookup(keySelector, x => x, comparer, cancellationToken);
        }

        public static Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));

            return source.ToLookup(keySelector, x => x, EqualityComparer<TKey>.Default, cancellationToken);
        }

        public static Task<int> Sum(this IAsyncEnumerable<int> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Aggregate(0, (x, y) => x + y, cancellationToken);
        }

        public static Task<long> Sum(this IAsyncEnumerable<long> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Aggregate(0L, (x, y) => x + y, cancellationToken);
        }

        public static Task<double> Sum(this IAsyncEnumerable<double> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Aggregate(0.0, (x, y) => x + y, cancellationToken);
        }

        public static Task<float> Sum(this IAsyncEnumerable<float> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Aggregate(0f, (x, y) => x + y, cancellationToken);
        }

        public static Task<decimal> Sum(this IAsyncEnumerable<decimal> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Aggregate(0m, (x, y) => x + y, cancellationToken);
        }

        public static Task<int?> Sum(this IAsyncEnumerable<int?> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Aggregate((int?)0, (x, y) => x + y.GetValueOrDefault(), cancellationToken);
        }

        public static Task<long?> Sum(this IAsyncEnumerable<long?> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Aggregate((long?)0, (x, y) => x + y.GetValueOrDefault(), cancellationToken);
        }

        public static Task<double?> Sum(this IAsyncEnumerable<double?> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Aggregate((double?)0, (x, y) => x + y.GetValueOrDefault(), cancellationToken);
        }

        public static Task<float?> Sum(this IAsyncEnumerable<float?> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Aggregate((float?)0, (x, y) => x + y.GetValueOrDefault(), cancellationToken);
        }

        public static Task<decimal?> Sum(this IAsyncEnumerable<decimal?> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Aggregate((decimal?)0, (x, y) => x + y.GetValueOrDefault(), cancellationToken);
        }

        public static Task<int> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).Sum(cancellationToken);
        }

        public static Task<long> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).Sum(cancellationToken);
        }

        public static Task<double> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).Sum(cancellationToken);
        }

        public static Task<float> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).Sum(cancellationToken);
        }

        public static Task<decimal> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).Sum(cancellationToken);
        }

        public static Task<int?> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int?> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).Sum(cancellationToken);
        }

        public static Task<long?> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long?> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).Sum(cancellationToken);
        }

        public static Task<double?> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double?> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).Sum(cancellationToken);
        }

        public static Task<float?> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float?> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).Sum(cancellationToken);
        }

        public static Task<decimal?> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal?> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.Select(selector).Sum(cancellationToken);
        }

        public static Task<bool> IsEmpty<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return IsEmpty_(source, cancellationToken);
        }

        private static async Task<bool> IsEmpty_<TSource>(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            return !await source.Any(cancellationToken).ConfigureAwait(false);
        }


        private static async Task<IList<TSource>> ExtremaBy<TSource, TKey>(IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TKey, int> compare, CancellationToken cancellationToken)
        {
            var result = new List<TSource>();

            using (var e = source.GetEnumerator())
            {
                if (!await e.MoveNext(cancellationToken).ConfigureAwait(false))
                    throw new InvalidOperationException(Strings.NO_ELEMENTS);

                var current = e.Current;
                var resKey = keySelector(current);
                result.Add(current);

                while (await e.MoveNext(cancellationToken).ConfigureAwait(false))
                {
                    var cur = e.Current;
                    var key = keySelector(cur);

                    var cmp = compare(key, resKey);
                    if (cmp == 0)
                    {
                        result.Add(cur);
                    }
                    else if (cmp > 0)
                    {
                        result = new List<TSource> { cur };
                        resKey = key;
                    }
                }
            }

            return result;
        }
    }
}
