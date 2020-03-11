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
        private static int damage;
        /// <summary>
        /// Старт атаки
        /// </summary>
        /// <param name="fighter">Атакующий</param>
        /// <param name="enemy">Защитник</param>
        /// <param name="choise">Выбор атакаи, обычная или магичская</param>
        /// <returns>true - Смерть одного из бойцов</returns>
        public static void StartAttack(this BaseFighter fighter, BaseFighter enemy, EnumAttackChoise choice)
        {
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
            enemy.Health -= damage;
            FighterInfoHelper.AttackMessage(fighter, enemy, damage);
        }


        /// <summary>
        /// Обычная такая
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="fighterTwo">Защищающийся</param>
        private static void BaseAttack(this BaseFighter fighter, BaseFighter enemy)
        {
            damage = (fighter.Strength * 10) - enemy.Defence;
            //Находим все Атакующие\Активные эффекты и прибавляем к атаке
            var effects = fighter.GetEffects().FindAll(x => x.IsAttackOrDeffence == true && x.IsActiveOrPassive == false);
            foreach (var effect in effects)
            {
                damage += effect.Run(enemy,damage);
            }
        }


        /// <summary>
        /// Использование супер-способностей
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="fighterTwo">Защищающийся</param>
        private static void SuperAbility(this BaseFighter fighter, BaseFighter enemy)
        {
            damage = 0;
            damage = fighter.Ability.Use(fighter, enemy);
            if(fighter.Ability.IsAttack)
            {
                var effects = fighter.GetEffects().FindAll(x => x.IsAttackOrDeffence == true && x.IsActiveOrPassive == false && x.IsPositiveOrNegative == true);
                foreach (var effect in effects)
                {
                    damage += effect.Run(enemy, damage);
                }
            }
        }


        /// <summary>
        /// Запуск отрицательных эффектов
        /// </summary>
        /// <param name="fighter">Боец</param>
        public static void EffectsNegative(this BaseFighter fighter)
        {
            var negEffects = fighter?.GetEffects().FindAll(x => x.IsPositiveOrNegative == false && x.IsActiveOrPassive == false && x.IsAttackOrDeffence == false);
            RunEffects(negEffects, fighter);
        }


        /// <summary>
        /// Запуск положительных эффектов
        /// </summary>
        /// <param name="fighter">Боец</param>
        public static void EffectsPositive(this BaseFighter fighter)
        {
            var posEffects = fighter?.GetEffects().FindAll(x => x.IsPositiveOrNegative == true && x.IsActiveOrPassive == false && x.IsAttackOrDeffence == false);
            RunEffects(posEffects, fighter);
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
                effect.Run(fighter, 0);
                if (effect.Ticks <= 0)
                    fighter.RemoveEffect(effect);
            }
        }
    }
}