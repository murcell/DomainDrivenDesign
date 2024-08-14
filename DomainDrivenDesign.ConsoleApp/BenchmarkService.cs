using BenchmarkDotNet.Attributes;

namespace DomainDrivenDesign.ConsoleApp
{
	public class BenchmarkService
	{
		[Benchmark(Baseline = true)]
		public void Equals() 
		{
			int id = 1;
			Test1 test1 = new Test1();
			Test2 test2 = new Test2();
            Console.WriteLine(test1.Equals(test2));
        }

		[Benchmark]
		public void Equatable()
		{
			int id = 1;
			Test2 test1 = new Test2();
			Test2 test2 = new Test2();
			Console.WriteLine(test1.Equals(test2));
		}
	}


	public class Test1
	{
        public int Id { get; set; }
        public override bool Equals(object? obj)
		{
			if (obj == null) return false;

			if (obj is not Test1 entity) return false;

			if (obj.GetType() != GetType()) return false;

			return entity.Id == Id;
		}
	}

	public class Test2 : IEquatable<Test2>
	{
		public int Id { get; set; }
		public override bool Equals(object? obj)
		{
			if (obj == null) return false;

			if (obj is not Test2 entity) return false;

			if (obj.GetType() != GetType()) return false;

			return entity.Id == Id;
		}

		public bool Equals(Test2? other)
		{
			if (other == null) return false;

			if (other is not Test2 entity) return false;

			if (other.GetType() != GetType()) return false;

			return entity.Id == Id;
		}
	}

}
