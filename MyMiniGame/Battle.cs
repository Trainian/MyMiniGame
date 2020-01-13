﻿using MyMiniGame.Fighters.Classes;
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
            //Находим все Атакующие\Пассивные эффекты и прибавляем к атаке
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
            fighter.Ability.Use(fighter, enemy);
        }
        /// <summary>
        /// Подсчет атаки или защиты Положительных и Отриацательных эффектов.
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="FighterTwo">Защищающийся</param>
        /// <returns>Возвращается разница между уроном эффектов</returns>
        public static void Effects(BaseFighter fighter, BaseFighter enemy)
        {
            //Сделать перебор только по пассивным эффектам и запускать их
            var posEffects = fighter.Effects.FindAll(x => x.IsPositiveOrNegative == true && x.IsActiveOrPassive == false);
            RunEffects(posEffects, fighter);

            var negEffects = fighter.Effects.FindAll(x => x.IsPositiveOrNegative == false && x.IsActiveOrPassive == false);
            RunEffects(negEffects, fighter);

            posEffects = enemy.Effects.FindAll(x => x.IsPositiveOrNegative == true && x.IsActiveOrPassive == false);
            RunEffects(posEffects, enemy);

            negEffects = enemy.Effects.FindAll(x => x.IsPositiveOrNegative == false && x.IsActiveOrPassive == false);
            RunEffects(negEffects, enemy);
        }
        /// <summary>
        /// Выполняет эффекты и удаляет уже завершившиеся
        /// </summary>
        /// <param name="effects">Лист эффектов для выполнения, Негативные или Положительные</param>
        /// <param name="fighter">Боей, чьи эффекты будут запускаться</param>
        /// <returns>Возвращает урон от эффектов в int</returns>
        public static void RunEffects (List<IEffect> effects, BaseFighter fighter)
        {
            foreach (var effect in effects)
            {
                effect.Run(0);
                if (effect.Ticks <= 0)
                    fighter.Effects.Remove(effect);
            }
        }
    }
}