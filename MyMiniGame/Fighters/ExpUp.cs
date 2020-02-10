using MyMiniGame.Fighters.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters
{
    /// <summary>
    /// Получение опыта
    /// </summary>
    public static class ExpUp
    {
        /// <summary>
        /// Добавляем опыт
        /// </summary>
        /// <param name="fighter">Боец</param>
        /// <param name="enemyLvl">Уровень противника</param>
        /// <param name="Win">Победил = True, Проиграл = False</param>
        public static void ExpSet (BaseFighter fighter, uint enemyLvl)
        {
            var rnd = new Random(DateTime.Now.GetHashCode());

            fighter.Exp += enemyLvl * (uint)rnd.Next(20, 25);
            LevelSet(fighter);
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
