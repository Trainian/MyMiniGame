using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static MyMiniGame.Messager;

namespace MyMiniGame
{
    static class Battle
    {
        /// <summary>
        /// Обычная такая
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="fighterTwo">Защищающийся</param>
        /// <returns>Возвращает атаку = Силе + Эффекты</returns>
        public static void BaseAttack(this BaseFighter fighter, BaseFighter enemy)
        {
            int dmg = 0;
            dmg += fighter.Strength;
            //Находим все Атакующие\Пассивные эффекты
            var effects = fighter.Effects.FindAll(x => x.IsActiveOrPassive == true && x.IsActiveOrPassive == false);
            foreach (var effect in effects)
            {
                effect.Run(dmg);
            }
            enemy.Health -= dmg;
            FighterInfoHelper.AttackMessage(fighter,enemy,dmg);
        }
        /// <summary>
        /// Использование супер-способностей
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="fighterTwo">Защищающийся</param>
        /// <returns>Накладывает положительные или отрицательные эффекты</returns>
        public static void SuperAbility(this BaseFighter fighter, BaseFighter enemy)
        {
            if (fighter.Ability.IsAttack == false)
            {
                fighter.Ability.Use(fighter, enemy);
            }
            else
            {
                fighter.Ability.Use(fighter, enemy);
            }
        }
        /// <summary>
        /// Подсчет атаки или защиты Положительных и Отриацательных эффектов.
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="FighterTwo">Защищающийся</param>
        /// <returns>Возвращается разница между уроном эффектов</returns>
        public static void Effects(this BaseFighter fighter, BaseFighter enemy)
        {
            int dmg = 0;
            var posEffects = enemy.Effects.FindAll(x => x.IsPositiveOrNegative == true);
            dmg += RunEffects(posEffects, enemy);

            var negEffects = enemy.Effects.FindAll(x => x.IsPositiveOrNegative == false);
            dmg += RunEffects(negEffects, enemy);

        }
        /// <summary>
        /// Выполняет эффекты и удаляет уже завершившиеся
        /// </summary>
        /// <param name="effects">Лист эффектов для выполнения, Негативные или Положительные</param>
        /// <param name="fighter">Боей, чьи эффекты будут запускаться</param>
        /// <returns>Возвращает урон от эффектов в int</returns>
        public static int RunEffects (List<IEffect> effects, BaseFighter fighter)
        {
            int dmg = 0;
            foreach (var effect in effects)
            {
                dmg += effect.Run(dmg);
                if (effect.Ticks <= 0)
                    fighter.Effects.Remove(effect);
            }
            return dmg;
        }
        /// <summary>
        /// Проверяет на смерть
        /// </summary>
        /// <param name="fighter">Боец</param>
        /// <returns>Возвращает TRUE - если мертв и FALSE - если жив</returns>
        public static bool IsDeath(this BaseFighter fighter)
        {
            if (fighter.Health <= 0)
                return true;
            else
                return false;
        }
    }
}