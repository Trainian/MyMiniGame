using System;
using System.Collections.Generic;
using MyMiniGame.Fighters.Abilitys.Interfaces;
using MyMiniGame.Fighters.Classes;

namespace MyMiniGame.Fighters.Abilitys.LowGrade
{
    public struct Cure : IAbility
    {
        public List<EnumClasses> IdClass => new List<EnumClasses>(new EnumClasses[] {EnumClasses.Priest});
        public string FullInfo => "Восстанавливает немного здоровья";

        public int Cost => 30;

        public string Name => "Лёгкое Лечение";

        public bool IsAttack => false;

        public void Use(BaseFighter fighter, BaseFighter enemy)
        {
            int hlth = (int)(fighter.Intellegence * 15);
            fighter.Mana -= Cost;
            Console.ForegroundColor = fighter.Color;
            Console.WriteLine($"---> {fighter.Name} лечится на {hlth}! <---");
            Console.ForegroundColor = ConsoleColor.White;
            fighter.Health += hlth;
        }
    }
}
