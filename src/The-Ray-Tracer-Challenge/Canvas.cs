namespace The_Ray_Tracer_Challenge
{
    public class Canvas
    {
        private readonly Color[,] _canvas;

        public Canvas(int width, int height)
        {
            _canvas = new Color[width, height];
        }

        public Color this[int x, int y]
        {
            get => _canvas[x, y];
            set
            {
                if (x >= Width || x < 0)
                    return;

                if (y >= Height || y < 0)
                    return;

                _canvas[x, y] = value;
            }
        }

        public int Width => _canvas.GetLength(0);
        public int Height => _canvas.GetLength(1);
    }
}
