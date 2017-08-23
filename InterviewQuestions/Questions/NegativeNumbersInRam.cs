/*
	Как хранятся отрицательные числа в памяти

		* в последнем бите(31 или 63) стоит 1 или 0, если 0 - число положительное, 1 - число отрицательное, но инвертированное, число -1 будет 111...1111, а число -3 - 111...1101

*/
using System;
using System.Runtime.InteropServices;

namespace InterviewQuestions.Questions
{
	public class NegativeNumbersInRam:QuestionBase
	{
		[StructLayout(LayoutKind.Explicit)]
		private class Pointer
		{
			class IntPtrWrapper { public IntPtr _intPtr; }
			class ObjectWrapper { public object _object; }
			[FieldOffset(0)]
			private ObjectWrapper _objectWrapper;//object for which will get pinter
			[FieldOffset(0)]
			private IntPtrWrapper _intPtrWrapper;//pointer for object	
			public Pointer()
			{
				_intPtrWrapper = new IntPtrWrapper();
				_objectWrapper = new ObjectWrapper();
			}
						
			public IntPtr GetPointer(object obj)
			{
				_objectWrapper._object = obj;
				//gcHandle = GCHandle.Alloc(_objectWrapper._object, GCHandleType.Pinned);
				return _intPtrWrapper._intPtr;
			}

		}
		public NegativeNumbersInRam()
		{
			QuestionData = new QuestionData()
			{
				QuestionDescription = "Как хранятся отрицательные числа в памяти",
				Topic = "Inside"
			};
		}
		public override void RunQuestion()
		{
			base.RunQuestion();
			int x = int.MaxValue;
			int y = 0x7FFFFFFF;
			unsafe
			{
				y = 2020612176;// 240 224 48 160
				string str = "HelŬo";
				byte* ptr = (byte*)(new Pointer().GetPointer(y).ToInt32());
				for (int i = 0; i < 20; i++)
				{
					Console.WriteLine($"({i}): {(char)ptr[i]} = {ptr[i]}");
                }
				//ptr[7] = 255;
				Console.WriteLine(y);
				Console.WriteLine("##");

				byte b = (byte)x;
				byte* ptr_x = &b;
				byte* ptr_y = (byte*)y;

				Console.WriteLine(ptr_y[0]);
				Console.WriteLine(ptr_y[1]);
				Console.WriteLine((uint)ptr_y[2]);
				Console.WriteLine((uint)ptr_y[3]);

				Console.WriteLine(ptr_x[0]);
				Console.WriteLine((uint)ptr_y[0]);

			}
		}
	}
}
