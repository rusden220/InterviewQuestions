/*
	
	При наследовании что происходит с приватными(private) полями и методами классов	
	* они наследуются, но доступа к ним нет, напрямую через рефлексию тоже(только если просмотреть все BaseType). 
		есть при чтении памяти напрямую или метод класса родителя

*/
using System;
using System.Runtime.InteropServices;


namespace InterviewQuestions.Questions
{
	public class AccessToPrivateFieldInDescendantClass:QuestionBase
	{
		[StructLayout(LayoutKind.Explicit)]
		private class Parent
		{
			[FieldOffset(0)]
			private int _nameP = 12345;
			public void ShowPrivateValue() { Console.WriteLine(_nameP); }
			private void ToDo() { }
		}
		[StructLayout(LayoutKind.Explicit)]
		private class Child:Parent
		{
			[FieldOffset(2)]
			private int _nameC = 6789;
			public void TryGetPrivateFiled()
			{
				var t = base.GetType().GetField("_nameP", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
				t?.GetValue(base.MemberwiseClone());
			}
			
		}
		/// <summary>
		/// class for work with pointer
		/// </summary>
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
			/// <summary>
			/// return pointer for object
			/// </summary>
			/// <param name="obj">object for which will get pinter</param>
			/// <returns></returns>
			public IntPtr GetPointer(object obj)
			{
				_objectWrapper._object = obj;
				//gcHandle = GCHandle.Alloc(_objectWrapper._object, GCHandleType.Pinned);
				return _intPtrWrapper._intPtr;
			}

		}
		public AccessToPrivateFieldInDescendantClass()
		{
			QuestionData = new QuestionData()
			{
				QuestionDescription = "При наследовании что происходит с приватными(private) полями и методами классов",
				Topic = "inside"
			};
		}
		public override void RunQuestion()
		{
			base.RunQuestion();
			var c = new Child();
			var t = c.GetType().GetField("_nameP", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
			c.TryGetPrivateFiled();
			Console.WriteLine(t?.GetValue(c));
			unsafe
			{
				IntPtr i = new Pointer().GetPointer(c);
				int* ptr = (int*)i.ToInt32();
				//Console.WriteLine(ptr[-2]);
				//Console.WriteLine(ptr[-1]);
				//Console.WriteLine(ptr[0]);
				Console.WriteLine($"Текущее значение переменной в классе родителя {ptr[1]}");
				Console.WriteLine("Измененяем на 123");
				ptr[1] = 123;
				Console.WriteLine("Смотрим значение через метод в класса родителя");
				c.ShowPrivateValue();

				//Console.WriteLine(ptr[2]);
				//Console.WriteLine(ptr[3]);
				//Console.WriteLine(ptr[4]);
			}

		}
	}
}
