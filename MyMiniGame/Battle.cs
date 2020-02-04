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
        public static void BaseAttack(this BaseFighter fighter, BaseFighter enemy)
        {
            //TODO: По думать по поводу того что бы убрать временные переменные в бойцах
            enemy.TempDamage += (uint)((fighter.Strength * 10) - enemy.Defence);
            //Находим все Атакующие\Активные эффекты и прибавляем к атаке
            var effects = fighter.GetEffects().FindAll(x => x.IsAttackOrDeffence == true && x.IsActiveOrPassive == false);
            foreach (var effect in effects)
            {
                effect.Run(enemy);
            }
            enemy.Health -= (int)enemy.TempDamage;

            FighterInfoHelper.AttackMessage(fighter, enemy, (int)enemy.TempDamage);
            enemy.TempDamage = 0;
        }
        /// <summary>
        /// Использование супер-способностей
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="fighterTwo">Защищающийся</param>
        public static void SuperAbility(this BaseFighter fighter, BaseFighter enemy)
        {
            fighter.Ability.Use(fighter, enemy);
            if(fighter.Ability.IsAttack)
            {
                var effects = fighter.GetEffects().FindAll(x => x.IsAttackOrDeffence == true && x.IsActiveOrPassive == false && x.IsPositiveOrNegative == true);
                foreach (var effect in effects)
                {
                    effect.Run(enemy);
                }
            }
        }
        /// <summary>
        /// Подсчет атаки или защиты Положительных и Отриацательных эффектов.
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="FighterTwo">Защищающийся</param>
        public static void Effects(BaseFighter fighter, BaseFighter enemy)
        {
            var posEffects = fighter.GetEffects().FindAll(x => x.IsPositiveOrNegative == true && x.IsActiveOrPassive == false && x.IsAttackOrDeffence == false);
            RunEffects(posEffects, fighter);

            var negEffects = fighter.GetEffects().FindAll(x => x.IsPositiveOrNegative == false && x.IsActiveOrPassive == false && x.IsAttackOrDeffence == false);
            RunEffects(negEffects, fighter);

            posEffects = enemy.GetEffects().FindAll(x => x.IsPositiveOrNegative == true && x.IsActiveOrPassive == false && x.IsAttackOrDeffence == false);
            RunEffects(posEffects, enemy);

            negEffects = enemy.GetEffects().FindAll(x => x.IsPositiveOrNegative == false && x.IsActiveOrPassive == false && x.IsAttackOrDeffence == false);
            RunEffects(negEffects, enemy);
        }
        /// <summary>
        /// Выполняет эффекты и удаляет уже завершившиеся
        /// </summary>
        /// <param name="effects">Лист эффектов для выполнения, Негативные или Положительные</param>
        /// <param name="fighter">Боей, чьи эффекты будут запускаться</param>
        public static void RunEffects (List<IEffect> effects, BaseFighter fighter)
        {
            foreach (var effect in effects)
            {
                effect.Run(fighter);
                if (effect.Ticks <= 0)
                    fighter.RemoveEffect(effect);
            }
        }
    }
}