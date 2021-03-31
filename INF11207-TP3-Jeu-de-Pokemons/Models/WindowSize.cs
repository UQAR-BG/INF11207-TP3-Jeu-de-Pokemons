namespace INF11207_TP3_Jeu_de_Pokemons.Models
{
    public class WindowSize
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public WindowSize(int height, int width)
        {
            Width = width;
            Height = height;
        }
    }
}
