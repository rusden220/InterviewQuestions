/*
	Как будет очищена память если не отписаться от события
*/
using System;

namespace InterviewQuestions.Questions
{
	public class MemoryLeakInEventContract : QuestionBase
	{
		private class Parent
		{
			public event EventHandler Event;			

		}
		private class Child
		{

		}

		public MemoryLeakInEventContract()
		{
			QuestionData = new QuestionData()
			{
				QuestionDescription = "Как будет очищена память если не отписаться от события",
				Topic = "event"
			};
		}
		public override void RunQuestion()
		{
			base.RunQuestion();

		}
	}
}
