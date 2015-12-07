using Mntone.XPath.Internal.Conditions;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mntone.XPath.Internal.Builders
{
	internal abstract class HierarchyXPathExpressionBuilder : XPathExpressionBuilder
	{
		public List<XPathCondition> Conditions { get; } = new List<XPathCondition>();

		public abstract Expression Build<T>(Expression exp, IXPathRetriveConfig<T> config);
	}
}