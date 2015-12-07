using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mntone.XPath.Internal.Builders
{
	internal sealed class RootXPathExpressionBuilder : XPathExpressionBuilder
	{
		internal RootXPathExpressionBuilder() { }

		internal Func<IEnumerable<TIn>, IEnumerable<TOut>> Build<TIn, TOut>(IXPathRetriveConfig<TIn> config)
		{
			var input = Expression.Parameter(typeof(IEnumerable<TIn>), "input");
			var childExp = this.BuildChild(input, config);
			return (Func<IEnumerable<TIn>, IEnumerable<TOut>>)Expression.Lambda(childExp, input).Compile();
		}
	}
}