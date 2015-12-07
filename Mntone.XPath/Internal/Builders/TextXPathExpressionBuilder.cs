using System.Linq;
using System.Linq.Expressions;

namespace Mntone.XPath.Internal.Builders
{
	internal sealed class TextXPathExpressionBuilder : HierarchyXPathExpressionBuilder
	{
		public override Expression Build<T>(Expression exp, IXPathRetriveConfig<T> config)
		{
			var nodeParameter = Expression.Parameter(typeof(T), "node");
			var parentExp = Expression.Call(
				typeof(Enumerable),
				"Select",
				new[] { typeof(T), typeof(string) },
				exp,
				Expression.Lambda(
					Expression.Invoke(config.TextGetter, nodeParameter),
					nodeParameter));
			var childExp = this.BuildChild(parentExp, config);
			return childExp;
		}
	}
}