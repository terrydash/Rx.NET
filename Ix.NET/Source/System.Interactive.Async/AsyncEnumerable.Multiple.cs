// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace System.Linq
{
    public static partial class AsyncEnumerable
    {
        public static IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
        {
            if (first == null)
                throw new ArgumentNullException(nameof(first));
            if (second == null)
                throw new ArgumentNullException(nameof(second));

            return Create(() =>
            {
                var switched = false;
                var e = first.GetEnumerator();

                var cts = new CancellationTokenDisposable();
                var a = new AssignableDisposable { Disposable = e };
                var d = Disposable.Create(cts, a);

                var f = default(Func<CancellationToken, Task<bool>>);
                f = async ct =>
                {
                    if (await e.MoveNext(ct).ConfigureAwait(false))
                    {
                        return true;
                    }
                    if (switched)
                    {
                        return false;
                    }
                    switched = true;

                    e = second.GetEnumerator();
                    a.Disposable = e;

                    return await f(ct).ConfigureAwait(false);
                };

                return Create(
                    f,
                    () => e.Current,
                    d.Dispose,
                    e
                );
            });
        }

        public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> selector)
        {
            if (first == null)
                throw new ArgumentNullException(nameof(first));
            if (second == null)
                throw new ArgumentNullException(nameof(second));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return Create(() =>
            {
                var e1 = first.GetEnumerator();
                var e2 = second.GetEnumerator();
                var current = default(TResult);

                var cts = new CancellationTokenDisposable();
                var d = Disposable.Create(cts, e1, e2);

                return Create(
                    ct => e1.MoveNext(cts.Token).Zip(e2.MoveNext(cts.Token), (f, s) =>
                        {
                            var result = f && s;
                            if (result)
                                current = selector(e1.Current, e2.Current);
                            return result;
                        }),
                    () => current,
                    d.Dispose
                );
            });
        }

       




        public static IAsyncEnumerable<TSource> Union<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            if (first == null)
                throw new ArgumentNullException(nameof(first));
            if (second == null)
                throw new ArgumentNullException(nameof(second));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            return first.Concat(second).Distinct(comparer);
        }

        public static IAsyncEnumerable<TSource> Union<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
        {
            if (first == null)
                throw new ArgumentNullException(nameof(first));
            if (second == null)
                throw new ArgumentNullException(nameof(second));

            return first.Union(second, EqualityComparer<TSource>.Default);
        }

        public static Task<bool> SequenceEqual<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource> comparer, CancellationToken cancellationToken)
        {
            if (first == null)
                throw new ArgumentNullException(nameof(first));
            if (second == null)
                throw new ArgumentNullException(nameof(second));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            return SequenceEqual_(first, second, comparer, cancellationToken);
        }

        private static async Task<bool> SequenceEqual_<TSource>(IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource> comparer,
            CancellationToken cancellationToken)
        {
            using (var e1 = first.GetEnumerator())
            using (var e2 = second.GetEnumerator())
            {
                while (await e1.MoveNext(cancellationToken).ConfigureAwait(false))
                {
                    if (!(await e2.MoveNext(cancellationToken).ConfigureAwait(false) && comparer.Equals(e1.Current, e2.Current)))
                    {
                        return false;
                    }
                }

                return !await e2.MoveNext(cancellationToken).ConfigureAwait(false);
            }
        }

        public static Task<bool> SequenceEqual<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, CancellationToken cancellationToken)
        {
            if (first == null)
                throw new ArgumentNullException(nameof(first));
            if (second == null)
                throw new ArgumentNullException(nameof(second));

            return first.SequenceEqual(second, EqualityComparer<TSource>.Default, cancellationToken);
        }



        public static IAsyncEnumerable<TOther> SelectMany<TSource, TOther>(this IAsyncEnumerable<TSource> source, IAsyncEnumerable<TOther> other)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            return source.SelectMany(_ => other);
        }
    }
}
