using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ProCoder.Library.Tests;

namespace NStory.Tests
{
	[TestFixture]
	public class ExceptionTests
	{
		[Test]
		public void GivenAScenario_WhenNoExceptionsAreThrown()
		{
			Scenario
				.Given(ASimpleScenario)
				.When(TheScenarioExecutesAndNoExceptionsAreThrown)
				.Then(NoExceptionsAreReported)
				.Execute();
			
		}

		[Test]
		public void GivenAScenario_WhenOneExceptionIsThrown()
		{
			throw new NotImplementedException();
			
		}

		[Test]
		public void GivenAScenario_WhenTwoExceptionsAreThrown()
		{
			throw new NotImplementedException();
			
		}

		public void ASimpleScenario()
		{
			var s = Scenario.Given(() => { });
		}
		public void TheScenarioExecutesAndNoExceptionsAreThrown()
		{
			
		}

		public void NoExceptionsAreReported()
		{
			
		}
	}
}
