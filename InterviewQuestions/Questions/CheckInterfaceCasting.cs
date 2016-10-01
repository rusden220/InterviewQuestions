/*
	Переопределение двух разных типов к одному интерфейсу и обратно
		public interface IInterface { void ToDo(); }
		public class C1: IInterface
		{
			public int GetNum() { return 0; }
			public void ToDo() { }
		}
		public class C2 : IInterface
		{
			public void ToDo() {}
			public string GetString() { return string.Empty; }
		}
		C1 c1 = new C1();
		C2 c2 = new C2();
		MakeTest((C1)(IInterface)c2);
		private void MakeTest(C1 c1){} 
		что будет

		* ошибка во время выполнения, так как приветит тип с2 к с1 невозможно
*/
using System;


namespace InterviewQuestions.Questions
{
	public class CheckInterfaceCasting:QuestionBase
	{
		private interface IInterface { void ToDo(); }
		private class C1 : IInterface
		{
			public int GetNum() { return 0; }
			public void ToDo() { }
		}
		private class C2 : IInterface
		{
			public void ToDo() { }
			public string GetString() { return string.Empty; }
		}		
		public CheckInterfaceCasting()
		{
			QuestionData = new QuestionData()
			{
				QuestionDescription = "Переопределение двух разных типов к одному интерфейсу и обратно",
				Topic = "Simple"
			};
		}
		private void MakeTest(C1 c1)
		{

		}
		public override void RunQuestion()
		{
			base.RunQuestion();
			try
			{
				C1 c1 = new C1();
				C2 c2 = new C2();
				Console.WriteLine("В начале класс C2 приводится к интерфейсу");
				Console.WriteLine("Теперь интерфейс приводится к классу C1");
				MakeTest((C1)(IInterface)c2);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				//throw;
			}
			

	}
	}
}
