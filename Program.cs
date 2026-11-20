namespace SpaceInvaders
{
    internal class Program
    {
        static Random r = new Random();
        static char[,] map = new char[10, 50];
        static void GenerateMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = 'x';
                }
            }
        }
        static void GenerateEnemy()
        {
            int sorokSzama = r.Next(3, 6);
            for (int i = 1; i < sorokSzama; i++)
            {
                for (int j = 7; j < map.GetLength(1) - 7; j++)
                {
                    map[i, j] = '@';
                }
            }
        }
        static void DisplayMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            GenerateMap();
            GenerateEnemy();
            DisplayMap();
            Console.Read();
        }
    }
}
