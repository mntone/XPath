using System.Diagnostics;
using System.Linq.Expressions;

namespace Mntone.XPath.Internal.Conditions
{
	[DebuggerDisplay("Name = {this.Name}, Value = {this.Value}")]
	internal sealed class AttributeXPathCondition : XPathCondition
	{
		public string Name { get; }
		public string Value { get; }

		public AttributeXPathCondition(string name, string value)
		{
			this.Name = name;
			this.Value = value;
		}

		public override Expression Build<T>(ParameterExpression parameter, IXPathRetriveConfig<T> config)
		{
			return Expression.Equal(
				Expression.Invoke(config.AttributeValueGetter, parameter, Expression.Constant(this.Name, typeof(string))),
				Expression.Constant(this.Value, typeof(string)));
		}
	}
}