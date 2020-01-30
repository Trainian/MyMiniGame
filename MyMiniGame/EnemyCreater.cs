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
            Random rnd = new Random();
            BaseFighter fighter;
            int ch = 1;
            string name = Enum.GetName(typeof(EnemyNames),ch);            
            ch = rnd.Next(1, Enum.GetNames(typeof(EnumClasses)).Length);

            fighter = ch switch
            {
                1 => new Warrior(name),
                2 => new Paladin(name),
                3 => new Mag(name),
                4 => new Priest(name),
                5 => new Archer(name),
                6 => new Thief(name),
                _ => throw new Exception("Хакер, что ли ?"),
            };

            return fighter;
        }

        //TODO: Релизовать поднятие уровня для противника при создании
        private static BaseFighter LevelUp (BaseFighter fighter)
        {
            return fighter;
        }

    }
}
