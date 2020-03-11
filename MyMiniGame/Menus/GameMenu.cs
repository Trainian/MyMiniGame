using MyMiniGame.Fighters.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using MyMiniGame.Fighters;
using static MyMiniGame.Messager;

namespace MyMiniGame.Menus
{
    /// <summary>
    /// Класс для Начала Атаки, Повышения уровня, Магазина и т.д.
    /// </summary>
    class GameMenu
    {
        public void Start (BaseFighter fighter)
        {
            BaseFighter bfighter = fighter;
            string strCh;
            int ch;

            do
            {
                Console.Clear();
                Console.WriteLine($"Добро пожаловать, {bfighter.Name}");
                Console.WriteLine("Что будем делать ?");
                Console.WriteLine("1 - Найти противника\n2 - Повысить уровень\n3 - Магазин\n4 - Информация о герое\n5 - Выход в меню");
                strCh = Console.ReadLine();
                if(int.TryParse(strCh,out ch))
                {
                    switch(ch)
                    {
                        case 1:
                            var fm = new FightMenu(bfighter);
                            fm.StartAttack();
                            break;
                        case 2:
                            LevelUp.Menu(fighter);
                            break;
                        case 3:
                            throw new MissingMethodException("Реализация в процессе");
                            break;
                        case 4:
                            FighterInfoHelper.fighterFullInfo(fighter);
                            Console.WriteLine("Для продолжения, нажмите 'Enter'...");
                            Console.ReadLine();
                            break;
                        case 5:
                            //Выход в Главное меню
                            break;
                        default:
                            continue;
                    }
                }
            } while (ch != 5);
        }
    }
}
