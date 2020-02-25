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
                Console.WriteLine("5 - Случайный параметр");
                Console.WriteLine("0 - Выйти обратно в меню\n");

                strCh = Console.ReadLine();
                if (fighter.LvlUp == 0)
                {
                    Console.Clear();
                    fighter.SetParametersToNormalize(); // Пересчитываем кол-во Маны и Жизни
                    FighterInfoHelper.fighterFullInfo(fighter); // Информация о пользователе
                    Console.WriteLine("Нет очков для распределения.\n\nДля продолжения, нажмите любую кнопку...");
                    Console.ReadKey();
                    break;
                }
                if (int.TryParse(strCh, out ch))
                {
                    switch (ch)
                    {
                        case 1:
                            SetUpParams(fighter, EnumParameters.Strength);
                            break;
                        case 2:
                            SetUpParams(fighter, EnumParameters.Defence);
                            break;
                        case 3:
                            SetUpParams(fighter, EnumParameters.Agility);
                            break;
                        case 4:
                            SetUpParams(fighter, EnumParameters.Intellegence);
                            break;
                        case 5:
                            SetUpParams(fighter, null);
                            break;
                        case 0:
                            break;
                        default:
                            break;
                    }

                }

            } while (ch != 0);

        }


        public static void SetUpParams(BaseFighter fighter, EnumParameters? pr)
        {
            if (pr == null)
            {
                Random rnd = new Random(DateTime.Now.Millisecond);
                int temp = rnd.Next(1, Enum.GetNames(typeof(EnumParameters)).Length);
                pr = (EnumParameters)Enum.Parse(typeof(EnumParameters), (Enum.GetName(typeof(EnumParameters), temp)));
            }
            switch (pr)
            {
                case EnumParameters.Strength:
                    fighter.Strength++;
                    break;
                case EnumParameters.Defence:
                    fighter.Defence++;
                    break;
                case EnumParameters.Agility:
                    fighter.Agility++;
                    break;
                case EnumParameters.Intellegence:
                    fighter.Intellegence++;
                    break;
            }
            fighter.LvlUp--;
        }
    }
}
