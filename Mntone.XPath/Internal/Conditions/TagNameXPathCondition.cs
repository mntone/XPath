using System.Diagnostics;
using System.Linq.Expressions;

namespace Mntone.XPath.Internal.Conditions
{
	[DebuggerDisplay("TagName = {this.TagName}")]
	internal sealed class TagNameXPathCondition : XPathCondition
	{
		public string TagName { get; }

		public TagNameXPathCondition(string tagName)
		{
			this.TagName = tagName;
		}

		public override Expression Build<T>(ParameterExpression parameter, IXPathRetriveConfig<T> config)
		{
			return Expression.Equal(
				Expression.Invoke(config.TagNameGetter, parameter),
				Expression.Constant(this.TagName, typeof(string)));
		}
	}
}