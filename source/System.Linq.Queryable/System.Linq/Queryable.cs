using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace System.Linq;

public static class Queryable
{
	[RequiresUnreferencedCode("Enumerating in-memory collections as IQueryable can require unreferenced code because expressions referencing IQueryable extension methods can get rebound to IEnumerable extension methods. The IEnumerable extension methods could be trimmed causing the application to fail at runtime.")]
	public static IQueryable<TElement> AsQueryable<TElement>(this IEnumerable<TElement> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return (source as IQueryable<TElement>) ?? new EnumerableQuery<TElement>(source);
	}

	[RequiresUnreferencedCode("Enumerating in-memory collections as IQueryable can require unreferenced code because expressions referencing IQueryable extension methods can get rebound to IEnumerable extension methods. The IEnumerable extension methods could be trimmed causing the application to fail at runtime.")]
	public static IQueryable AsQueryable(this IEnumerable source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (source is IQueryable result)
		{
			return result;
		}
		Type type = TypeHelper.FindGenericType(typeof(IEnumerable<>), source.GetType());
		if (type == null)
		{
			throw Error.ArgumentNotIEnumerableGeneric("source");
		}
		return EnumerableQuery.Create(type.GenericTypeArguments[0], source);
	}

	[DynamicDependency("Where`1", typeof(Enumerable))]
	public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.Where_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(predicate)));
	}

	[DynamicDependency("Where`1", typeof(Enumerable))]
	public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, int, bool>> predicate)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.Where_Index_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(predicate)));
	}

	[DynamicDependency("OfType`1", typeof(Enumerable))]
	public static IQueryable<TResult> OfType<TResult>(this IQueryable source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.CreateQuery<TResult>(Expression.Call(null, CachedReflectionInfo.OfType_TResult_1(typeof(TResult)), source.Expression));
	}

	[DynamicDependency("Cast`1", typeof(Enumerable))]
	public static IQueryable<TResult> Cast<TResult>(this IQueryable source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.CreateQuery<TResult>(Expression.Call(null, CachedReflectionInfo.Cast_TResult_1(typeof(TResult)), source.Expression));
	}

	[DynamicDependency("Select`2", typeof(Enumerable))]
	public static IQueryable<TResult> Select<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.CreateQuery<TResult>(Expression.Call(null, CachedReflectionInfo.Select_TSource_TResult_2(typeof(TSource), typeof(TResult)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Select`2", typeof(Enumerable))]
	public static IQueryable<TResult> Select<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, int, TResult>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.CreateQuery<TResult>(Expression.Call(null, CachedReflectionInfo.Select_Index_TSource_TResult_2(typeof(TSource), typeof(TResult)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("SelectMany`2", typeof(Enumerable))]
	public static IQueryable<TResult> SelectMany<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, IEnumerable<TResult>>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.CreateQuery<TResult>(Expression.Call(null, CachedReflectionInfo.SelectMany_TSource_TResult_2(typeof(TSource), typeof(TResult)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("SelectMany`2", typeof(Enumerable))]
	public static IQueryable<TResult> SelectMany<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, int, IEnumerable<TResult>>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.CreateQuery<TResult>(Expression.Call(null, CachedReflectionInfo.SelectMany_Index_TSource_TResult_2(typeof(TSource), typeof(TResult)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("SelectMany`3", typeof(Enumerable))]
	public static IQueryable<TResult> SelectMany<TSource, TCollection, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, int, IEnumerable<TCollection>>> collectionSelector, Expression<Func<TSource, TCollection, TResult>> resultSelector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (collectionSelector == null)
		{
			throw Error.ArgumentNull("collectionSelector");
		}
		if (resultSelector == null)
		{
			throw Error.ArgumentNull("resultSelector");
		}
		return source.Provider.CreateQuery<TResult>(Expression.Call(null, CachedReflectionInfo.SelectMany_Index_TSource_TCollection_TResult_3(typeof(TSource), typeof(TCollection), typeof(TResult)), source.Expression, Expression.Quote(collectionSelector), Expression.Quote(resultSelector)));
	}

	[DynamicDependency("SelectMany`3", typeof(Enumerable))]
	public static IQueryable<TResult> SelectMany<TSource, TCollection, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, IEnumerable<TCollection>>> collectionSelector, Expression<Func<TSource, TCollection, TResult>> resultSelector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (collectionSelector == null)
		{
			throw Error.ArgumentNull("collectionSelector");
		}
		if (resultSelector == null)
		{
			throw Error.ArgumentNull("resultSelector");
		}
		return source.Provider.CreateQuery<TResult>(Expression.Call(null, CachedReflectionInfo.SelectMany_TSource_TCollection_TResult_3(typeof(TSource), typeof(TCollection), typeof(TResult)), source.Expression, Expression.Quote(collectionSelector), Expression.Quote(resultSelector)));
	}

	private static Expression GetSourceExpression<TSource>(IEnumerable<TSource> source)
	{
		if (!(source is IQueryable<TSource> queryable))
		{
			return Expression.Constant(source, typeof(IEnumerable<TSource>));
		}
		return queryable.Expression;
	}

	[DynamicDependency("Join`4", typeof(Enumerable))]
	public static IQueryable<TResult> Join<TOuter, TInner, TKey, TResult>(this IQueryable<TOuter> outer, IEnumerable<TInner> inner, Expression<Func<TOuter, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<TOuter, TInner, TResult>> resultSelector)
	{
		if (outer == null)
		{
			throw Error.ArgumentNull("outer");
		}
		if (inner == null)
		{
			throw Error.ArgumentNull("inner");
		}
		if (outerKeySelector == null)
		{
			throw Error.ArgumentNull("outerKeySelector");
		}
		if (innerKeySelector == null)
		{
			throw Error.ArgumentNull("innerKeySelector");
		}
		if (resultSelector == null)
		{
			throw Error.ArgumentNull("resultSelector");
		}
		return outer.Provider.CreateQuery<TResult>(Expression.Call(null, CachedReflectionInfo.Join_TOuter_TInner_TKey_TResult_5(typeof(TOuter), typeof(TInner), typeof(TKey), typeof(TResult)), outer.Expression, GetSourceExpression(inner), Expression.Quote(outerKeySelector), Expression.Quote(innerKeySelector), Expression.Quote(resultSelector)));
	}

	[DynamicDependency("Join`4", typeof(Enumerable))]
	public static IQueryable<TResult> Join<TOuter, TInner, TKey, TResult>(this IQueryable<TOuter> outer, IEnumerable<TInner> inner, Expression<Func<TOuter, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<TOuter, TInner, TResult>> resultSelector, IEqualityComparer<TKey>? comparer)
	{
		if (outer == null)
		{
			throw Error.ArgumentNull("outer");
		}
		if (inner == null)
		{
			throw Error.ArgumentNull("inner");
		}
		if (outerKeySelector == null)
		{
			throw Error.ArgumentNull("outerKeySelector");
		}
		if (innerKeySelector == null)
		{
			throw Error.ArgumentNull("innerKeySelector");
		}
		if (resultSelector == null)
		{
			throw Error.ArgumentNull("resultSelector");
		}
		return outer.Provider.CreateQuery<TResult>(Expression.Call(null, CachedReflectionInfo.Join_TOuter_TInner_TKey_TResult_6(typeof(TOuter), typeof(TInner), typeof(TKey), typeof(TResult)), outer.Expression, GetSourceExpression(inner), Expression.Quote(outerKeySelector), Expression.Quote(innerKeySelector), Expression.Quote(resultSelector), Expression.Constant(comparer, typeof(IEqualityComparer<TKey>))));
	}

	[DynamicDependency("GroupJoin`4", typeof(Enumerable))]
	public static IQueryable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IQueryable<TOuter> outer, IEnumerable<TInner> inner, Expression<Func<TOuter, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<TOuter, IEnumerable<TInner>, TResult>> resultSelector)
	{
		if (outer == null)
		{
			throw Error.ArgumentNull("outer");
		}
		if (inner == null)
		{
			throw Error.ArgumentNull("inner");
		}
		if (outerKeySelector == null)
		{
			throw Error.ArgumentNull("outerKeySelector");
		}
		if (innerKeySelector == null)
		{
			throw Error.ArgumentNull("innerKeySelector");
		}
		if (resultSelector == null)
		{
			throw Error.ArgumentNull("resultSelector");
		}
		return outer.Provider.CreateQuery<TResult>(Expression.Call(null, CachedReflectionInfo.GroupJoin_TOuter_TInner_TKey_TResult_5(typeof(TOuter), typeof(TInner), typeof(TKey), typeof(TResult)), outer.Expression, GetSourceExpression(inner), Expression.Quote(outerKeySelector), Expression.Quote(innerKeySelector), Expression.Quote(resultSelector)));
	}

	[DynamicDependency("GroupJoin`4", typeof(Enumerable))]
	public static IQueryable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IQueryable<TOuter> outer, IEnumerable<TInner> inner, Expression<Func<TOuter, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<TOuter, IEnumerable<TInner>, TResult>> resultSelector, IEqualityComparer<TKey>? comparer)
	{
		if (outer == null)
		{
			throw Error.ArgumentNull("outer");
		}
		if (inner == null)
		{
			throw Error.ArgumentNull("inner");
		}
		if (outerKeySelector == null)
		{
			throw Error.ArgumentNull("outerKeySelector");
		}
		if (innerKeySelector == null)
		{
			throw Error.ArgumentNull("innerKeySelector");
		}
		if (resultSelector == null)
		{
			throw Error.ArgumentNull("resultSelector");
		}
		return outer.Provider.CreateQuery<TResult>(Expression.Call(null, CachedReflectionInfo.GroupJoin_TOuter_TInner_TKey_TResult_6(typeof(TOuter), typeof(TInner), typeof(TKey), typeof(TResult)), outer.Expression, GetSourceExpression(inner), Expression.Quote(outerKeySelector), Expression.Quote(innerKeySelector), Expression.Quote(resultSelector), Expression.Constant(comparer, typeof(IEqualityComparer<TKey>))));
	}

	[DynamicDependency("OrderBy`2", typeof(Enumerable))]
	public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return (IOrderedQueryable<TSource>)source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.OrderBy_TSource_TKey_2(typeof(TSource), typeof(TKey)), source.Expression, Expression.Quote(keySelector)));
	}

	[DynamicDependency("OrderBy`2", typeof(Enumerable))]
	public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, IComparer<TKey>? comparer)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return (IOrderedQueryable<TSource>)source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.OrderBy_TSource_TKey_3(typeof(TSource), typeof(TKey)), source.Expression, Expression.Quote(keySelector), Expression.Constant(comparer, typeof(IComparer<TKey>))));
	}

	[DynamicDependency("OrderByDescending`2", typeof(Enumerable))]
	public static IOrderedQueryable<TSource> OrderByDescending<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return (IOrderedQueryable<TSource>)source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.OrderByDescending_TSource_TKey_2(typeof(TSource), typeof(TKey)), source.Expression, Expression.Quote(keySelector)));
	}

	[DynamicDependency("OrderByDescending`2", typeof(Enumerable))]
	public static IOrderedQueryable<TSource> OrderByDescending<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, IComparer<TKey>? comparer)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return (IOrderedQueryable<TSource>)source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.OrderByDescending_TSource_TKey_3(typeof(TSource), typeof(TKey)), source.Expression, Expression.Quote(keySelector), Expression.Constant(comparer, typeof(IComparer<TKey>))));
	}

	[DynamicDependency("ThenBy`2", typeof(Enumerable))]
	public static IOrderedQueryable<TSource> ThenBy<TSource, TKey>(this IOrderedQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return (IOrderedQueryable<TSource>)source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.ThenBy_TSource_TKey_2(typeof(TSource), typeof(TKey)), source.Expression, Expression.Quote(keySelector)));
	}

	[DynamicDependency("ThenBy`2", typeof(Enumerable))]
	public static IOrderedQueryable<TSource> ThenBy<TSource, TKey>(this IOrderedQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, IComparer<TKey>? comparer)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return (IOrderedQueryable<TSource>)source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.ThenBy_TSource_TKey_3(typeof(TSource), typeof(TKey)), source.Expression, Expression.Quote(keySelector), Expression.Constant(comparer, typeof(IComparer<TKey>))));
	}

	[DynamicDependency("ThenByDescending`2", typeof(Enumerable))]
	public static IOrderedQueryable<TSource> ThenByDescending<TSource, TKey>(this IOrderedQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return (IOrderedQueryable<TSource>)source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.ThenByDescending_TSource_TKey_2(typeof(TSource), typeof(TKey)), source.Expression, Expression.Quote(keySelector)));
	}

	[DynamicDependency("ThenByDescending`2", typeof(Enumerable))]
	public static IOrderedQueryable<TSource> ThenByDescending<TSource, TKey>(this IOrderedQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, IComparer<TKey>? comparer)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return (IOrderedQueryable<TSource>)source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.ThenByDescending_TSource_TKey_3(typeof(TSource), typeof(TKey)), source.Expression, Expression.Quote(keySelector), Expression.Constant(comparer, typeof(IComparer<TKey>))));
	}

	[DynamicDependency("Take`1", typeof(Enumerable))]
	public static IQueryable<TSource> Take<TSource>(this IQueryable<TSource> source, int count)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.Take_Int32_TSource_2(typeof(TSource)), source.Expression, Expression.Constant(count)));
	}

	[DynamicDependency("Take`1", typeof(Enumerable))]
	public static IQueryable<TSource> Take<TSource>(this IQueryable<TSource> source, Range range)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.Take_Range_TSource_2(typeof(TSource)), source.Expression, Expression.Constant(range)));
	}

	[DynamicDependency("TakeWhile`1", typeof(Enumerable))]
	public static IQueryable<TSource> TakeWhile<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.TakeWhile_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(predicate)));
	}

	[DynamicDependency("TakeWhile`1", typeof(Enumerable))]
	public static IQueryable<TSource> TakeWhile<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, int, bool>> predicate)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.TakeWhile_Index_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(predicate)));
	}

	[DynamicDependency("Skip`1", typeof(Enumerable))]
	public static IQueryable<TSource> Skip<TSource>(this IQueryable<TSource> source, int count)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.Skip_TSource_2(typeof(TSource)), source.Expression, Expression.Constant(count)));
	}

	[DynamicDependency("SkipWhile`1", typeof(Enumerable))]
	public static IQueryable<TSource> SkipWhile<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.SkipWhile_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(predicate)));
	}

	[DynamicDependency("SkipWhile`1", typeof(Enumerable))]
	public static IQueryable<TSource> SkipWhile<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, int, bool>> predicate)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.SkipWhile_Index_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(predicate)));
	}

	[DynamicDependency("GroupBy`2", typeof(Enumerable))]
	public static IQueryable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return source.Provider.CreateQuery<IGrouping<TKey, TSource>>(Expression.Call(null, CachedReflectionInfo.GroupBy_TSource_TKey_2(typeof(TSource), typeof(TKey)), source.Expression, Expression.Quote(keySelector)));
	}

	[DynamicDependency("GroupBy`3", typeof(Enumerable))]
	public static IQueryable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, Expression<Func<TSource, TElement>> elementSelector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		if (elementSelector == null)
		{
			throw Error.ArgumentNull("elementSelector");
		}
		return source.Provider.CreateQuery<IGrouping<TKey, TElement>>(Expression.Call(null, CachedReflectionInfo.GroupBy_TSource_TKey_TElement_3(typeof(TSource), typeof(TKey), typeof(TElement)), source.Expression, Expression.Quote(keySelector), Expression.Quote(elementSelector)));
	}

	[DynamicDependency("GroupBy`2", typeof(Enumerable))]
	public static IQueryable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, IEqualityComparer<TKey>? comparer)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return source.Provider.CreateQuery<IGrouping<TKey, TSource>>(Expression.Call(null, CachedReflectionInfo.GroupBy_TSource_TKey_3(typeof(TSource), typeof(TKey)), source.Expression, Expression.Quote(keySelector), Expression.Constant(comparer, typeof(IEqualityComparer<TKey>))));
	}

	[DynamicDependency("GroupBy`3", typeof(Enumerable))]
	public static IQueryable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, Expression<Func<TSource, TElement>> elementSelector, IEqualityComparer<TKey>? comparer)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		if (elementSelector == null)
		{
			throw Error.ArgumentNull("elementSelector");
		}
		return source.Provider.CreateQuery<IGrouping<TKey, TElement>>(Expression.Call(null, CachedReflectionInfo.GroupBy_TSource_TKey_TElement_4(typeof(TSource), typeof(TKey), typeof(TElement)), source.Expression, Expression.Quote(keySelector), Expression.Quote(elementSelector), Expression.Constant(comparer, typeof(IEqualityComparer<TKey>))));
	}

	[DynamicDependency("GroupBy`4", typeof(Enumerable))]
	public static IQueryable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, Expression<Func<TSource, TElement>> elementSelector, Expression<Func<TKey, IEnumerable<TElement>, TResult>> resultSelector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		if (elementSelector == null)
		{
			throw Error.ArgumentNull("elementSelector");
		}
		if (resultSelector == null)
		{
			throw Error.ArgumentNull("resultSelector");
		}
		return source.Provider.CreateQuery<TResult>(Expression.Call(null, CachedReflectionInfo.GroupBy_TSource_TKey_TElement_TResult_4(typeof(TSource), typeof(TKey), typeof(TElement), typeof(TResult)), source.Expression, Expression.Quote(keySelector), Expression.Quote(elementSelector), Expression.Quote(resultSelector)));
	}

	[DynamicDependency("GroupBy`3", typeof(Enumerable))]
	public static IQueryable<TResult> GroupBy<TSource, TKey, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, Expression<Func<TKey, IEnumerable<TSource>, TResult>> resultSelector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		if (resultSelector == null)
		{
			throw Error.ArgumentNull("resultSelector");
		}
		return source.Provider.CreateQuery<TResult>(Expression.Call(null, CachedReflectionInfo.GroupBy_TSource_TKey_TResult_3(typeof(TSource), typeof(TKey), typeof(TResult)), source.Expression, Expression.Quote(keySelector), Expression.Quote(resultSelector)));
	}

	[DynamicDependency("GroupBy`3", typeof(Enumerable))]
	public static IQueryable<TResult> GroupBy<TSource, TKey, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, Expression<Func<TKey, IEnumerable<TSource>, TResult>> resultSelector, IEqualityComparer<TKey>? comparer)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		if (resultSelector == null)
		{
			throw Error.ArgumentNull("resultSelector");
		}
		return source.Provider.CreateQuery<TResult>(Expression.Call(null, CachedReflectionInfo.GroupBy_TSource_TKey_TResult_4(typeof(TSource), typeof(TKey), typeof(TResult)), source.Expression, Expression.Quote(keySelector), Expression.Quote(resultSelector), Expression.Constant(comparer, typeof(IEqualityComparer<TKey>))));
	}

	[DynamicDependency("GroupBy`4", typeof(Enumerable))]
	public static IQueryable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, Expression<Func<TSource, TElement>> elementSelector, Expression<Func<TKey, IEnumerable<TElement>, TResult>> resultSelector, IEqualityComparer<TKey>? comparer)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		if (elementSelector == null)
		{
			throw Error.ArgumentNull("elementSelector");
		}
		if (resultSelector == null)
		{
			throw Error.ArgumentNull("resultSelector");
		}
		return source.Provider.CreateQuery<TResult>(Expression.Call(null, CachedReflectionInfo.GroupBy_TSource_TKey_TElement_TResult_5(typeof(TSource), typeof(TKey), typeof(TElement), typeof(TResult)), source.Expression, Expression.Quote(keySelector), Expression.Quote(elementSelector), Expression.Quote(resultSelector), Expression.Constant(comparer, typeof(IEqualityComparer<TKey>))));
	}

	[DynamicDependency("Distinct`1", typeof(Enumerable))]
	public static IQueryable<TSource> Distinct<TSource>(this IQueryable<TSource> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.Distinct_TSource_1(typeof(TSource)), source.Expression));
	}

	[DynamicDependency("Distinct`1", typeof(Enumerable))]
	public static IQueryable<TSource> Distinct<TSource>(this IQueryable<TSource> source, IEqualityComparer<TSource>? comparer)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.Distinct_TSource_2(typeof(TSource)), source.Expression, Expression.Constant(comparer, typeof(IEqualityComparer<TSource>))));
	}

	[DynamicDependency("DistinctBy`2", typeof(Enumerable))]
	public static IQueryable<TSource> DistinctBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.DistinctBy_TSource_TKey_2(typeof(TSource), typeof(TKey)), source.Expression, Expression.Quote(keySelector)));
	}

	[DynamicDependency("DistinctBy`2", typeof(Enumerable))]
	public static IQueryable<TSource> DistinctBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, IEqualityComparer<TKey>? comparer)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.DistinctBy_TSource_TKey_3(typeof(TSource), typeof(TKey)), source.Expression, Expression.Quote(keySelector), Expression.Constant(comparer, typeof(IEqualityComparer<TKey>))));
	}

	[DynamicDependency("Chunk`1", typeof(Enumerable))]
	public static IQueryable<TSource[]> Chunk<TSource>(this IQueryable<TSource> source, int size)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.CreateQuery<TSource[]>(Expression.Call(null, CachedReflectionInfo.Chunk_TSource_1(typeof(TSource)), source.Expression, Expression.Constant(size)));
	}

	[DynamicDependency("Concat`1", typeof(Enumerable))]
	public static IQueryable<TSource> Concat<TSource>(this IQueryable<TSource> source1, IEnumerable<TSource> source2)
	{
		if (source1 == null)
		{
			throw Error.ArgumentNull("source1");
		}
		if (source2 == null)
		{
			throw Error.ArgumentNull("source2");
		}
		return source1.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.Concat_TSource_2(typeof(TSource)), source1.Expression, GetSourceExpression(source2)));
	}

	[DynamicDependency("Zip`2", typeof(Enumerable))]
	public static IQueryable<(TFirst First, TSecond Second)> Zip<TFirst, TSecond>(this IQueryable<TFirst> source1, IEnumerable<TSecond> source2)
	{
		if (source1 == null)
		{
			throw Error.ArgumentNull("source1");
		}
		if (source2 == null)
		{
			throw Error.ArgumentNull("source2");
		}
		return source1.Provider.CreateQuery<(TFirst, TSecond)>(Expression.Call(null, CachedReflectionInfo.Zip_TFirst_TSecond_2(typeof(TFirst), typeof(TSecond)), source1.Expression, GetSourceExpression(source2)));
	}

	[DynamicDependency("Zip`3", typeof(Enumerable))]
	public static IQueryable<TResult> Zip<TFirst, TSecond, TResult>(this IQueryable<TFirst> source1, IEnumerable<TSecond> source2, Expression<Func<TFirst, TSecond, TResult>> resultSelector)
	{
		if (source1 == null)
		{
			throw Error.ArgumentNull("source1");
		}
		if (source2 == null)
		{
			throw Error.ArgumentNull("source2");
		}
		if (resultSelector == null)
		{
			throw Error.ArgumentNull("resultSelector");
		}
		return source1.Provider.CreateQuery<TResult>(Expression.Call(null, CachedReflectionInfo.Zip_TFirst_TSecond_TResult_3(typeof(TFirst), typeof(TSecond), typeof(TResult)), source1.Expression, GetSourceExpression(source2), Expression.Quote(resultSelector)));
	}

	[DynamicDependency("Zip`3", typeof(Enumerable))]
	public static IQueryable<(TFirst First, TSecond Second, TThird Third)> Zip<TFirst, TSecond, TThird>(this IQueryable<TFirst> source1, IEnumerable<TSecond> source2, IEnumerable<TThird> source3)
	{
		if (source1 == null)
		{
			throw Error.ArgumentNull("source1");
		}
		if (source2 == null)
		{
			throw Error.ArgumentNull("source2");
		}
		if (source3 == null)
		{
			throw Error.ArgumentNull("source3");
		}
		return source1.Provider.CreateQuery<(TFirst, TSecond, TThird)>(Expression.Call(null, CachedReflectionInfo.Zip_TFirst_TSecond_TThird_3(typeof(TFirst), typeof(TSecond), typeof(TThird)), source1.Expression, GetSourceExpression(source2), GetSourceExpression(source3)));
	}

	[DynamicDependency("Union`1", typeof(Enumerable))]
	public static IQueryable<TSource> Union<TSource>(this IQueryable<TSource> source1, IEnumerable<TSource> source2)
	{
		if (source1 == null)
		{
			throw Error.ArgumentNull("source1");
		}
		if (source2 == null)
		{
			throw Error.ArgumentNull("source2");
		}
		return source1.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.Union_TSource_2(typeof(TSource)), source1.Expression, GetSourceExpression(source2)));
	}

	[DynamicDependency("Union`1", typeof(Enumerable))]
	public static IQueryable<TSource> Union<TSource>(this IQueryable<TSource> source1, IEnumerable<TSource> source2, IEqualityComparer<TSource>? comparer)
	{
		if (source1 == null)
		{
			throw Error.ArgumentNull("source1");
		}
		if (source2 == null)
		{
			throw Error.ArgumentNull("source2");
		}
		return source1.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.Union_TSource_3(typeof(TSource)), source1.Expression, GetSourceExpression(source2), Expression.Constant(comparer, typeof(IEqualityComparer<TSource>))));
	}

	[DynamicDependency("UnionBy`2", typeof(Enumerable))]
	public static IQueryable<TSource> UnionBy<TSource, TKey>(this IQueryable<TSource> source1, IEnumerable<TSource> source2, Expression<Func<TSource, TKey>> keySelector)
	{
		if (source1 == null)
		{
			throw Error.ArgumentNull("source1");
		}
		if (source2 == null)
		{
			throw Error.ArgumentNull("source2");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return source1.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.UnionBy_TSource_TKey_3(typeof(TSource), typeof(TKey)), source1.Expression, GetSourceExpression(source2), Expression.Quote(keySelector)));
	}

	[DynamicDependency("UnionBy`2", typeof(Enumerable))]
	public static IQueryable<TSource> UnionBy<TSource, TKey>(this IQueryable<TSource> source1, IEnumerable<TSource> source2, Expression<Func<TSource, TKey>> keySelector, IEqualityComparer<TKey>? comparer)
	{
		if (source1 == null)
		{
			throw Error.ArgumentNull("source1");
		}
		if (source2 == null)
		{
			throw Error.ArgumentNull("source2");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return source1.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.UnionBy_TSource_TKey_4(typeof(TSource), typeof(TKey)), source1.Expression, GetSourceExpression(source2), Expression.Quote(keySelector), Expression.Constant(comparer, typeof(IEqualityComparer<TKey>))));
	}

	[DynamicDependency("Intersect`1", typeof(Enumerable))]
	public static IQueryable<TSource> Intersect<TSource>(this IQueryable<TSource> source1, IEnumerable<TSource> source2)
	{
		if (source1 == null)
		{
			throw Error.ArgumentNull("source1");
		}
		if (source2 == null)
		{
			throw Error.ArgumentNull("source2");
		}
		return source1.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.Intersect_TSource_2(typeof(TSource)), source1.Expression, GetSourceExpression(source2)));
	}

	[DynamicDependency("Intersect`1", typeof(Enumerable))]
	public static IQueryable<TSource> Intersect<TSource>(this IQueryable<TSource> source1, IEnumerable<TSource> source2, IEqualityComparer<TSource>? comparer)
	{
		if (source1 == null)
		{
			throw Error.ArgumentNull("source1");
		}
		if (source2 == null)
		{
			throw Error.ArgumentNull("source2");
		}
		return source1.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.Intersect_TSource_3(typeof(TSource)), source1.Expression, GetSourceExpression(source2), Expression.Constant(comparer, typeof(IEqualityComparer<TSource>))));
	}

	[DynamicDependency("IntersectBy`2", typeof(Enumerable))]
	public static IQueryable<TSource> IntersectBy<TSource, TKey>(this IQueryable<TSource> source1, IEnumerable<TKey> source2, Expression<Func<TSource, TKey>> keySelector)
	{
		if (source1 == null)
		{
			throw Error.ArgumentNull("source1");
		}
		if (source2 == null)
		{
			throw Error.ArgumentNull("source2");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return source1.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.IntersectBy_TSource_TKey_3(typeof(TSource), typeof(TKey)), source1.Expression, GetSourceExpression(source2), Expression.Quote(keySelector)));
	}

	[DynamicDependency("IntersectBy`2", typeof(Enumerable))]
	public static IQueryable<TSource> IntersectBy<TSource, TKey>(this IQueryable<TSource> source1, IEnumerable<TKey> source2, Expression<Func<TSource, TKey>> keySelector, IEqualityComparer<TKey>? comparer)
	{
		if (source1 == null)
		{
			throw Error.ArgumentNull("source1");
		}
		if (source2 == null)
		{
			throw Error.ArgumentNull("source2");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return source1.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.IntersectBy_TSource_TKey_4(typeof(TSource), typeof(TKey)), source1.Expression, GetSourceExpression(source2), Expression.Quote(keySelector), Expression.Constant(comparer, typeof(IEqualityComparer<TKey>))));
	}

	[DynamicDependency("Except`1", typeof(Enumerable))]
	public static IQueryable<TSource> Except<TSource>(this IQueryable<TSource> source1, IEnumerable<TSource> source2)
	{
		if (source1 == null)
		{
			throw Error.ArgumentNull("source1");
		}
		if (source2 == null)
		{
			throw Error.ArgumentNull("source2");
		}
		return source1.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.Except_TSource_2(typeof(TSource)), source1.Expression, GetSourceExpression(source2)));
	}

	[DynamicDependency("Except`1", typeof(Enumerable))]
	public static IQueryable<TSource> Except<TSource>(this IQueryable<TSource> source1, IEnumerable<TSource> source2, IEqualityComparer<TSource>? comparer)
	{
		if (source1 == null)
		{
			throw Error.ArgumentNull("source1");
		}
		if (source2 == null)
		{
			throw Error.ArgumentNull("source2");
		}
		return source1.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.Except_TSource_3(typeof(TSource)), source1.Expression, GetSourceExpression(source2), Expression.Constant(comparer, typeof(IEqualityComparer<TSource>))));
	}

	[DynamicDependency("ExceptBy`2", typeof(Enumerable))]
	public static IQueryable<TSource> ExceptBy<TSource, TKey>(this IQueryable<TSource> source1, IEnumerable<TKey> source2, Expression<Func<TSource, TKey>> keySelector)
	{
		if (source1 == null)
		{
			throw Error.ArgumentNull("source1");
		}
		if (source2 == null)
		{
			throw Error.ArgumentNull("source2");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return source1.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.ExceptBy_TSource_TKey_3(typeof(TSource), typeof(TKey)), source1.Expression, GetSourceExpression(source2), Expression.Quote(keySelector)));
	}

	[DynamicDependency("ExceptBy`2", typeof(Enumerable))]
	public static IQueryable<TSource> ExceptBy<TSource, TKey>(this IQueryable<TSource> source1, IEnumerable<TKey> source2, Expression<Func<TSource, TKey>> keySelector, IEqualityComparer<TKey>? comparer)
	{
		if (source1 == null)
		{
			throw Error.ArgumentNull("source1");
		}
		if (source2 == null)
		{
			throw Error.ArgumentNull("source2");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return source1.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.ExceptBy_TSource_TKey_4(typeof(TSource), typeof(TKey)), source1.Expression, GetSourceExpression(source2), Expression.Quote(keySelector), Expression.Constant(comparer, typeof(IEqualityComparer<TKey>))));
	}

	[DynamicDependency("First`1", typeof(Enumerable))]
	public static TSource First<TSource>(this IQueryable<TSource> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.First_TSource_1(typeof(TSource)), source.Expression));
	}

	[DynamicDependency("First`1", typeof(Enumerable))]
	public static TSource First<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.First_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(predicate)));
	}

	[DynamicDependency("FirstOrDefault`1", typeof(Enumerable))]
	public static TSource? FirstOrDefault<TSource>(this IQueryable<TSource> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.FirstOrDefault_TSource_1(typeof(TSource)), source.Expression));
	}

	[DynamicDependency("FirstOrDefault`1", typeof(Enumerable))]
	public static TSource FirstOrDefault<TSource>(this IQueryable<TSource> source, TSource defaultValue)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.FirstOrDefault_TSource_3(typeof(TSource)), source.Expression, Expression.Constant(defaultValue, typeof(TSource))));
	}

	[DynamicDependency("FirstOrDefault`1", typeof(Enumerable))]
	public static TSource? FirstOrDefault<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.FirstOrDefault_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(predicate)));
	}

	[DynamicDependency("FirstOrDefault`1", typeof(Enumerable))]
	public static TSource FirstOrDefault<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate, TSource defaultValue)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.FirstOrDefault_TSource_4(typeof(TSource)), source.Expression, Expression.Quote(predicate), Expression.Constant(defaultValue, typeof(TSource))));
	}

	[DynamicDependency("Last`1", typeof(Enumerable))]
	public static TSource Last<TSource>(this IQueryable<TSource> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.Last_TSource_1(typeof(TSource)), source.Expression));
	}

	[DynamicDependency("Last`1", typeof(Enumerable))]
	public static TSource Last<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.Last_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(predicate)));
	}

	[DynamicDependency("LastOrDefault`1", typeof(Enumerable))]
	public static TSource? LastOrDefault<TSource>(this IQueryable<TSource> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.LastOrDefault_TSource_1(typeof(TSource)), source.Expression));
	}

	[DynamicDependency("LastOrDefault`1", typeof(Enumerable))]
	public static TSource LastOrDefault<TSource>(this IQueryable<TSource> source, TSource defaultValue)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.LastOrDefault_TSource_3(typeof(TSource)), source.Expression, Expression.Constant(defaultValue, typeof(TSource))));
	}

	[DynamicDependency("LastOrDefault`1", typeof(Enumerable))]
	public static TSource? LastOrDefault<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.LastOrDefault_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(predicate)));
	}

	[DynamicDependency("LastOrDefault`1", typeof(Enumerable))]
	public static TSource LastOrDefault<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate, TSource defaultValue)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.LastOrDefault_TSource_4(typeof(TSource)), source.Expression, Expression.Quote(predicate), Expression.Constant(defaultValue, typeof(TSource))));
	}

	[DynamicDependency("Single`1", typeof(Enumerable))]
	public static TSource Single<TSource>(this IQueryable<TSource> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.Single_TSource_1(typeof(TSource)), source.Expression));
	}

	[DynamicDependency("Single`1", typeof(Enumerable))]
	public static TSource Single<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.Single_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(predicate)));
	}

	[DynamicDependency("SingleOrDefault`1", typeof(Enumerable))]
	public static TSource? SingleOrDefault<TSource>(this IQueryable<TSource> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.SingleOrDefault_TSource_1(typeof(TSource)), source.Expression));
	}

	[DynamicDependency("SingleOrDefault`1", typeof(Enumerable))]
	public static TSource SingleOrDefault<TSource>(this IQueryable<TSource> source, TSource defaultValue)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.SingleOrDefault_TSource_3(typeof(TSource)), source.Expression, Expression.Constant(defaultValue, typeof(TSource))));
	}

	[DynamicDependency("SingleOrDefault`1", typeof(Enumerable))]
	public static TSource? SingleOrDefault<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.SingleOrDefault_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(predicate)));
	}

	[DynamicDependency("SingleOrDefault`1", typeof(Enumerable))]
	public static TSource SingleOrDefault<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate, TSource defaultValue)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.SingleOrDefault_TSource_4(typeof(TSource)), source.Expression, Expression.Quote(predicate), Expression.Constant(defaultValue, typeof(TSource))));
	}

	[DynamicDependency("ElementAt`1", typeof(Enumerable))]
	public static TSource ElementAt<TSource>(this IQueryable<TSource> source, int index)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (index < 0)
		{
			throw Error.ArgumentOutOfRange("index");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.ElementAt_Int32_TSource_2(typeof(TSource)), source.Expression, Expression.Constant(index)));
	}

	[DynamicDependency("ElementAt`1", typeof(Enumerable))]
	public static TSource ElementAt<TSource>(this IQueryable<TSource> source, Index index)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (index.IsFromEnd && index.Value == 0)
		{
			throw Error.ArgumentOutOfRange("index");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.ElementAt_Index_TSource_2(typeof(TSource)), source.Expression, Expression.Constant(index)));
	}

	[DynamicDependency("ElementAtOrDefault`1", typeof(Enumerable))]
	public static TSource? ElementAtOrDefault<TSource>(this IQueryable<TSource> source, int index)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.ElementAtOrDefault_Int32_TSource_2(typeof(TSource)), source.Expression, Expression.Constant(index)));
	}

	[DynamicDependency("ElementAtOrDefault`1", typeof(Enumerable))]
	public static TSource? ElementAtOrDefault<TSource>(this IQueryable<TSource> source, Index index)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.ElementAtOrDefault_Index_TSource_2(typeof(TSource)), source.Expression, Expression.Constant(index)));
	}

	[DynamicDependency("DefaultIfEmpty`1", typeof(Enumerable))]
	public static IQueryable<TSource> DefaultIfEmpty<TSource>(this IQueryable<TSource> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.DefaultIfEmpty_TSource_1(typeof(TSource)), source.Expression));
	}

	[DynamicDependency("DefaultIfEmpty`1", typeof(Enumerable))]
	public static IQueryable<TSource> DefaultIfEmpty<TSource>(this IQueryable<TSource> source, TSource defaultValue)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.DefaultIfEmpty_TSource_2(typeof(TSource)), source.Expression, Expression.Constant(defaultValue, typeof(TSource))));
	}

	[DynamicDependency("Contains`1", typeof(Enumerable))]
	public static bool Contains<TSource>(this IQueryable<TSource> source, TSource item)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<bool>(Expression.Call(null, CachedReflectionInfo.Contains_TSource_2(typeof(TSource)), source.Expression, Expression.Constant(item, typeof(TSource))));
	}

	[DynamicDependency("Contains`1", typeof(Enumerable))]
	public static bool Contains<TSource>(this IQueryable<TSource> source, TSource item, IEqualityComparer<TSource>? comparer)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<bool>(Expression.Call(null, CachedReflectionInfo.Contains_TSource_3(typeof(TSource)), source.Expression, Expression.Constant(item, typeof(TSource)), Expression.Constant(comparer, typeof(IEqualityComparer<TSource>))));
	}

	[DynamicDependency("Reverse`1", typeof(Enumerable))]
	public static IQueryable<TSource> Reverse<TSource>(this IQueryable<TSource> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.Reverse_TSource_1(typeof(TSource)), source.Expression));
	}

	[DynamicDependency("SequenceEqual`1", typeof(Enumerable))]
	public static bool SequenceEqual<TSource>(this IQueryable<TSource> source1, IEnumerable<TSource> source2)
	{
		if (source1 == null)
		{
			throw Error.ArgumentNull("source1");
		}
		if (source2 == null)
		{
			throw Error.ArgumentNull("source2");
		}
		return source1.Provider.Execute<bool>(Expression.Call(null, CachedReflectionInfo.SequenceEqual_TSource_2(typeof(TSource)), source1.Expression, GetSourceExpression(source2)));
	}

	[DynamicDependency("SequenceEqual`1", typeof(Enumerable))]
	public static bool SequenceEqual<TSource>(this IQueryable<TSource> source1, IEnumerable<TSource> source2, IEqualityComparer<TSource>? comparer)
	{
		if (source1 == null)
		{
			throw Error.ArgumentNull("source1");
		}
		if (source2 == null)
		{
			throw Error.ArgumentNull("source2");
		}
		return source1.Provider.Execute<bool>(Expression.Call(null, CachedReflectionInfo.SequenceEqual_TSource_3(typeof(TSource)), source1.Expression, GetSourceExpression(source2), Expression.Constant(comparer, typeof(IEqualityComparer<TSource>))));
	}

	[DynamicDependency("Any`1", typeof(Enumerable))]
	public static bool Any<TSource>(this IQueryable<TSource> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<bool>(Expression.Call(null, CachedReflectionInfo.Any_TSource_1(typeof(TSource)), source.Expression));
	}

	[DynamicDependency("Any`1", typeof(Enumerable))]
	public static bool Any<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.Execute<bool>(Expression.Call(null, CachedReflectionInfo.Any_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(predicate)));
	}

	[DynamicDependency("All`1", typeof(Enumerable))]
	public static bool All<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.Execute<bool>(Expression.Call(null, CachedReflectionInfo.All_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(predicate)));
	}

	[DynamicDependency("Count`1", typeof(Enumerable))]
	public static int Count<TSource>(this IQueryable<TSource> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<int>(Expression.Call(null, CachedReflectionInfo.Count_TSource_1(typeof(TSource)), source.Expression));
	}

	[DynamicDependency("Count`1", typeof(Enumerable))]
	public static int Count<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.Execute<int>(Expression.Call(null, CachedReflectionInfo.Count_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(predicate)));
	}

	[DynamicDependency("LongCount`1", typeof(Enumerable))]
	public static long LongCount<TSource>(this IQueryable<TSource> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<long>(Expression.Call(null, CachedReflectionInfo.LongCount_TSource_1(typeof(TSource)), source.Expression));
	}

	[DynamicDependency("LongCount`1", typeof(Enumerable))]
	public static long LongCount<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (predicate == null)
		{
			throw Error.ArgumentNull("predicate");
		}
		return source.Provider.Execute<long>(Expression.Call(null, CachedReflectionInfo.LongCount_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(predicate)));
	}

	[DynamicDependency("Min`1", typeof(Enumerable))]
	public static TSource? Min<TSource>(this IQueryable<TSource> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.Min_TSource_1(typeof(TSource)), source.Expression));
	}

	[DynamicDependency("Min`1", typeof(Enumerable))]
	public static TSource? Min<TSource>(this IQueryable<TSource> source, IComparer<TSource>? comparer)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.Min_TSource_2(typeof(TSource)), source.Expression, Expression.Constant(comparer, typeof(IComparer<TSource>))));
	}

	[DynamicDependency("Min`2", typeof(Enumerable))]
	public static TResult? Min<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<TResult>(Expression.Call(null, CachedReflectionInfo.Min_TSource_TResult_2(typeof(TSource), typeof(TResult)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("MinBy`2", typeof(Enumerable))]
	public static TSource? MinBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.MinBy_TSource_TKey_2(typeof(TSource), typeof(TKey)), source.Expression, Expression.Quote(keySelector)));
	}

	[DynamicDependency("MinBy`2", typeof(Enumerable))]
	public static TSource? MinBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, IComparer<TSource>? comparer)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.MinBy_TSource_TKey_3(typeof(TSource), typeof(TKey)), source.Expression, Expression.Quote(keySelector), Expression.Constant(comparer, typeof(IComparer<TSource>))));
	}

	[DynamicDependency("Max`1", typeof(Enumerable))]
	public static TSource? Max<TSource>(this IQueryable<TSource> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.Max_TSource_1(typeof(TSource)), source.Expression));
	}

	[DynamicDependency("Max`1", typeof(Enumerable))]
	public static TSource? Max<TSource>(this IQueryable<TSource> source, IComparer<TSource>? comparer)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.Max_TSource_2(typeof(TSource)), source.Expression, Expression.Constant(comparer, typeof(IComparer<TSource>))));
	}

	[DynamicDependency("Max`2", typeof(Enumerable))]
	public static TResult? Max<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<TResult>(Expression.Call(null, CachedReflectionInfo.Max_TSource_TResult_2(typeof(TSource), typeof(TResult)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("MaxBy`2", typeof(Enumerable))]
	public static TSource? MaxBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.MaxBy_TSource_TKey_2(typeof(TSource), typeof(TKey)), source.Expression, Expression.Quote(keySelector)));
	}

	[DynamicDependency("MaxBy`2", typeof(Enumerable))]
	public static TSource? MaxBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, IComparer<TSource>? comparer)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (keySelector == null)
		{
			throw Error.ArgumentNull("keySelector");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.MaxBy_TSource_TKey_3(typeof(TSource), typeof(TKey)), source.Expression, Expression.Quote(keySelector), Expression.Constant(comparer, typeof(IComparer<TSource>))));
	}

	[DynamicDependency("Sum", typeof(Enumerable))]
	public static int Sum(this IQueryable<int> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<int>(Expression.Call(null, CachedReflectionInfo.Sum_Int32_1, source.Expression));
	}

	[DynamicDependency("Sum", typeof(Enumerable))]
	public static int? Sum(this IQueryable<int?> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<int?>(Expression.Call(null, CachedReflectionInfo.Sum_NullableInt32_1, source.Expression));
	}

	[DynamicDependency("Sum", typeof(Enumerable))]
	public static long Sum(this IQueryable<long> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<long>(Expression.Call(null, CachedReflectionInfo.Sum_Int64_1, source.Expression));
	}

	[DynamicDependency("Sum", typeof(Enumerable))]
	public static long? Sum(this IQueryable<long?> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<long?>(Expression.Call(null, CachedReflectionInfo.Sum_NullableInt64_1, source.Expression));
	}

	[DynamicDependency("Sum", typeof(Enumerable))]
	public static float Sum(this IQueryable<float> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<float>(Expression.Call(null, CachedReflectionInfo.Sum_Single_1, source.Expression));
	}

	[DynamicDependency("Sum", typeof(Enumerable))]
	public static float? Sum(this IQueryable<float?> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<float?>(Expression.Call(null, CachedReflectionInfo.Sum_NullableSingle_1, source.Expression));
	}

	[DynamicDependency("Sum", typeof(Enumerable))]
	public static double Sum(this IQueryable<double> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<double>(Expression.Call(null, CachedReflectionInfo.Sum_Double_1, source.Expression));
	}

	[DynamicDependency("Sum", typeof(Enumerable))]
	public static double? Sum(this IQueryable<double?> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<double?>(Expression.Call(null, CachedReflectionInfo.Sum_NullableDouble_1, source.Expression));
	}

	[DynamicDependency("Sum", typeof(Enumerable))]
	public static decimal Sum(this IQueryable<decimal> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<decimal>(Expression.Call(null, CachedReflectionInfo.Sum_Decimal_1, source.Expression));
	}

	[DynamicDependency("Sum", typeof(Enumerable))]
	public static decimal? Sum(this IQueryable<decimal?> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<decimal?>(Expression.Call(null, CachedReflectionInfo.Sum_NullableDecimal_1, source.Expression));
	}

	[DynamicDependency("Sum`1", typeof(Enumerable))]
	public static int Sum<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, int>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<int>(Expression.Call(null, CachedReflectionInfo.Sum_Int32_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Sum`1", typeof(Enumerable))]
	public static int? Sum<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, int?>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<int?>(Expression.Call(null, CachedReflectionInfo.Sum_NullableInt32_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Sum`1", typeof(Enumerable))]
	public static long Sum<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, long>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<long>(Expression.Call(null, CachedReflectionInfo.Sum_Int64_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Sum`1", typeof(Enumerable))]
	public static long? Sum<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, long?>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<long?>(Expression.Call(null, CachedReflectionInfo.Sum_NullableInt64_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Sum`1", typeof(Enumerable))]
	public static float Sum<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, float>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<float>(Expression.Call(null, CachedReflectionInfo.Sum_Single_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Sum`1", typeof(Enumerable))]
	public static float? Sum<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, float?>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<float?>(Expression.Call(null, CachedReflectionInfo.Sum_NullableSingle_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Sum`1", typeof(Enumerable))]
	public static double Sum<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, double>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<double>(Expression.Call(null, CachedReflectionInfo.Sum_Double_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Sum`1", typeof(Enumerable))]
	public static double? Sum<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, double?>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<double?>(Expression.Call(null, CachedReflectionInfo.Sum_NullableDouble_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Sum`1", typeof(Enumerable))]
	public static decimal Sum<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<decimal>(Expression.Call(null, CachedReflectionInfo.Sum_Decimal_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Sum`1", typeof(Enumerable))]
	public static decimal? Sum<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal?>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<decimal?>(Expression.Call(null, CachedReflectionInfo.Sum_NullableDecimal_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Average", typeof(Enumerable))]
	public static double Average(this IQueryable<int> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<double>(Expression.Call(null, CachedReflectionInfo.Average_Int32_1, source.Expression));
	}

	[DynamicDependency("Average", typeof(Enumerable))]
	public static double? Average(this IQueryable<int?> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<double?>(Expression.Call(null, CachedReflectionInfo.Average_NullableInt32_1, source.Expression));
	}

	[DynamicDependency("Average", typeof(Enumerable))]
	public static double Average(this IQueryable<long> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<double>(Expression.Call(null, CachedReflectionInfo.Average_Int64_1, source.Expression));
	}

	[DynamicDependency("Average", typeof(Enumerable))]
	public static double? Average(this IQueryable<long?> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<double?>(Expression.Call(null, CachedReflectionInfo.Average_NullableInt64_1, source.Expression));
	}

	[DynamicDependency("Average", typeof(Enumerable))]
	public static float Average(this IQueryable<float> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<float>(Expression.Call(null, CachedReflectionInfo.Average_Single_1, source.Expression));
	}

	[DynamicDependency("Average", typeof(Enumerable))]
	public static float? Average(this IQueryable<float?> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<float?>(Expression.Call(null, CachedReflectionInfo.Average_NullableSingle_1, source.Expression));
	}

	[DynamicDependency("Average", typeof(Enumerable))]
	public static double Average(this IQueryable<double> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<double>(Expression.Call(null, CachedReflectionInfo.Average_Double_1, source.Expression));
	}

	[DynamicDependency("Average", typeof(Enumerable))]
	public static double? Average(this IQueryable<double?> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<double?>(Expression.Call(null, CachedReflectionInfo.Average_NullableDouble_1, source.Expression));
	}

	[DynamicDependency("Average", typeof(Enumerable))]
	public static decimal Average(this IQueryable<decimal> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<decimal>(Expression.Call(null, CachedReflectionInfo.Average_Decimal_1, source.Expression));
	}

	[DynamicDependency("Average", typeof(Enumerable))]
	public static decimal? Average(this IQueryable<decimal?> source)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.Execute<decimal?>(Expression.Call(null, CachedReflectionInfo.Average_NullableDecimal_1, source.Expression));
	}

	[DynamicDependency("Average`1", typeof(Enumerable))]
	public static double Average<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, int>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<double>(Expression.Call(null, CachedReflectionInfo.Average_Int32_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Average`1", typeof(Enumerable))]
	public static double? Average<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, int?>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<double?>(Expression.Call(null, CachedReflectionInfo.Average_NullableInt32_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Average`1", typeof(Enumerable))]
	public static float Average<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, float>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<float>(Expression.Call(null, CachedReflectionInfo.Average_Single_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Average`1", typeof(Enumerable))]
	public static float? Average<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, float?>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<float?>(Expression.Call(null, CachedReflectionInfo.Average_NullableSingle_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Average`1", typeof(Enumerable))]
	public static double Average<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, long>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<double>(Expression.Call(null, CachedReflectionInfo.Average_Int64_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Average`1", typeof(Enumerable))]
	public static double? Average<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, long?>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<double?>(Expression.Call(null, CachedReflectionInfo.Average_NullableInt64_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Average`1", typeof(Enumerable))]
	public static double Average<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, double>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<double>(Expression.Call(null, CachedReflectionInfo.Average_Double_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Average`1", typeof(Enumerable))]
	public static double? Average<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, double?>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<double?>(Expression.Call(null, CachedReflectionInfo.Average_NullableDouble_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Average`1", typeof(Enumerable))]
	public static decimal Average<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<decimal>(Expression.Call(null, CachedReflectionInfo.Average_Decimal_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Average`1", typeof(Enumerable))]
	public static decimal? Average<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal?>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<decimal?>(Expression.Call(null, CachedReflectionInfo.Average_NullableDecimal_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(selector)));
	}

	[DynamicDependency("Aggregate`1", typeof(Enumerable))]
	public static TSource Aggregate<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, TSource, TSource>> func)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (func == null)
		{
			throw Error.ArgumentNull("func");
		}
		return source.Provider.Execute<TSource>(Expression.Call(null, CachedReflectionInfo.Aggregate_TSource_2(typeof(TSource)), source.Expression, Expression.Quote(func)));
	}

	[DynamicDependency("Aggregate`2", typeof(Enumerable))]
	public static TAccumulate Aggregate<TSource, TAccumulate>(this IQueryable<TSource> source, TAccumulate seed, Expression<Func<TAccumulate, TSource, TAccumulate>> func)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (func == null)
		{
			throw Error.ArgumentNull("func");
		}
		return source.Provider.Execute<TAccumulate>(Expression.Call(null, CachedReflectionInfo.Aggregate_TSource_TAccumulate_3(typeof(TSource), typeof(TAccumulate)), source.Expression, Expression.Constant(seed), Expression.Quote(func)));
	}

	[DynamicDependency("Aggregate`3", typeof(Enumerable))]
	public static TResult Aggregate<TSource, TAccumulate, TResult>(this IQueryable<TSource> source, TAccumulate seed, Expression<Func<TAccumulate, TSource, TAccumulate>> func, Expression<Func<TAccumulate, TResult>> selector)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		if (func == null)
		{
			throw Error.ArgumentNull("func");
		}
		if (selector == null)
		{
			throw Error.ArgumentNull("selector");
		}
		return source.Provider.Execute<TResult>(Expression.Call(null, CachedReflectionInfo.Aggregate_TSource_TAccumulate_TResult_4(typeof(TSource), typeof(TAccumulate), typeof(TResult)), source.Expression, Expression.Constant(seed), Expression.Quote(func), Expression.Quote(selector)));
	}

	[DynamicDependency("SkipLast`1", typeof(Enumerable))]
	public static IQueryable<TSource> SkipLast<TSource>(this IQueryable<TSource> source, int count)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.SkipLast_TSource_2(typeof(TSource)), source.Expression, Expression.Constant(count)));
	}

	[DynamicDependency("TakeLast`1", typeof(Enumerable))]
	public static IQueryable<TSource> TakeLast<TSource>(this IQueryable<TSource> source, int count)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.TakeLast_TSource_2(typeof(TSource)), source.Expression, Expression.Constant(count)));
	}

	[DynamicDependency("Append`1", typeof(Enumerable))]
	public static IQueryable<TSource> Append<TSource>(this IQueryable<TSource> source, TSource element)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.Append_TSource_2(typeof(TSource)), source.Expression, Expression.Constant(element)));
	}

	[DynamicDependency("Prepend`1", typeof(Enumerable))]
	public static IQueryable<TSource> Prepend<TSource>(this IQueryable<TSource> source, TSource element)
	{
		if (source == null)
		{
			throw Error.ArgumentNull("source");
		}
		return source.Provider.CreateQuery<TSource>(Expression.Call(null, CachedReflectionInfo.Prepend_TSource_2(typeof(TSource)), source.Expression, Expression.Constant(element)));
	}
}
