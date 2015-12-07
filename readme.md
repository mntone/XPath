# XPath

[![Build status](https://img.shields.io/appveyor/ci/mntone/XPath/master.svg?style=flat-square)](https://ci.appveyor.com/project/mntone/XPath) [![NuGet](https://img.shields.io/nuget/v/Mntone.XPath.svg?style=flat-square)](https://www.nuget.org/packages/Mntone.XPath/) [![Downloads](https://img.shields.io/nuget/dt/Mntone.XPath.svg?style=flat-square)](https://www.nuget.org/packages/Mntone.XPath/) [![License](https://img.shields.io/github/license/mntone/XPath.svg?style=flat-square)](https://github.com/mntone/XPath/blob/master/LICENSE.txt)

This is simplified xpath function generator for .NET.


## Requirement

- Each parser (e.g. HtmlAgilityPack)


## Usage

In this case, use HtmlAgilityPack together.

1. Install XPath.
2. Create class `XPathRetriveConfig.`

	```csharp
	internal sealed class HtmlAgilityXPathRetriveConfig : IXPathRetriveConfig<HtmlNode>
	{
		public static HtmlAgilityXPathRetriveConfig Instance { get { return _Instance ?? (_Instance = new HtmlAgilityXPathRetriveConfig()); } }
		private static HtmlAgilityXPathRetriveConfig _Instance = null;

		private HtmlAgilityXPathRetriveConfig() { }

		public Expression<Func<HtmlNode, IEnumerable<HtmlNode>>> ChildrenGetter => node => node.ChildNodes;

		public Expression<Func<HtmlNode, string>> TagNameGetter => node => node.Name;
		public Expression<Func<HtmlNode, string>> TextGetter => node => node.InnerText;
		public Expression<Func<HtmlNode, string, string>> AttributeValueGetter => (node, name) => node.GetAttributeValue(name, string.Empty);
	}
	```

3. Compile function and parse.

	```csharp
	public string GetFirstDivText(string html)
	{
		var func = XPathExpression.Compile<HtmlNode, T>("/html/body/div[0]/text()", HtmlAgilityXPathRetriveConfig.Instance);

		var doc = new HtmlDocument();
		doc.Load(new StringReader(html));

		var result = func(new[] { doc.DocumentNode }).Single();
		return result;
	}
	```


## LICENSE

[MIT License](https://github.com/mntone/XPath/blob/master/LICENSE.txt)


## Author

- mntone<br>
	GitHub: https://github.com/mntone<br>
	Twitter: https://twitter.com/mntone (posted in Japanese; however, english is ok)