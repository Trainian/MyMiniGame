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
        /// <returns>Возвращает атаку = Силе</returns>
        public static int BaseAttack(this BaseFighter fighterOne, BaseFighter fighterTwo)
        {
            return fighterOne.Strength;
        }
        /// <summary>
        /// Использование супер-способностей
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="fighterTwo">Защищающийся</param>
        /// <returns>Накладывает положительные или отрицательные эффекты</returns>
        public static int SuperAbility(this BaseFighter fighterOne, BaseFighter fighterTwo)
        {
            int attack = 0;
            if(fighterOne.Mana >= fighterOne.Ability.Cost)
            {
                Console.ForegroundColor = fighterOne.Color;

                fighterOne.Mana =- fighterOne.Ability.Cost;
                fighterOne.Ability.Use(fighterOne, fighterTwo);

                Console.ForegroundColor = ConsoleColor.White;
            }
            return attack;
        }
        /// <summary>
        /// Подсчет атаки или защиты Положительных и Отриацательных эффектов.
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="FighterTwo">Защищающийся</param>
        /// <returns>Возвращается разница между уроном эффектов</returns>
        public static int Effects(this BaseFighter fighterOne, BaseFighter FighterTwo)
        {
            int dmg = 0;
            var posEffects = FighterTwo.Effects.FindAll(x => x.IsPositive == true);
            dmg += RunEffects(posEffects, FighterTwo);

            var negEffects = FighterTwo.Effects.FindAll(x => x.IsPositive == false);
            dmg += RunEffects(negEffects, FighterTwo);

            return dmg;
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
                dmg += effect.Run(fighter);
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