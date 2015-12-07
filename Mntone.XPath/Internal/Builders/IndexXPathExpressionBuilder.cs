using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Mntone.XPath.Internal.Builders
{
	[DebuggerDisplay("Index = {this.Index}")]
	internal sealed class IndexXPathExpressionBuilder : HierarchyXPathExpressionBuilder
	{
		public int Index { get; }

		public IndexXPathExpressionBuilder(int index)
		{
			this.Index = index;
		}

		public override Expression Build<T>(Expression exp, IXPathRetriveConfig<T> config)
		{
			var nodeParameter = Expression.Parameter(typeof(T), "node");
			var parentExp = Expression.NewArrayInit(
				typeof(T),
				Expression.Call(
					typeof(Enumerable),
					"ElementAt",
					new[] { typeof(T) },
					exp,
					Expression.Constant(this.Index - 1, typeof(int))));
			var childExp = this.BuildChild(parentExp, config);
			return childExp;
		}
	}
}