using System.Linq;
using System.Linq.Expressions;

namespace Mntone.XPath.Internal.Builders
{
	internal sealed class ChildrenPathXPathExpressionBuilder : HierarchyXPathExpressionBuilder
	{
		public override Expression Build<T>(Expression exp, IXPathRetriveConfig<T> config)
		{
			var nodeParameter = Expression.Parameter(typeof(T), "node");
			var node2Parameter = Expression.Parameter(typeof(T), "node2");
			var parentExp = Expression.Call(
				typeof(Enumerable),
				"SelectMany",
				new[] { typeof(T), typeof(T) },
				exp,
				this.Conditions.Count == 0
					? config.ChildrenGetter
					: Expression.Lambda(
						Expression.Call(
							typeof(Enumerable),
							"Where",
							new[] { typeof(T) },
							Expression.Invoke(config.ChildrenGetter, nodeParameter),
							this.Conditions.Select(c => c.Build(node2Parameter, config)).ToAndLambda(node2Parameter)),
						nodeParameter));
			var childExp = this.BuildChild(parentExp, config);
			return childExp;
		}
	}
}