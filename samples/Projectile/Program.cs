using Projectile.Lib;
using The_Ray_Tracer_Challenge;
using The_Ray_Tracer_Challenge.Extensions;

namespace Projectile
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var environment = new ProjectileEnvironment(new Vector(0, -0.1, 0), new Vector(-0.01, 0, 0));
            var projectile = new Lib.Projectile(new Point(0, 1, 0), new Vector(10, 15, 0).Normalize());

            while (projectile.Position.Y > 0)
            {
                ConsoleHelpers.Log(projectile);
                projectile = RenderCycle.Tick(environment, projectile);
            }

            ConsoleHelpers.Log(projectile);
            System.Console.WriteLine("Done");
            System.Console.ReadLine();
        }
    }
}
