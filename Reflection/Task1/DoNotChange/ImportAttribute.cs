using System;

namespace Task1.DoNotChange
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class ImportAttribute : Attribute
	{
	}
}
