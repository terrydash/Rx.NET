﻿// // Licensed to the .NET Foundation under one or more agreements.
// // The .NET Foundation licenses this file to you under the Apache 2.0 License.
// // See the LICENSE file in the project root for more information. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class AsyncEnumerable
    {
        public static IAsyncEnumerable<TSource> AsAsyncEnumerable<TSource>(this IAsyncEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Select(x => x);
        }

        public static IAsyncEnumerable<TValue> Empty<TValue>()
        {
            return Create(() => Create<TValue>(
                              ct => TaskExt.False,
                              () => { throw new InvalidOperationException(); },
                              () => { })
            );
        }
    }
}