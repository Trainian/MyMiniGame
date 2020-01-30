using MyMiniGame.Fighters.Classes;
using System;
using System.Collections.Generic;
using System.Text;
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
            string strCh;
            int ch;

            do
            {
                Console.Clear();
                Console.WriteLine($"Добро пожаловать, {fighter.Name}");
                Console.WriteLine("Что будем делать ?");
                Console.WriteLine("1 - Найти противника\n2 - Повысить уровень\n3 - Магазин\n4 - Информация о герое\n5 - Выход в меню");
                strCh = Console.ReadLine();
                if(int.TryParse(strCh,out ch))
                {
                    switch(ch)
                    {
                        case 1:
                            var fm = new FightMenu(fighter);
                            fm.StartAtack();
                            break;
                        case 2:
                            throw new MissingMethodException("Реализация в процессе");
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
                            break;
                        default:
                            break;
                    }
                }
            } while (ch != 5);
        }
    }
}
