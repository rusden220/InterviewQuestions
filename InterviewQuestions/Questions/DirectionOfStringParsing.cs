/*
	В какую сторону парсится строка, и что будет выведено на экран
	result = $"{array[i]} = {array[++i]}";			

		* слева на право
		на экране будет в начале array[i]
		затем array[i + 1]
*/
using System;


namespace InterviewQuestions.Questions
{
	public class DirectionOfStringParsing: QuestionBase
	{
		public DirectionOfStringParsing()
		{
			QuestionData = new QuestionData()
			{ QuestionDescription = " В какую сторону парсится строка, и что будет выведено на экран result = $\"{array[i]} = {array[++i]}\"; ",
				Topic = "Simple" };
		}
		public override void RunQuestion()
		{
			base.RunQuestion();
			Console.WriteLine("слева на право");
			int i = 0;
			int[] array = new int[] { 0, 1, 2 };
			Console.WriteLine("{array[i]} = {array[++i]}");
			Console.WriteLine($"{array[i]} = {array[++i]}");
		}
	}
}
