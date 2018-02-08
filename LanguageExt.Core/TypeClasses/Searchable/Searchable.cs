using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using LanguageExt.ClassInstances;

namespace LanguageExt.TypeClasses
{
    public interface SearchResult<out A>
    {
        /// <summary>
        /// Monad bind operation
        /// </summary>
        [Pure]
        Option<B> Bind<B>(Func<A, Option<B>> f);

    }

    public interface Searchable<K, V>
    {
        // when implementing interfaces is possible in C# 8 ? we can add default implementation here for
        // ContainsKey(k), Contains((k,v)) etc.

        [Pure]
        Option<V> Find(K key);
    }

    public interface Searchable2<K, out V>
    {
        // when implementing interfaces is possible in C# 8 ? we can add default implementation here for
        // ContainsKey(k), Contains((k,v)) etc.

        [Pure]
        IEnumerable<V> Find2(K key);
    }
}
