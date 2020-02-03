using MyMiniGame.Fighters;
using MyMiniGame.Fighters.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using static MyMiniGame.Messager;

namespace MyMiniGame
{
    internal static class FighterInfoHelper
    {
        /// <summary>
        /// Сообщение о совершенной атаке
        /// </summary>
        /// <param name="fighter">Атакующий</param>
        /// <param name="enemy">Защищающийся</param>
        /// <param name="dmg">Урон</param>
        public static void AttackMessage(BaseFighter fighter, BaseFighter enemy, int dmg)
        {
            Console.ForegroundColor = fighter.Color;
            Console.WriteLine($"{fighter.Name} нанёс {dmg} урона {enemy.Name}");
            Console.WriteLine($"Оставшееся здоровье {enemy.Name}: {enemy.Health}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Полная информация о бойце
        /// </summary>
        /// <param name="fighter">Боец</param>
        internal static void fighterFullInfo(BaseFighter fighter)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Name:{fighter.Name}, Class:{fighter.Class}, Level:{fighter.Level}, Exp:{fighter.Exp}");
            Console.WriteLine($"Health:{fighter.Health}, Mana:{fighter.Mana}");
            Console.WriteLine($"Strength:{fighter.Strength}, Defence:{fighter.Defence}, Agility:{fighter.Agility}, Intellegence:{fighter.Intellegence}");
            Console.WriteLine($"Ability:{fighter.Ability.Name}, Info:{fighter.Ability.FullInfo}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        internal static void fighterSmallInfo(BaseFighter fighter)
        {
            Console.ForegroundColor = fighter.Color;
            Console.WriteLine($"Fighter {fighter.Name}, Health: {fighter.Health}, Mana: {fighter.Mana}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Обычная информация о бойцах
        /// </summary>
        /// <param name="fighter">Атакующий</param>
        /// <param name="enemy">Защищающийся</param>
        internal static void fightersNormalInfo(BaseFighter fighter, BaseFighter enemy)
        {
            fighterInfoCreater(fighter);
            fighterInfoCreater(enemy);
            String str = new String('-', 40);
            Console.WriteLine(str);
        }
        /// <summary>
        /// Сообщение о бойце содержащее всю нужную для боя информацию
        /// </summary>
        /// <param name="fighter"></param>
        private static void fighterInfoCreater (BaseFighter fighter)
        {
            var effects = fighter.GetEffects();
            Console.ForegroundColor = fighter.Color;
            Console.WriteLine($"Fighter {fighter.Name}, Class: {fighter.Class}, Ability: {fighter.Ability.Name}");
            Console.WriteLine($"Health: {fighter.Health}, Mana:{fighter.Mana}");
            Console.Write("Эффекты: ");
            foreach (var item in effects)
            {
                Console.Write($" |-{item.Name}-| ");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        internal static void changeFighters<T> (ref T fighterOne, ref T fighterTwo)
        {
            var temp = fighterOne;
            fighterOne = fighterTwo;
            fighterTwo = temp;
        }
    }
}
