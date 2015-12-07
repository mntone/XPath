using System.Linq.Expressions;

namespace Mntone.XPath.Internal.Conditions
{
	internal abstract class XPathCondition
	{
		public abstract Expression Build<T>(ParameterExpression parameter, IXPathRetriveConfig<T> config);
	}
}