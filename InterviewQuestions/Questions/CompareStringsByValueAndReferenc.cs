/*
	Сравнение строки по ссылке и по значению
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Questions
{
	public class CompareStringsByValueAndReferenc:QuestionBase
	{
		public CompareStringsByValueAndReferenc()
		{
			QuestionData = new QuestionData() { QuestionDescription = "Сравнение строки по ссылке и по значению ", Topic="Simple" };
		}
		public override void RunQuestion()
		{
			string str = "foo";
			Console.WriteLine("Insert foo");
			string str2 = Console.ReadLine();//inserted foo
			Console.WriteLine($"{nameof(str)} = {str}, {nameof(str2)} = {str2}");
			Console.WriteLine($"(object)str == (object)str2 {(object)str == (object)str2}"); // false
			Console.WriteLine($"str == str2 {str == str2}"); // true			
		}
	}
}
