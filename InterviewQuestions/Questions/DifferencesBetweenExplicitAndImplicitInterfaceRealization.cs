using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Questions
{
	public class DifferencesBetweenExplicitAndImplicitInterfaceRealization: QuestionBase
	{
		public interface IC1
		{
			void ToDo();
		}
		public interface IC2
		{
			void ToDo();
		}
		public class TestClass : IC1, IC2
		{
			public void ToDo()
			{
				Console.WriteLine(nameof(TestClass));
			}
			void IC2.ToDo()
			{
				Console.WriteLine(nameof(IC2));
			}

			void IC1.ToDo()
			{
				Console.WriteLine(nameof(IC1));
			}
		}
		public override void RunQuestion()
		{
			TestClass tc = new TestClass();
			tc.ToDo();
			((IC1)tc).ToDo();
			((IC2)tc).ToDo();
			base.RunQuestion();
		}
	}
}
