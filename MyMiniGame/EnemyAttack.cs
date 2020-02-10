using System;
using System.Collections.Generic;
using System.Text;
using MyMiniGame.Fighters.Classes;

namespace MyMiniGame
{
    /// <summary>
    /// Класс для формирования атаки противника (компьютера)
    /// </summary>
    public static class EnemyAttack
    {
        private static int _numberAttack = 0;

        /// <summary>
        /// Сформировать атаку
        /// </summary>
        /// <param name="fighter">Игрок</param>
        /// <param name="enemy">Компьютер</param>
        public static void Attack(BaseFighter fighter, BaseFighter enemy)
        {
            _numberAttack++;
            if (_numberAttack % 4 == 0 && enemy.Mana >= enemy.Ability.Cost)
            {
                enemy.SuperAbility(fighter);
            }
            else
                enemy.BaseAttack(fighter);
        }
    }
}
