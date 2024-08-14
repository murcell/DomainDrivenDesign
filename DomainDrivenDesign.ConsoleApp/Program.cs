using BenchmarkDotNet.Running;

namespace DomainDrivenDesign.ConsoleApp;

internal class Program
{
	static void Main(string[] args)
	{

		BenchmarkRunner.Run<BenchmarkService>();
		Console.ReadLine();
	}
}
