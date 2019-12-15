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
        /// Начинает бой
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="fighterTwo">Защищающийся</param>
        /// <returns>Возвращает значение TRUE - если бой закончился и FALSE - если бой продолжается</returns>
        public static bool Fight (BaseFighter fighterOne, BaseFighter fighterTwo)
        {
            int attack = 0;
            attack += fighterOne.Attack(fighterTwo);
            attack += fighterOne.Effects(fighterTwo);
            fighterOne.SuperAbility(fighterTwo);

            if (attack > 0)
                fighterTwo.Health -= attack;
            else
                attack = 0;

            FighterInfoHelper.fightersNormalInfo(fighterOne, fighterTwo);

            Console.ForegroundColor = fighterOne.Color;
            messager($"{fighterOne.Name} нанёс {attack} урона {fighterTwo.Name}");
            messager($"Оставшееся здоровье противника: {fighterTwo.Health}");
            Console.ForegroundColor = ConsoleColor.White;

            return fighterTwo.IsDeath();
        }
        /// <summary>
        /// Проверяет на смерть
        /// </summary>
        /// <param name="fighter">Боец</param>
        /// <returns>Возвращает TRUE - если мертв и FALSE - если жив</returns>
        private static bool IsDeath (this BaseFighter fighter)
        {
            if (fighter.Health <= 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Использование супер-способностей
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="fighterTwo">Защищающийся</param>
        /// <returns>Накладывает положительные или отрицательные эффекты</returns>
        private static int SuperAbility(this BaseFighter fighterOne, BaseFighter fighterTwo)
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
        /// Обычная такая
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="fighterTwo">Защищающийся</param>
        /// <returns>Возвращает атаку = Силе</returns>
        private static int Attack(this BaseFighter fighterOne, BaseFighter fighterTwo)
        {
            return fighterOne.Strength;
        }
        /// <summary>
        /// Подсчет атаки или защиты Положительных и Отриацательных эффектов.
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="FighterTwo">Защищающийся</param>
        /// <returns>Возвращается разница между уроном эффектов</returns>
        private static int Effects(this BaseFighter fighterOne, BaseFighter FighterTwo)
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
        private static int RunEffects (List<IEffect> effects, BaseFighter fighter)
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
    }
}