namespace Projectile.Lib
{
    public static class RenderCycle
    {
        public static Projectile Tick(ProjectileEnvironment environment, Projectile projectile)
        {
            var position = projectile.Position + projectile.Velocity;
            var velocity = projectile.Velocity + environment.Gravity + environment.Wind;
            return new Projectile(position, velocity);
        }
    }
}
