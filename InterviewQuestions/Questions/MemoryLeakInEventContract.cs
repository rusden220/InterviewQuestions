/*
	Как будет очищена память если не отписаться от события
	(MemoryLeakInEventContract)

	* Она не будет очищаться, если подписчик это коротокоживущий объект, а издатель долгоживущий, то будет возникать утечка памяти(memory leak). Так как сборщик мусора не сможет удалить коротко живущий объект.

	//если использовать weak reference возможно будет отписака, проверить
*/
using System;

namespace InterviewQuestions.Questions
{
	public class MemoryLeakInEventContract : QuestionBase
	{
		private class EventClass
		{
			public event EventHandler Event;
			public void RaiseEvent()
			{
				Console.WriteLine(nameof(RaiseEvent));
				Event.Invoke(this, null);
			}
			~EventClass()
			{
				Console.WriteLine($"{nameof(EventClass)} deleted");
			}
		}
		private class Subscriber
		{
			private EventClass _eventClass;
			public Subscriber ()
			{
				_eventClass = new EventClass();
			}
						
			public void AddIntoEvent()
			{
				_eventClass.Event += _eventClass_Event;
				Console.WriteLine(nameof(AddIntoEvent));			
			}
			private void _eventClass_Event(object sender, EventArgs e)
			{
				Console.WriteLine(nameof(_eventClass_Event));
			}
			public void RaiseEvent()
			{
				_eventClass.RaiseEvent();
			}
			~Subscriber()
			{
				Console.WriteLine($"{nameof(Subscriber)} deleted");
			}
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
			Subscriber s = new Subscriber();
			s.AddIntoEvent();
			s.RaiseEvent();
			s = null;
			GC.Collect();
		}
	}
}
