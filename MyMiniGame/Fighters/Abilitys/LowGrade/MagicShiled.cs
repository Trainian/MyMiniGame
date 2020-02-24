using MyMiniGame.Fighters.Abilitys.Interfaces;
using MyMiniGame.Fighters.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using MyMiniGame.Fighters.Effects;

namespace MyMiniGame.Fighters.Abilitys
{
    class MagicShiled : IAbility
    {
        public List<EnumClasses> IdClass => new List<EnumClasses>(new EnumClasses[] {EnumClasses.Paladin});
        public string FullInfo => "Магический щит, дающий защиту при следующем ударе и восстанавливающий не много здоровья";

        public int Cost => 20;

        public string Name => "Лёгкий магический щит";

        public bool IsAttack => false;

        public void Use(BaseFighter fighter, BaseFighter enemy)
        {
            int hlth = fighter.Strength * 10;
            fighter.Health += hlth;
            Console.WriteLine($"{fighter.Name} лечится на {hlth}");
            fighter.AddEffect(new Shield());
        }
    }
}
