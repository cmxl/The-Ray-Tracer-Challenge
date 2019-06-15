using Projectile.Lib;
using System.Diagnostics;
using System.IO;
using The_Ray_Tracer_Challenge;
using The_Ray_Tracer_Challenge.Constants;
using The_Ray_Tracer_Challenge.Extensions;
using The_Ray_Tracer_Challenge.ImageFormatters;

namespace Projectile_Plotting
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var start = new Point(0, 1, 0);
            Tuple velocity = new Vector(1, 1.8, 0).Normalize();
            velocity *= 11.25;
            var gravity = new Vector(0, -0.1, 0);
            var wind = new Vector(-0.01, 0, 0);

            var environment = new ProjectileEnvironment(gravity, wind);
            var projectile = new Projectile.Lib.Projectile(start, velocity);
            var canvas = new Canvas(900, 550);

            while (projectile.Position.Y > 0)
            {
                var x = (int)projectile.Position.X;
                var y = (int)(canvas.Height - projectile.Position.Y);

                //canvas.WritePixel(x, y, Colors.Green);
                canvas.WritePixel(x, y, Colors.Green);
                projectile = RenderCycle.Tick(environment, projectile);
            }

            var formatter = new PPMImageFormatter();
            var content = formatter.CreateImage(canvas);
            File.WriteAllText("projectile.ppm", content);

            Process.Start("explorer", "projectile.ppm");
            System.Console.WriteLine("Done");
            System.Console.ReadLine();
        }
    }
}
