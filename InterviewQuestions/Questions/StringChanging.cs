/*
	Можно ли изменять строки в C#
		
		* да, но только через unsafe
*/
using System;

namespace InterviewQuestions.Questions
{
	public class StringChanging:QuestionBase
	{
		public StringChanging()
		{
			QuestionData = new QuestionData()
			{
				QuestionDescription = "Можно ли изменять строки в C#",
				Topic = "inside"
			};
		}
		public override void RunQuestion()
		{
			base.RunQuestion();
			string str = "Hello, World";
			Console.WriteLine(str);
			Console.WriteLine("use unsafe");
			unsafe
			{
				fixed(char* ptr_char = str)
				{
					ptr_char[2] = '1';
				}
			}
			Console.WriteLine("after unsafe " + str);
			Console.WriteLine("Resize");
			
			unsafe
			{
				fixed (char* ptr_char = str)
				{
					ptr_char[-2] = (char)(str.Length + 1);
					char t = ptr_char[12];
					Console.WriteLine(str);
					ptr_char[12] = '!';
					ptr_char[13] = '\0';
				}
				Console.WriteLine("after unsafe resize" + str);
			}
		}
	}
}
