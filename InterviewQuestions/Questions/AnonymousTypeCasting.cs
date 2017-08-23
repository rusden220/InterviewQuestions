using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Questions
{
	public class AnonymousTypeCasting : QuestionBase
	{
		public dynamic GetDynamic()
		{
			return new { Num = 1, Str = "Dynamic string" };
		}
		public void TestDynamic()
		{
			var t = GetDynamic();
			Console.WriteLine($"Num: { t.Num } Str: {t.Str}");
		}

		public object GetObject()
		{
			return new { Num = 2, Str = "Obj string" };
		}
		public T Cast<T>(object obj, T t)
		{
			return (T)obj;
		}
		public void TestObject()
		{
			var t = GetObject();
			var cast = Cast(t, new { Num = 1, Str = "" });
			Console.WriteLine($"Num: { cast.Num } Str: {cast.Str}");

		}
		public override void RunQuestion()
		{
			TestDynamic();
			TestObject();
			base.RunQuestion();
		}
	}
}
