using System;
using System.Collections;
using System.Collections.Generic;
using InterviewQuestions.Questions;

namespace InterviewQuestions
{

	class Program
	{
		static void Main(string[] args)
		{
			QuestionsWorker();
		}
		
		static void QuestionsWorker()
		{

			List<QuestionBase> questions = new List<QuestionBase>();
			questions.Add(new CompareStringsByValueAndReferenc());
			questions.Add(new StringComparisonWithPoolIntern());
			questions.Add(new DifferencesBetweenDisposeAndFinalize());
			questions.Add(new DirectionOfStringParsing());
			questions.Add(new AccessToPrivateFieldInDescendantClass());
			questions.Add(new GetStringEmpty());
			questions.Add(new DifferencesBetweenOverrideAndNew());
			questions.Add(new CheckInterfaceCasting());
			questions.Add(new CtorRush());
			questions.Add(new MemoryLeakInEventContract());
			questions.Add(new StringChanging());
			questions.Add(new NegativeNumbersInRam());
			questions.Add(new DifferencesBetweenExplicitAndImplicitInterfaceRealization());
			questions.Add(new AnonymousTypeCasting());

			for (int i = 0; i < questions.Count; i++)
			{
				Console.WriteLine($"{i}: {questions[i].ToString()}");
			}
			int qNum = 0;
			while (qNum != -1)
			{
				Console.WriteLine($"Insert Number of the questions");
				Console.WriteLine("for exit insert -1");
				if (int.TryParse(Console.ReadLine(), out qNum))
				{
					try { questions[qNum].RunQuestion(); }
					catch (Exception ex) { Console.WriteLine(ex.Message); }
				}
				else Console.WriteLine("must be a number");
				Console.WriteLine();
			}
		}
	}
}
