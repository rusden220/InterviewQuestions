using System;

namespace InterviewQuestions.Questions
{
	/// <summary>
	/// Contain Data for a question
	/// </summary>
	public struct QuestionData
	{
		/// <summary>
		/// the question store here
		/// </summary>
		public string QuestionDescription { get; set; }
		/// <summary>
		/// topic of the question	
		/// </summary>
		public string Topic { get; set; }

	}
	/// <summary>
	/// Question base class
	/// </summary>
	public abstract class QuestionBase
	{
#if QUEST_NUM
		private int _questionNumber{get; set;}
#endif
		private QuestionData _questionData;
		/// <summary>
		/// Contain data for the question
		/// </summary>
		/// не автосвойство потому что потом должно быть переписано с учётом номер вопроса
		protected QuestionData QuestionData
		{
			get { return _questionData; }
			set { _questionData = value; }
		} 

		/// <summary>
		/// Show information about the question
		/// </summary>
		public virtual void PrintInformation()
		{
#if QUEST_NUM
			Console.WriteLine($"number of the question{_questionNumber}");
#endif
			Console.WriteLine($"topic of the question: {_questionData.Topic}");
			Console.WriteLine($"description of the question: {_questionData.QuestionDescription}");
		}
		/// <summary>
		/// If the answer to the question requires an explanation
		/// </summary>
		public virtual void RunQuestion()
		{
			PrintInformation();
		}
	}
}
