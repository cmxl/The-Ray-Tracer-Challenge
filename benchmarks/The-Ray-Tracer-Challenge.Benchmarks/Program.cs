using BenchmarkDotNet.Running;

namespace The_Ray_Tracer_Challenge.Benchmarks
{
    internal class Program
    {
        private static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}
