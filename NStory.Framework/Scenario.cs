using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NStory.Framework
{
	public static class Scenario
	{
		public static IScenarioStep Given(Action initialStateSetupMethod)
		{
			var scenarioRunner = new ScenarioRunner();
			scenarioRunner.AddStep("Given", initialStateSetupMethod);
			return scenarioRunner;
		}

		public static IScenarioStep Given<T>(Action<T> initialStateSetupMethod, T param1)
		{
			var scenarioRunner = new ScenarioRunner();
			scenarioRunner.AddStep("Given", initialStateSetupMethod, param1);
			return scenarioRunner;
		}

		public static IScenarioStep Given<T1,T2>(Action<T1,T2> initialStateSetupMethod, T1 param1, T2 param2)
		{
			var scenarioRunner = new ScenarioRunner();
			scenarioRunner.AddStep("Given", initialStateSetupMethod, param1, param2);
			return scenarioRunner;
		}

		public class ScenarioRunner : IScenarioStep
		{
			private readonly List<ConcreteStep> mSteps = new List<ConcreteStep>();

			public void Execute()
			{
				Exception firstFailure = null;
				bool reportSuccess = false;
				foreach (var step in mSteps)
				{
					Console.Out.Write(step.StepKind + " " + step.StepDetails);
					if (step.StepKind == "Given") reportSuccess = false;
					if (step.StepKind == "When") reportSuccess = false;
					if (step.StepKind == "Then") reportSuccess = true;
					try
					{
						step.StepAction.Invoke();
						if (reportSuccess)
							Console.Out.WriteLine(" => passed");
						else
							Console.Out.WriteLine();
					}
					catch (NotImplementedException nie)
					{
						Assert.Inconclusive(nie.Message);
					}
					catch (Exception e)
					{
						firstFailure = e;
						Console.Out.WriteLine(" => failed");
					}
				}
				if (firstFailure != null) throw firstFailure;
			}

			public void AddStep(string stepKind, Action stepAction)
			{
				mSteps.Add(new ConcreteStep(stepKind, FormatName(stepAction.Method.Name), stepAction));
			}

			public void AddStep<T>(string stepKind, Action<T> stepAction, T param1)
			{
				mSteps.Add(new ConcreteStep(stepKind, FormatName(stepAction.Method.Name, param1), () => stepAction(param1)));
			}

			public void AddStep<T1, T2>(string stepKind, Action<T1, T2> stepAction, T1 param1, T2 param2)
			{
				mSteps.Add(new ConcreteStep(stepKind, FormatName(stepAction.Method.Name, param1, param2), () => stepAction(param1, param2)));
			}

			private static string FormatName(string input, params object[] strings)
			{
				var toReturn = new StringBuilder();
				int paramNum = 0;
				for (int i = 0; i < input.Length; i++)
				{
					char c = input[i];
					if (char.IsUpper(c) && i > 0)
						toReturn.Append(" ");
					if(c == '_' && paramNum < strings.Length)
					{
						toReturn.Append(' ');
						if(strings[paramNum] is string)
							toReturn.Append('"');
						toReturn.Append(strings[paramNum]);
						if (strings[paramNum] is string)
							toReturn.Append('"');
						paramNum++;
					}
					else
						toReturn.Append(c);
				}
				if(paramNum < strings.Length)
				{
					for (int i = paramNum; i < strings.Length; i++)
					{
						toReturn.Append(' ');
						if (strings[i] is string)
							toReturn.Append('"');
						toReturn.Append(strings[i]);
						if (strings[i] is string)
							toReturn.Append('"');
					}
				}
				return toReturn.ToString();
			}
		}

		private class ConcreteStep
		{
			public ConcreteStep(string stepKind, string stepDetails, Action stepAction)
			{
				StepKind = stepKind;
				StepDetails = stepDetails;
				StepAction = stepAction;
			}

			public string StepKind { get; private set; }
			public string StepDetails { get; private set; }
			public Action StepAction { get; private set; }
		}
	}
}
