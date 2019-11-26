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
            Console.WriteLine($"Name:{fighter.Name}, Class:{fighter.Class}, Health:{fighter.Health}, Mana:{fighter.Mana}");
            Console.WriteLine($"Strength:{fighter.Strength}, Defence:{fighter.Defence}, Agility:{fighter.Agility}, Intellegence:{fighter.Intellegence}");
            Console.WriteLine($"Abilitye:{fighter.Ability.Name}, Info:{fighter.Ability.FullInfo}");
        }
        internal static void SuperAbility (this BaseFighter fighterOne, BaseFighter fighterTwo)
        {
            fighterOne.Ability.Use(fighterOne, fighterTwo);
        }
        internal static void Attack (this BaseFighter fighterOne, BaseFighter fighterTwo)
        {
            fighterTwo.Health -= fighterOne.Strength;
            messager($"{fighterOne.Name} нанёс {fighterOne.Strength} урона {fighterTwo.Name}");
        }
    }
}
