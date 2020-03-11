using System;
using System.Collections.Generic;
using MyMiniGame.Fighters.Abilitys.Interfaces;
using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects;

namespace MyMiniGame.Fighters.Abilitys.LowGrade
{
    public struct MagicShiled : IAbility
    {
        public List<EnumClasses> IdClass => new List<EnumClasses>(new EnumClasses[] {EnumClasses.Paladin});
        public string FullInfo => "Магический щит, дающий защиту при следующем ударе и восстанавливающий не много здоровья";

        public int Cost => 20;

        public string Name => "Лёгкий магический щит";

        public bool IsAttack => false;

        public int Use(BaseFighter fighter, BaseFighter enemy)
        {
            int hlth = fighter.Strength * 10;
            fighter.Health += hlth;
            Console.ForegroundColor = fighter.Color;
            Console.WriteLine($"{fighter.Name} лечится на {hlth}");
            Console.ForegroundColor = ConsoleColor.White;
            fighter.AddEffect(new Shield());
            return 0;
        }
    }
}
