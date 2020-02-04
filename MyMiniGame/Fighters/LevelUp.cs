using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using MyMiniGame.Fighters.Classes;

namespace MyMiniGame.Fighters
{
    public static class LevelUp
    {
        public static void Menu (BaseFighter fighter)
        {
            int ch = 0;
            string strCh;

            if (fighter.LvlUp > 0)
            {
                do
                {
                    Console.Clear();
                    fighter.SetParametersToNormalize(); // Пересчитываем кол-во Маны и Жизни
                    FighterInfoHelper.fighterFullInfo(fighter); // Информация о пользователе
                    Console.WriteLine($"Колличество очков для распределения: {fighter.LvlUp}");
                    Console.WriteLine("Выберите характеристику, для повышения:");
                    Console.WriteLine("1 - Сила, увеличивает атаку и немного добовляет жизней");
                    Console.WriteLine("2 - Защита, увеличивает сопротивляемость урону");
                    Console.WriteLine("3 - Ловкость, даёт шанс уклониться и сделать два удара подрят");
                    Console.WriteLine("4 - Интеллект, увеличивает силу Спецспособности и количество Маны");
                    Console.WriteLine("0 - Выйти обратно в меню\n");

                    strCh = Console.ReadLine();
                    if (int.TryParse(strCh, out ch))
                    {
                        switch (ch)
                        {
                            case 1:
                                fighter.Strength++;
                                break;
                            case 2:
                                fighter.Defence++;
                                break;
                            case 3:
                                fighter.Agility++;
                                break;
                            case 4:
                                fighter.Intellegence++;
                                break;
                            case 0:
                                break;
                            default:
                                break;
                        }

                    }

                    fighter.LvlUp--;

                } while (fighter.LvlUp != 0 && ch != 0);
            }

            Console.Clear();
            fighter.SetParametersToNormalize(); // Пересчитываем кол-во Маны и Жизни
            FighterInfoHelper.fighterFullInfo(fighter); // Информация о пользователе
            Console.WriteLine("Нет очков для распределения.\n\nДля продолжения, нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
