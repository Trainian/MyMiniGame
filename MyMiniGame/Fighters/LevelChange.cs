using MyMiniGame.Fighters.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters
{
    //TODO: Реализовать возможность роста уровня
    public static class LevelChange
    {
        /// <summary>
        /// Добавляем или отнимаем Опыт
        /// </summary>
        /// <param name="fighter">Боец</param>
        /// <param name="enemyLvl">Уровень противника</param>
        /// <param name="Win">Победил = True, Проиграл = False</param>
        public static void ExpSet (BaseFighter fighter, uint enemyLvl, bool Win)
        {
            var rnd = new Random(DateTime.Now.GetHashCode());

            if(Win)
            {
                fighter.Exp += enemyLvl * (uint)rnd.Next(200, 500);
                LevelSet(fighter);
            }
            else
            {
                fighter.Exp -= enemyLvl * (uint)rnd.Next(1, 3);
                // Проверяем на отрицательное значение опыта (в случае проигрыша) и не даём упасть ниже 0
                if (fighter.Exp < 0)
                    fighter.Exp = 0;
            }
        }
        /// <summary>
        /// Проверяем на возможность повышения уровня
        /// </summary>
        /// <param name="fighter">Боец</param>
        private static void LevelSet (BaseFighter fighter)
        {
            uint nextLevelExp;
            while((nextLevelExp = (uint)(fighter.Level * 10) * 2) < fighter.Exp)
            {
                // Проверяем на возможность повышения уровня и сбрасываем кол-во опыта на уровне
                if (fighter.Exp > nextLevelExp)
                {
                    fighter.Level++;
                    fighter.Exp -= nextLevelExp;
                    fighter.LvlUp += 3;
                }
            }
        }
    }
}
