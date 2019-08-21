using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Projectile.Lib;
using The_Ray_Tracer_Challenge.Constants;
using The_Ray_Tracer_Challenge.Extensions;

namespace The_Ray_Tracer_Challenge.Benchmarks
{

    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class Render
    {
        private Point _start;
        private Tuple _velocity;
        private Vector _gravity;
        private Vector _wind;

        [GlobalSetup]
        public void Setup()
        {
            _start = new Point(0, 1, 0);
            _velocity = new Vector(1, 1.8, 0).Normalize();
            _velocity *= 11.25;
            _gravity = new Vector(0, -0.1, 0);
            _wind = new Vector(-0.01, 0, 0);
        }


        [Benchmark(Description = "Initialize Canvas")]
        [Arguments(900, 550)]
        [Arguments(1920, 1080)]
        [Arguments(2540, 1440)]
        public Canvas InitializeCanvas(int x, int y) => new Canvas(x, y);

        [Benchmark(Description = "Tick until Y <= 0")]
        [Arguments(900, 550)]
        [Arguments(1920, 1080)]
        [Arguments(2540, 1440)]
        public Canvas Tick(int x, int y)
        {
            var environment = new ProjectileEnvironment(_gravity, _wind);
            var projectile = new Projectile.Lib.Projectile(_start, _velocity);
            var canvas = new Canvas(x, y);

            while (projectile.Position.Y > 0)
            {
                var X = (int)projectile.Position.X;
                var Y = (int)(canvas.Height - projectile.Position.Y);
                canvas[X, Y] = Colors.Green;
                projectile = RenderCycle.Tick(environment, projectile);
            }
            return canvas;
        }
    }
}
