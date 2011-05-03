using System;

namespace NStory.Framework
{
	public static class ScenarioExtensions
	{
		public static IScenarioStep When(this IScenarioStep currentStep, Action stepAction)
		{
			((Scenario.ScenarioRunner)currentStep).AddStep("When", stepAction);
			return currentStep;
		}

		public static IScenarioStep When<T>(this IScenarioStep currentStep, Action<T> stepAction, T param1)
		{
			((Scenario.ScenarioRunner)currentStep).AddStep("When", stepAction, param1);
			return currentStep;
		}

		public static IScenarioStep When<T1, T2>(this IScenarioStep currentStep, Action<T1, T2> stepAction, T1 param1, T2 param2)
		{
			((Scenario.ScenarioRunner)currentStep).AddStep("When", stepAction, param1, param2);
			return currentStep;
		}

		public static IScenarioStep Then(this IScenarioStep currentStep, Action stepAction)
		{
			((Scenario.ScenarioRunner)currentStep).AddStep("Then", stepAction);
			return currentStep;
		}

		public static IScenarioStep Then<T>(this IScenarioStep currentStep, Action<T> stepAction, T param1)
		{
			((Scenario.ScenarioRunner)currentStep).AddStep("Then", stepAction, param1);
			return currentStep;
		}

		public static IScenarioStep Then<T1, T2>(this IScenarioStep currentStep, Action<T1, T2> stepAction, T1 param1, T2 param2)
		{
			((Scenario.ScenarioRunner)currentStep).AddStep("Then", stepAction, param1, param2);
			return currentStep;
		}

		public static IScenarioStep And(this IScenarioStep currentStep, Action stepAction)
		{
			((Scenario.ScenarioRunner)currentStep).AddStep(" and", stepAction);
			return currentStep;
		}

		public static IScenarioStep And<T>(this IScenarioStep currentStep, Action<T> stepAction, T param1)
		{
			((Scenario.ScenarioRunner)currentStep).AddStep(" and", stepAction, param1);
			return currentStep;
		}

		public static IScenarioStep And<T1, T2>(this IScenarioStep currentStep, Action<T1, T2> stepAction, T1 param1, T2 param2)
		{
			((Scenario.ScenarioRunner)currentStep).AddStep(" and", stepAction, param1, param2);
			return currentStep;
		}

		public static IScenarioStep But(this IScenarioStep currentStep, Action stepAction)
		{
			((Scenario.ScenarioRunner)currentStep).AddStep(" but", stepAction);
			return currentStep;
		}

		public static IScenarioStep But<T>(this IScenarioStep currentStep, Action<T> stepAction, T param1)
		{
			((Scenario.ScenarioRunner)currentStep).AddStep(" but", stepAction, param1);
			return currentStep;
		}

		public static IScenarioStep But<T1, T2>(this IScenarioStep currentStep, Action<T1, T2> stepAction, T1 param1, T2 param2)
		{
			((Scenario.ScenarioRunner)currentStep).AddStep(" but", stepAction, param1, param2);
			return currentStep;
		}

		public static void Execute(this IScenarioStep currentStep)
		{
			((Scenario.ScenarioRunner)currentStep).Execute();
		}
	}
}