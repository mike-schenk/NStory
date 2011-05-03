using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NStory.Framework;
using NUnit.Framework;

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

		IScenarioStep subject;
		private Exception exception;

		public void ASimpleScenario()
		{
			subject = Scenario.Given(() => { });
		}

		public void TheScenarioExecutesAndNoExceptionsAreThrown()
		{
			try
			{
				subject.Execute();
			}
			catch (Exception e)
			{
				exception = e;
			}
		}

		public void NoExceptionsAreReported()
		{
			Assert.That(exception, Is.Null);
		}
	}
}
