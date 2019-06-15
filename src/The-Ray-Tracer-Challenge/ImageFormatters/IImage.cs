using System.IO;

namespace The_Ray_Tracer_Challenge.ImageFormatters
{
    public interface IImage
    {
        Stream AsStream();
    }
}
