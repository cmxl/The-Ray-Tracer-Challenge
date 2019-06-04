using The_Ray_Tracer_Challenge;

namespace Projectile
{
    public class Projectile
    {
        public Projectile(Tuple position, Tuple velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        public Tuple Position { get; }
        public Tuple Velocity { get; }
    }
}
