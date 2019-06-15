namespace The_Ray_Tracer_Challenge
{
    public class Canvas
    {
        private readonly Color[,] _canvas;

        public Canvas(int width, int height)
        {
            _canvas = new Color[width, height];
        }

        public int Width => _canvas.GetLength(0);
        public int Height => _canvas.GetLength(1);

        public void WritePixel(int x, int y, Color color) 
            => _canvas[x, y] = color;

        public Color PixelAt(int x, int y) 
            => _canvas[x, y];
    }
}
