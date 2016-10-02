/*
При наследовании и определённых конструкторов в каждом из классов, чей конструкторо выполнится первым
	
	* конструктор родитель, замет наследник
*/
using System;

namespace InterviewQuestions.Questions
{
	public class CtorRush:QuestionBase
	{
		private class Parent
		{
			protected static string _staticString = nameof(_staticString); //7
			private string _simpleText = nameof(_simpleText); // 9
			static Parent()
			{
				Console.WriteLine($"static {nameof(Parent)}"); // 8
			}
			public Parent() //10
			{
				Console.WriteLine(nameof(Parent)); //11
			}
		}
		private class Child : Parent
		{
			private string _simpleTextChild = nameof(_simpleTextChild);  //5
			static Child()
			{
				Console.WriteLine($"static {nameof(Child)}"); // 4
			}
			public Child() //6
			{				
				Console.WriteLine(nameof(Child)); //12
			}
		}
		private class ChildNew : Child
		{
			private string _simpleTextChildNew = nameof(_simpleTextChildNew); //2
			static ChildNew()
			{
				Console.WriteLine($"static {nameof(ChildNew)}"); //1
				//Console.WriteLine(_staticString); //если используется статик переменная из класса родителя выше, то перед обращением к ней вызывается статик класса-родителя, в котором она реализованна
			}
			public ChildNew() // 3
			{
				Console.WriteLine(nameof(ChildNew)); // 13
			}
		}
		public CtorRush()
		{
			QuestionData = new QuestionData()
			{
				QuestionDescription = "При наследовании и определённых конструкторов в каждом из классов, чей конструкторо выполнится первым",
				Topic = "Simple"
			};
		}		
		public override void RunQuestion()
		{
			base.RunQuestion();
			ChildNew cw = new ChildNew();
		}
	}
}
