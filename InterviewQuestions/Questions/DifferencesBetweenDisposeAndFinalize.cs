/*
	различия между Dispose and Finalize

		* finalize - ~className() вызывается CLR
		* Dispose вызывается при использовании using() или самим пользователем
*/
using System;

namespace InterviewQuestions.Questions
{
	/// <summary>
	/// the differences between dispose and finalize
	/// </summary>
	public class DifferencesBetweenDisposeAndFinalize:QuestionBase
	{
		private class SimpleClass:IDisposable
		{
			public SimpleClass()
			{
				Console.WriteLine("ctor");
			}
			public void DoSomething()
			{
				Console.WriteLine("DoSomething");
			}
			~SimpleClass()
			{
				Console.WriteLine("~SimpleClass ");
			}
			public void Dispose()
			{
				Console.WriteLine("Dispose");
			}
		}
		public DifferencesBetweenDisposeAndFinalize()
		{
			QuestionData = new QuestionData()
			{ QuestionDescription = "различия между Dispose and Finalize",
				Topic = "simple" };
		}
		public override void RunQuestion()
		{
			base.RunQuestion();
			Console.WriteLine("создаётся объект, вызывается метод в нём, затем для него вызывается метод Dispose, после вызывается сборщик мусора, для очистки памяти, так как он работает в фоновом режиме");

			//doesn't work with GC.Collect();
			//using (SimpleClass sc = new SimpleClass())
			//{
			//	sc.DoSomething();
			//	//sc = null;
			//}

			SimpleClass sc = new SimpleClass();
			sc.DoSomething();
			sc.Dispose();
			sc = null;
			GC.Collect();//must be for the example
		}
	}
}
