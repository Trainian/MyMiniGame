﻿using MyMiniGame.Fighters.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using static MyMiniGame.Messager;

namespace MyMiniGame
{
    class MainMenu
    {
        /// <summary>
        /// Сартовое меню, для начала игры, Загрузки игры, Информации об игре или выходе
        /// </summary>
        public void StartMenu ()
        {
            string strCh;
            int ch;
            GameMenu gm;

            do
            {
                Console.Clear();
                messager?.Invoke("Доброе пожаловать !");
                messager?.Invoke("1 - Начать игру\n2 - Загрузить игру\n3 - О игре\n4 - Выход");
                strCh = Console.ReadLine();
                if (int.TryParse(strCh, out ch))
                {
                    switch (ch)
                    {
                        case 1:
                            var fighter = FighterCreateHelper.FighterCreate(); // Создание персонажа
                            gm = new GameMenu();
                            gm.Start(fighter); // Старт Игры
                            break;
                        case 2:
                            throw new MissingMethodException("Реализация в процессе");
                            break;
                        case 3:
                            throw new MissingMethodException("Реализация в процессе");
                            break;
                        case 4:
                            break;
                        default:
                            throw new NotSupportedException("Хакер, что ли");
                            break;
                    }
                }
            } while (ch != 4);

        }
    }
}
