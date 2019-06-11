using The_Ray_Tracer_Challenge;
using The_Ray_Tracer_Challenge.Extensions;

namespace Projectile
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var environment = new ProjectileEnvironment(new Vector(0, -0.1, 0), new Vector(-0.01, 0, 0));
            var projectile = new Projectile(new Point(0, 1, 0), new Vector(10, 15, 0).Normalize());

            while (projectile.Position.Y > 0)
            {
                Log(projectile);
                projectile = Tick(environment, projectile);
            }

            Log(projectile);
            System.Console.WriteLine("Done");
            System.Console.ReadLine();
        }

        private static void Log(Projectile projectile)
        {
            LogDistance(projectile);
            LogAscendingDescending(projectile);
            LogCoordinates(projectile);
        }

        private static void LogDistance(Projectile projectile)
            => System.Console.WriteLine($"Distance trvelled: {projectile.Position.X}");

        private static void LogAscendingDescending(Projectile projectile)
            => System.Console.WriteLine($"Projectile is {(projectile.Velocity.Y > 0 ? "Ascending" : "Descending")}");

        private static void LogCoordinates(Projectile projectile)
            => System.Console.WriteLine($"Position: ({projectile.Position.X}, {projectile.Position.Y}, {projectile.Position.Z}); Velocity: ({projectile.Velocity.X}, {projectile.Velocity.Y}, {projectile.Velocity.Z})");

        private static Projectile Tick(ProjectileEnvironment environment, Projectile projectile)
        {
            var position = projectile.Position + projectile.Velocity;
            var velocity = projectile.Velocity + environment.Gravity + environment.Wind;
            return new Projectile(position, velocity);
        }
    }
}
