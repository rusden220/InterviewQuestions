using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Questions
{
	public class DifferencesBetweenDictionaryAndHashSet: QuestionBase
	{

		public override void RunQuestion()
		{
			HashSet<string> hashSet = new HashSet<string>();
			Dictionary<int, string> dict = new Dictionary<int, string>();

			string testString = "testString";
			hashSet.Add(testString);
			try
			{
				var result = hashSet.Add(testString);
				//testString = "testString2";
				unsafe
				{
					fixed(char* ptr_char = testString)
					{
						ptr_char[1] = '1';
					}
				}
				result = hashSet.Add(testString);
			}
			catch (Exception ex)
			{

				throw;
			}
			

			base.RunQuestion();
		}
	}
}
