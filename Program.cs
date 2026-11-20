using System.Diagnostics;

namespace SpaceInvaders
{
    internal class Program
    {
        static Random r = new Random();
        static char[,] map = new char[10, 45];
        static char[] playerLayer = new char[45];
        static void GeneratePlayer()
        {
            for (int i = 0; i < playerLayer.Length; i++)
            {
                playerLayer[i] = ' ';
            }

            playerLayer[Convert.ToInt32((playerLayer.Length / 2))] = 'P';
        }
        static void DisplayPlayer()
        {
            foreach (char item in playerLayer)
            {
                Console.Write(item);
            }
        }
        static void GenerateMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = ' ';
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
        static void GenerateBaricade()
        {
            for (int j = 7; j < map.GetLength(1) - 7; j++)
            {
                if (j % 5 == 0)
                {
                    map[(map.GetLength(0) - 1), j] = ' ';
                }
                else
                {
                    map[(map.GetLength(0) - 1), j] = '▀';
                }
            }
        }
        static void EnemyMovement()
        {

        }
        static void Bullet()
        {
            int bulletX = map.GetLength(1) / 2;
            int bulletY = map.GetLength(0) - 2;
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    bulletY = map.GetLength(0) - 1;
                    while (bulletY > 0)
                    {
                        map[bulletY, bulletX] = '|';
                        Console.Clear();
                        DisplayMap();
                        GeneratePlayer();
                        Thread.Sleep(250);
                        map[bulletY, bulletX] = ' ';
                        bulletY--;
                    }
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
            GenerateBaricade();
            DisplayMap();
            GeneratePlayer();
            DisplayPlayer();
            Bullet();
            while (true)
            {
                ConsoleKeyInfo info = Console.ReadKey(true);

                if (info.Key == ConsoleKey.D)
                {

                    for (int i = playerLayer.Length - 1; i >= 0; i--)
                    {
                        if (playerLayer[i] == 'P' && i + 1 < playerLayer.Length)
                        {
                            playerLayer[i] = ' ';
                            playerLayer[i + 1] = 'P';
                            break;
                        }
                    }
                }
                else if (info.Key == ConsoleKey.A)
                {

                    for (int i = 0; i < playerLayer.Length; i++)
                    {
                        if (playerLayer[i] == 'P' && i - 1 >= 0)
                        {
                            playerLayer[i] = ' ';
                            playerLayer[i - 1] = 'P';
                            break;
                        }
                    }
                }

                Console.Clear();
                DisplayMap();
                DisplayPlayer();
            }
            Console.Read();
        }
    }
}