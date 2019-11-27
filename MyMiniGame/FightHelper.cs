using System;
using System.Collections.Generic;
using System.Text;
using static MyMiniGame.Program;

namespace MyMiniGame
{
    internal static class FightHelper
    {
        internal static void fighterFullInfo(this BaseFighter fighter)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Name:{fighter.Name}, Class:{fighter.Class}, Health:{fighter.Health}, Mana:{fighter.Mana}");
            Console.WriteLine($"Strength:{fighter.Strength}, Defence:{fighter.Defence}, Agility:{fighter.Agility}, Intellegence:{fighter.Intellegence}");
            Console.WriteLine($"Abilitye:{fighter.Ability.Name}, Info:{fighter.Ability.FullInfo}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        internal static void fighterSmallInfo(this BaseFighter fighterOne)
        {
            Console.ForegroundColor = fighterOne.Color;
            Console.WriteLine("Fighter {0} Health: {1}", fighterOne.Name, fighterOne.Health);
            Console.ForegroundColor = ConsoleColor.White;
        }
        internal static void fightersNormalInfo(BaseFighter fighterOne, BaseFighter fighterTwo)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Fighter {0} Health: {1}", fighterOne.Name, fighterOne.Health);
            Console.WriteLine("Fighter {0} Health: {1}", fighterTwo.Name, fighterTwo.Health);
        }
        internal static void SuperAbility (this BaseFighter fighterOne, BaseFighter fighterTwo)
        {
            Console.ForegroundColor = fighterOne.Color;
            fighterOne.Ability.Use(fighterOne, fighterTwo);
            Console.ForegroundColor = ConsoleColor.White;
        }
        internal static void Attack (this BaseFighter fighterOne, BaseFighter fighterTwo)
        {
            Console.ForegroundColor = fighterOne.Color;
            fighterTwo.Health -= fighterOne.Strength;
            messager($"{fighterOne.Name} нанёс {fighterOne.Strength} урона {fighterTwo.Name}");
            messager($"Оставшееся здоровье противника: {fighterTwo.Health}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        internal static void Reverse<T> (ref T fighterOne,ref T fighterTwo) where T : BaseFighter
        {
            var temp = fighterOne;
            fighterOne = fighterTwo;
            fighterTwo = temp;
        }
    }
}
