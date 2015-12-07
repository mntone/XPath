using System.Resources;
using System.Reflection;
using Mntone.XPath.Internal;

[assembly: AssemblyTitle(AssemblyInfo.QualifiedName)]
[assembly: AssemblyDescription(AssemblyInfo.Description)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(AssemblyInfo.Author)]
[assembly: AssemblyProduct(AssemblyInfo.QualifiedName)]
[assembly: AssemblyCopyright("Copyright (C) 2015- " + AssemblyInfo.Author)]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("en")]

[assembly: AssemblyVersion("0.9.0.0")]
[assembly: AssemblyFileVersion("0.9.0.0")]

namespace Mntone.XPath.Internal
{
	internal static class AssemblyInfo
	{
		public const string Name = "Mntone.Xpath";
		public const string QualifiedName = "Xpath";
		public const string Description = "Simplified xpath function generator for .NET";
		public const string Version = "0.9.0.0";
		public const string Author = "mntone";
	}
}