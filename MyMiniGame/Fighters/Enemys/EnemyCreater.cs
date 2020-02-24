using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Enemys;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame
{
    public static class EnemyCreater
    {
        /// <summary>
        /// Создает нового Случайного бойца, с уровнем = lvl
        /// </summary>
        /// <param name="lvl">Уровень бойца</param>
        /// <returns>Возвращает нового бойца с уровнем = lvl</returns>
        public static BaseFighter CreateEnemy (int lvl)
        {
            lvl += 3;
            Random rnd = new Random(DateTime.Now.Millisecond);
            BaseFighter fighter;
            int ch = rnd.Next(0, Enum.GetNames(typeof(EnumNames)).Length-1);

            string name = Enum.GetName(typeof(EnumNames),ch); // Cлучайное Имя
            ch = rnd.Next(1, Enum.GetNames(typeof(EnumClasses)).Length); // Случайный класс

            fighter = ch switch
            {
                1 => new Warrior(name),
                2 => new Paladin(name),
                3 => new Mag(name),
                4 => new Priest(name),
                5 => new Archer(name),
                6 => new Thief(name)
            };

            fighter.Level = (byte)lvl;
            if (lvl > 1)
                fighter.LvlUp = (byte)(lvl * 3);

            fighter = LevelUp(fighter);
            return fighter;
        }

        private static BaseFighter LevelUp (BaseFighter fighter)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            while (fighter.LvlUp > 0)
            {
                switch (rnd.Next(1,4))
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
                }

                fighter.LvlUp--;
            }
            return fighter;
        }

    }
}
