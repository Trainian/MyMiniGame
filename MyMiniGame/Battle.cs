using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MyMiniGame.Menus;
using static MyMiniGame.Messager;

namespace MyMiniGame
{
    static class Battle
    {
        /// <summary>
        /// Старт атаки
        /// </summary>
        /// <param name="fighter">Атакующий</param>
        /// <param name="enemy">Защитник</param>
        /// <param name="choise">Выбор атакаи, обычная или магичская</param>
        /// <returns>true - Смерть одного из бойцов</returns>
        public static bool StartAttack(this BaseFighter fighter, BaseFighter enemy, EnumAttackChoise choice)
        {
            fighter.Effects();
            if (IsDeath(fighter))
                return true;

            switch (choice)
            {
                case EnumAttackChoise.BaseAttack:
                    fighter.BaseAttack(enemy);
                    break;
                case EnumAttackChoise.MagicAttack:
                    fighter.SuperAbility(enemy);
                    break;
                default:
                    throw new NullReferenceException("Ошибка выбора атаки");
            }
            if (IsDeath(enemy))
                return true;

            else return false;
        }


        /// <summary>
        /// Обычная такая
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="fighterTwo">Защищающийся</param>
        private static void BaseAttack(this BaseFighter fighter, BaseFighter enemy)
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
        private static void SuperAbility(this BaseFighter fighter, BaseFighter enemy)
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
        public static void Effects(this BaseFighter fighter)
        {
            var posEffects = fighter.GetEffects().FindAll(x => x.IsPositiveOrNegative == true && x.IsActiveOrPassive == false && x.IsAttackOrDeffence == false);
            RunEffects(posEffects, fighter);

            var negEffects = fighter.GetEffects().FindAll(x => x.IsPositiveOrNegative == false && x.IsActiveOrPassive == false && x.IsAttackOrDeffence == false);
            RunEffects(negEffects, fighter);
        }


        /// <summary>
        /// Выполняет эффекты и удаляет уже завершившиеся
        /// </summary>
        /// <param name="effects">Лист эффектов для выполнения, Негативные или Положительные</param>
        /// <param name="fighter">Боей, чьи эффекты будут запускаться</param>
        private static void RunEffects (List<IEffect> effects, BaseFighter fighter)
        {
            foreach (var effect in effects)
            {
                effect.Run(fighter);
                if (effect.Ticks <= 0)
                    fighter.RemoveEffect(effect);
            }
        }


        private static bool IsDeath(BaseFighter fighter)
        {
            return fighter.Health <= 0;
        }
    }
}