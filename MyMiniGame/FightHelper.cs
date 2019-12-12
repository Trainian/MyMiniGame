using MyMiniGame.Fighters;
using MyMiniGame.Fighters.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using static MyMiniGame.Messager;

namespace MyMiniGame
{
    internal static class FightHelper
    {
        internal static void fighterFullInfo(this BaseFighter fighter)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            messager?.Invoke($"Name:{fighter.Name}, Class:{fighter.Class}, Health:{fighter.Health}, Mana:{fighter.Mana}");
            messager?.Invoke($"Strength:{fighter.Strength}, Defence:{fighter.Defence}, Agility:{fighter.Agility}, Intellegence:{fighter.Intellegence}");
            messager?.Invoke($"Abilitye:{fighter.Ability}, Info:{fighter.Ability.FullInfo}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        internal static void fighterSmallInfo(this BaseFighter fighterOne)
        {
            Console.ForegroundColor = fighterOne.Color; 
            messager?.Invoke($"Fighter {fighterOne.Name} Health: {fighterOne.Health}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        internal static void fightersNormalInfo(BaseFighter fighterOne, BaseFighter fighterTwo)
        {
            Console.ForegroundColor = ConsoleColor.White;
            messager?.Invoke($"Fighter {fighterOne.Name} Health: {fighterOne.Health}");
            messager?.Invoke($"Fighter {fighterTwo.Name} Health: {fighterTwo.Health}");
        }
        internal static void changeFighters<T> (ref T fighterOne, ref T fighterTwo)
        {
            var temp = fighterOne;
            fighterOne = fighterTwo;
            fighterTwo = temp;
        }
    }
}
