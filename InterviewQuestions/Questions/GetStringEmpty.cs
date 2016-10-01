/*
	что возвращает string.Empty
	
		*пустую строку длинной 0 ""
*/
using System;

namespace InterviewQuestions.Questions
{
	class GetStringEmpty:QuestionBase
	{
		public GetStringEmpty()
		{
			QuestionData = new QuestionData()
			{
				QuestionDescription = " что возвращает string.Empty",
				Topic = "Simple"
			};
		}
		public override void RunQuestion()
		{
			base.RunQuestion();
			Console.WriteLine($"String.Empty: {String.Empty}(пустой символ \"\" не null) Len = {String.Empty.Length}");
		}
	}
}
