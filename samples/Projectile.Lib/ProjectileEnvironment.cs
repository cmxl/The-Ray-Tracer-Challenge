using The_Ray_Tracer_Challenge;

namespace Projectile.Lib
{
    public class ProjectileEnvironment
    {
        public ProjectileEnvironment(Tuple gravity, Tuple wind)
        {
            Gravity = gravity;
            Wind = wind;
        }

        public Tuple Gravity { get; }
        public Tuple Wind { get; }
    }
}
