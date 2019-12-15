using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame
{
    class MainMenu
    {
        public void StartMenu ()
        {
            string tmpCh;
            int ch;

            Console.WriteLine("Доброе пожаловать !");
            Console.WriteLine("1 - Начать игру\n2 - Загрузить игру\n3 - О игре");
            do
            {
                tmpCh = Console.ReadLine();
                if (int.TryParse(tmpCh,out ch))
                {

                }

            } while (true);

        }
    }
}
