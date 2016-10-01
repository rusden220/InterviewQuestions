/*
	Сколько строк будет храниться в памяти 
	string str = "foo";
	string str2 = str;
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Questions
{
	public class StringComparisonWithPoolIntern:QuestionBase
	{
		public StringComparisonWithPoolIntern()
		{
			QuestionData = new QuestionData() { QuestionDescription = "Сколько строк сколько строк будет храниться в памяти string str = \"foo\"; string str2 = str; ", Topic="inside" };
		}
		public override void RunQuestion()
		{
			base.RunQuestion();
			//переписать с expression
			string str = "foo";
			string str2 = str;
			Console.WriteLine($"{nameof(str)} = foo; {nameof(str2)} = {nameof(str)}");			
			Console.WriteLine($"(object)str == (object)str2 {(object)str == (object)str2}"); // true
			Console.WriteLine($"str == str2 {str == str2}"); // true
			Console.WriteLine("потому что есть пул интернирования строк в котором хранятся все константы и даже если будет так\n");
			str2 = "fo" + "o";
			Console.WriteLine($"{nameof(str)} = foo; {nameof(str2)} = \"fo\" + \"o\"");
			Console.WriteLine($"(object)str == (object)str2 {(object)str == (object)str2}"); // true
			Console.WriteLine($"str == str2 {str == str2}"); // true	
		}	
	}
}
