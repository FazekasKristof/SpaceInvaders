<img width="1152" height="648" alt="alaprajz1" src="https://github.com/user-attachments/assets/a760a82d-d037-46ae-b419-887bff9acedd" />
-----
    ConsoleKeyInfo info = Console.ReadKey(true); 

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
