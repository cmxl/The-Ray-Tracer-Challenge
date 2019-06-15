using System.IO;
using System.Text;

namespace The_Ray_Tracer_Challenge.ImageFormatters
{
    public class PPMImage : IImage
    {
        internal PPMImage(string content)
        {
            Content = content;
        }

        public string Content { get; }

        public Stream AsStream()
        {
            var bytes = Encoding.Unicode.GetBytes(Content);
            return new MemoryStream(bytes);
        }

        public IImage FromStream(Stream stream)
        {
            string content;
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                var bytes = ms.ToArray();
                content = Encoding.Unicode.GetString(bytes);
            }
            // streams do contain the string terminater
            // we do not care about it and remove it
            return new PPMImage(content.Trim('\0'));
        }
    }
}
