using System;
using MyMiniGame.Fighters.Classes;

namespace MyMiniGame.Fighters.Enemys
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
            Random rnd = new Random(DateTime.Now.Millisecond);
            BaseFighter fighter;

            int ch = rnd.Next(1, Enum.GetNames(typeof(EnumEnemyNames)).Length);// Cлучайное Имя
            string name = Enum.GetName(typeof(EnumEnemyNames),ch); 

            ch = rnd.Next(1, Enum.GetNames(typeof(EnumClasses)).Length); // Случайный класс

            //TODO: Временно установка на создание бота, только как Thief
            ch = 6;
            //

            fighter = ch switch
            {
                1 => new Warrior(name),
                2 => new Paladin(name),
                3 => new Mag(name),
                4 => new Priest(name),
                5 => new Archer(name),
                6 => new Thief(name),
                _ => throw new NullReferenceException()
            };

            fighter.Level = (byte)lvl;
            if (lvl > 1) // Если уровень > 1, то улучшаем случайные характеристики
            {
                fighter.LvlUp = (byte)(lvl-1 * 3);
                while (fighter.LvlUp != 0)
                {
                    LevelUp.SetUpParams(fighter, null);
                    fighter.SetParametersToNormalize();
                }
            }

            return fighter;
        }

    }
}
