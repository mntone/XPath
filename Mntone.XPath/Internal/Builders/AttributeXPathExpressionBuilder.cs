using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Mntone.XPath.Internal.Builders
{
	[DebuggerDisplay("Name = {this.Name}")]
	internal sealed class AttributeXPathExpressionBuilder : HierarchyXPathExpressionBuilder
	{
		public string Name { get; }

		public AttributeXPathExpressionBuilder(string name)
		{
			this.Name = name;
		}

		public override Expression Build<T>(Expression exp, IXPathRetriveConfig<T> config)
		{
			var nodeParameter = Expression.Parameter(typeof(T), "node");
			var parentExp = Expression.Call(
				typeof(Enumerable),
				"Select",
				new[] { typeof(T), typeof(string) },
				exp,
				Expression.Lambda(
					Expression.Invoke(config.AttributeValueGetter, nodeParameter, Expression.Constant(this.Name, typeof(string))),
					nodeParameter));
			var childExp = this.BuildChild(parentExp, config);
			return childExp;
		}
	}
}