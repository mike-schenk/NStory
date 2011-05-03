using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace NStory.Tests
{

	public class ScenarioTestFixture
	{
		// ReSharper disable InconsistentNaming
//		protected AutoMock Mock;
//		protected readonly List<string> ChangedProperties = new List<string>();
//		protected Scenario Subject;

		protected string NameOf<T1>(Expression<Func<T1>> propertyExpression)
		{
			var prop = (PropertyInfo)((MemberExpression)propertyExpression.Body).Member;
			return prop.Name;
		}

		[SetUp]
		public void SetUp()
		{
//			Mock = AutoMock.GetLoose();
		}

		[TearDown]
		public void TearDown()
		{
//			Mock.Dispose();
		}
		// ReSharper restore InconsistentNaming
	}
}
