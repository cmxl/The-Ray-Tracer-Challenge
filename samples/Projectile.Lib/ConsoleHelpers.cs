namespace Projectile.Lib
{
    public static class ConsoleHelpers
    {
        public static void Log(Projectile projectile)
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
    }
}
