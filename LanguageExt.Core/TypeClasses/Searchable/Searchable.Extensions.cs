using System.Collections.Generic;
using LanguageExt.TypeClasses;
using System.Diagnostics.Contracts;

namespace LanguageExt
{
    public static partial class TypeClassExtensions
    {

        [Pure]
        public static IEnumerable<V> FindNested<A, BSearchable, B, V>(this Searchable2<A, BSearchable> nestedMap, A aKey, B bKey)
            where BSearchable : Searchable2<B, V>
            =>
            nestedMap.Find2(aKey).Bind(bMap => bMap.Find2(bKey));

        [Pure]
        public static Option<V> ThenFind<Searchable2, K, V>(this Option<Searchable2> outerResult, K innerKey)
            where Searchable2: struct, Searchable2<K, V>
         => outerResult.Bind(searchable => searchable.Find2(innerKey).HeadOrNone());

        //[Pure]
        //public static Option<V> FindNested<A, B, V>(this Searchable<A, Map<B, V>> nestedMap, A aKey, B bKey) =>
        //    nestedMap.Find(aKey).Bind(bMap => bMap.Find(bKey));

        //[Pure]
        //public static Option<V> FindNested<A, OrdB, B, V>(this Searchable<A, Map<OrdB, B, V>> nestedMap, A aKey, B bKey)
        //    where OrdB: struct, Ord<B> =>
        //    nestedMap.Find(aKey).Bind(bMap => bMap.Find(bKey));

        //[Pure]
        //public static Option<V> FindNested<OrdA, A, B, V>(this Map<OrdA, A, Map<B, V>> nestedMap, A aKey, B bKey)
        //    where OrdA: struct, Ord<A> =>
        //    nestedMap.Find(aKey).Bind(bMap => bMap.Find(bKey));
    }
}
