using System.Linq.Expressions;

namespace Mntone.XPath.Internal.Builders
{
	internal abstract class XPathExpressionBuilder
	{
		public XPathExpressionBuilder Child { get; set; }

		protected Expression BuildChild<T>(Expression exp, IXPathRetriveConfig<T> config)
		{
			var builder = this.Child as HierarchyXPathExpressionBuilder;
			if (builder == null) return exp;
			return builder.Build(exp, config);
		}
	}
}