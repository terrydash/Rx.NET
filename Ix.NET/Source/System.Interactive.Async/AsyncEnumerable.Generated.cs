// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class AsyncEnumerable
    {
        public static Task<decimal?> Min<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");

            return Min(source, selector, CancellationToken.None);
        }

        public static Task<TResult> Min<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");

            return Min(source, selector, CancellationToken.None);
        }

        public static Task<int> Sum(this IAsyncEnumerable<int> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return Sum(source, CancellationToken.None);
        }

        public static Task<long> Sum(this IAsyncEnumerable<long> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return Sum(source, CancellationToken.None);
        }

        public static Task<double> Sum(this IAsyncEnumerable<double> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return Sum(source, CancellationToken.None);
        }

        public static Task<float> Sum(this IAsyncEnumerable<float> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return Sum(source, CancellationToken.None);
        }

        public static Task<decimal> Sum(this IAsyncEnumerable<decimal> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return Sum(source, CancellationToken.None);
        }

        public static Task<int?> Sum(this IAsyncEnumerable<int?> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return Sum(source, CancellationToken.None);
        }

        public static Task<long?> Sum(this IAsyncEnumerable<long?> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return Sum(source, CancellationToken.None);
        }

        public static Task<double?> Sum(this IAsyncEnumerable<double?> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return Sum(source, CancellationToken.None);
        }

        public static Task<float?> Sum(this IAsyncEnumerable<float?> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return Sum(source, CancellationToken.None);
        }

        public static Task<decimal?> Sum(this IAsyncEnumerable<decimal?> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return Sum(source, CancellationToken.None);
        }

        public static Task<int> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");

            return Sum(source, selector, CancellationToken.None);
        }

        public static Task<long> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");

            return Sum(source, selector, CancellationToken.None);
        }

        public static Task<double> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");

            return Sum(source, selector, CancellationToken.None);
        }

        public static Task<float> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");

            return Sum(source, selector, CancellationToken.None);
        }

        public static Task<decimal> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");

            return Sum(source, selector, CancellationToken.None);
        }

        public static Task<int?> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");

            return Sum(source, selector, CancellationToken.None);
        }

        public static Task<long?> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");

            return Sum(source, selector, CancellationToken.None);
        }

        public static Task<double?> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");

            return Sum(source, selector, CancellationToken.None);
        }

        public static Task<float?> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");

            return Sum(source, selector, CancellationToken.None);
        }

        public static Task<decimal?> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");

            return Sum(source, selector, CancellationToken.None);
        }

        public static void ForEach<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource> action)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (action == null)
                throw new ArgumentNullException("action");

            source.ForEachAsync(action).Wait();
        }

        public static Task ForEachAsync<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource> action)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (action == null)
                throw new ArgumentNullException("action");

            return ForEachAsync(source, action, CancellationToken.None);
        }

        public static void ForEach<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource, int> action)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (action == null)
                throw new ArgumentNullException("action");

            source.ForEachAsync(action).Wait();
        }

        public static Task ForEachAsync<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource, int> action)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (action == null)
                throw new ArgumentNullException("action");

            return ForEachAsync(source, action, CancellationToken.None);
        }


        public static Task<bool> SequenceEqual<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            if (first == null)
                throw new ArgumentNullException("first");
            if (second == null)
                throw new ArgumentNullException("second");
            if (comparer == null)
                throw new ArgumentNullException("comparer");

            return SequenceEqual(first, second, comparer, CancellationToken.None);
        }

        public static Task<bool> SequenceEqual<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
        {
            if (first == null)
                throw new ArgumentNullException("first");
            if (second == null)
                throw new ArgumentNullException("second");

            return SequenceEqual(first, second, CancellationToken.None);
        }




        public static Task<TSource> First<TSource>(this IAsyncEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return First(source, CancellationToken.None);
        }

        public static Task<TSource> First<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return First(source, predicate, CancellationToken.None);
        }

        public static Task<TSource> FirstOrDefault<TSource>(this IAsyncEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return FirstOrDefault(source, CancellationToken.None);
        }

        public static Task<TSource> FirstOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return FirstOrDefault(source, predicate, CancellationToken.None);
        }

        public static Task<TSource> Last<TSource>(this IAsyncEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return Last(source, CancellationToken.None);
        }

        public static Task<TSource> Last<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return Last(source, predicate, CancellationToken.None);
        }

        public static Task<TSource> LastOrDefault<TSource>(this IAsyncEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return LastOrDefault(source, CancellationToken.None);
        }

        public static Task<TSource> LastOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return LastOrDefault(source, predicate, CancellationToken.None);
        }

        public static Task<TSource> Single<TSource>(this IAsyncEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return Single(source, CancellationToken.None);
        }

        public static Task<TSource> Single<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return Single(source, predicate, CancellationToken.None);
        }

        public static Task<TSource> SingleOrDefault<TSource>(this IAsyncEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return SingleOrDefault(source, CancellationToken.None);
        }

        public static Task<TSource> SingleOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return SingleOrDefault(source, predicate, CancellationToken.None);
        }


        public static Task<TSource[]> ToArray<TSource>(this IAsyncEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return ToArray(source, CancellationToken.None);
        }

        public static Task<List<TSource>> ToList<TSource>(this IAsyncEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return ToList(source, CancellationToken.None);
        }

        public static Task<Dictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");
            if (elementSelector == null)
                throw new ArgumentNullException("elementSelector");
            if (comparer == null)
                throw new ArgumentNullException("comparer");

            return ToDictionary(source, keySelector, elementSelector, comparer, CancellationToken.None);
        }

        public static Task<Dictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");
            if (elementSelector == null)
                throw new ArgumentNullException("elementSelector");

            return ToDictionary(source, keySelector, elementSelector, CancellationToken.None);
        }

        public static Task<Dictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");
            if (comparer == null)
                throw new ArgumentNullException("comparer");

            return ToDictionary(source, keySelector, comparer, CancellationToken.None);
        }

        public static Task<Dictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");

            return ToDictionary(source, keySelector, CancellationToken.None);
        }

        public static Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");
            if (elementSelector == null)
                throw new ArgumentNullException("elementSelector");
            if (comparer == null)
                throw new ArgumentNullException("comparer");

            return ToLookup(source, keySelector, elementSelector, comparer, CancellationToken.None);
        }

        public static Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");
            if (elementSelector == null)
                throw new ArgumentNullException("elementSelector");

            return ToLookup(source, keySelector, elementSelector, CancellationToken.None);
        }

        public static Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");
            if (comparer == null)
                throw new ArgumentNullException("comparer");

            return ToLookup(source, keySelector, comparer, CancellationToken.None);
        }

        public static Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");

            return ToLookup(source, keySelector, CancellationToken.None);
        }


        public static Task<bool> IsEmpty<TSource>(this IAsyncEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.IsEmpty(CancellationToken.None);
        }


    }
}
