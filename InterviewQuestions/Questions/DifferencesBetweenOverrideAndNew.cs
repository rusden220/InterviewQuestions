/*
	Отличие override от new
	(DifferencesBetweenOverrideAndNew)
	
	* Отличие что override полностью скрывает реализацию в классе родителе, а new нет, то есть метод переопределённый через new не будет скрывать реализацию в родителе, и будет вызвать именно её, а не из класса наследника
	
		class Parent
		{ virtual void todo() { Console.WriteLine("Parent"); } }
		class Child : Parent
		{ override void todo() { Console.WriteLine("Child");} }
		
		При вызове метода todo вот что будет
		child.todo(); // Child
		((Parent)child).todo(); // Child

		Но если реализовать через new
		class Child : Parent { new void todo(){ Console.WriteLine("Child");} }

		То при вызове будет по другому
		child.todo(); // Parent
		((Parent)child).todo(); // Parent

	* Так же разница будет если для создания класса потомка был использован класс родитель
		Parent child = new Child();
		//при override будет Child
		//при new будет Prent
		//при замещении(без virtual) будет всё равно Parent

	* ключевое слово override нельзя использовать без virtual, override or abstract, new можно, так как оно позволяет скрывать реализацию двух методов с однаковым нащванием в классе родителе и потомке
	
*/
using System;

namespace InterviewQuestions.Questions
{
	public class DifferencesBetweenOverrideAndNew: QuestionBase
	{		
		private class Parent
		{			
			public virtual void ToDoVirtual()
			{ Console.WriteLine("Parent"); }
			public void ToDo()
			{ Console.WriteLine("ToDoParent"); }
		}
		private class ChildOverride : Parent
		{
			public override void ToDoVirtual()
			{ Console.WriteLine("Child"); }
		}
		private class ChildNew : Parent
		{
			public new void ToDo()
			{ Console.WriteLine("ToDoChild"); }
		}
		public DifferencesBetweenOverrideAndNew()
		{
			QuestionData = new QuestionData()
			{
				QuestionDescription = " Отличие override от new",
				Topic = "Simple"
			};
		}
		public override void RunQuestion()
		{
			base.RunQuestion();
			ChildOverride co = new ChildOverride();
			Console.WriteLine("Для ToDoVirtual");
			Console.WriteLine("Для класса с override");
			Console.WriteLine("при обращении к дочернему классу");
			co.ToDoVirtual(); // Parent
			Console.WriteLine();

			ChildNew cn = new ChildNew();
			Console.WriteLine("Для класса с new");
			Console.WriteLine("при обращении к дочернему классу");
			cn.ToDoVirtual(); // Parent
			Console.WriteLine();

			Console.WriteLine("Если создавать класс потомок для Parent()\n");

			Parent cop = new ChildOverride();
			Console.WriteLine("Для класса с override");
			Console.WriteLine("при обращении к дочернему классу");
			cop.ToDoVirtual(); // Child
			Console.WriteLine();

			Parent cnp = new ChildNew();
			Console.WriteLine("Для класса с new");
			Console.WriteLine("при обращении к дочернему классу ");
			cnp.ToDoVirtual(); // Parent

			Console.WriteLine("\nДля ToDo");
			Console.WriteLine("Для класса с override");
			co.ToDo(); // ToDoParent
			Console.WriteLine("Для класса с new");
			cn.ToDo(); // ToDoChild
			Console.WriteLine("Для класса с override");
			cop.ToDo(); // ToDoParent
			Console.WriteLine("Для класса с new");
			cnp.ToDo(); // ToDoParent

		}
	}
}
