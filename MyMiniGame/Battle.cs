using MyMiniGame.Fighters.Classes;
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
            foreach (var effect in posEffects)
            {
                dmg += effect.Run(FighterTwo);
                if (effect.Ticks <= 0)
                    FighterTwo.Effects.Remove(effect);
            }

            var negEffects = FighterTwo.Effects.FindAll(x => x.IsPositive == false);
            foreach (var effect in negEffects)
            {
                dmg += effect.Run(FighterTwo);
                if (effect.Ticks <= 0)
                    FighterTwo.Effects.Remove(effect);
            }
            return dmg;
        }
    }
}
//-> Выбор Действия
//1) Обычная атака / Магическая атака

//    а) Получаем обычныую атаку и добавляем эффекты

//        i) Подсчитываем ману, если это магия

//        ii) Если нет маны, то пропускам, если есть то добавляем эффекты

//    б) Плюсуем атаку с эффектами

//    в) Выводим атаку